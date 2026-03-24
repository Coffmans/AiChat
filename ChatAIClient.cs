using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace AiChat
{
    public class ChatAIClient
    {
        private string json = "";

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly HttpClient _http;

        public ChatAIClient()
        {
            _http = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(120)
            };
        }

        /// <summary>
        /// Sends the current conversation history and returns the assistant reply.
        /// </summary>
        public async Task<string> SendAsync(IEnumerable<Message> history, string systemPrompt, string apiBaseUrl, string apiModelName, CancellationToken ct = default)
        {
            var requestBody = new
            {
                model = apiModelName,
                messages = BuildOpenAiMessages(systemPrompt, history)
            };

            json = JsonSerializer.Serialize(requestBody, _jsonOptions);

            using var content  = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await _http.PostAsync(apiBaseUrl, content, ct);

            string responseBody = await response.Content.ReadAsStringAsync(ct);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"API error {(int)response.StatusCode}: {responseBody}");

            using var doc = JsonDocument.Parse(responseBody);
            var choices = doc.RootElement.GetProperty("choices");
            var firstChoice = choices[0];
            return firstChoice
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? string.Empty;
        }

        private static List<object> BuildOpenAiMessages(string systemPrompt, IEnumerable<Message> history)
        {
            var messages = new List<object>();

            // System prompt goes first as its own message
            if (!string.IsNullOrWhiteSpace(systemPrompt))
            {
                messages.Add(new { role = "system", content = systemPrompt });
            }

            // Then the conversation history
            foreach (var msg in history)
            {
                messages.Add(new { role = msg.Role, content = msg.Content });
            }

            return messages;
        }
    }

    // ── Simple model classes ────────────────────────────────────────────────

    public record Message(
        [property: JsonPropertyName("role")]    string Role,
        [property: JsonPropertyName("content")] string Content
    );
}
