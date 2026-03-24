using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AiChat
{
    public class AppSettings
    {
        [JsonPropertyName("apiBaseUrl")]
        public string ApiBaseUrl { get; set; } = "";

        [JsonPropertyName("apiModelName")]
        public string ApiModelName { get; set; } = "";

        [JsonPropertyName("systemPrompt")]
        public string SystemPrompt { get; set; } = "";

        private static readonly string SettingsFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "AiChat"
        );

        private static readonly string SettingsFilePath = Path.Combine(SettingsFolder, "settings.json");

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        /// <summary>
        /// Loads settings from file. Returns default settings if file doesn't exist or error occurs.
        /// </summary>
        public static AppSettings Load()
        {
            try
            {
                if (!File.Exists(SettingsFilePath))
                {
                    return new AppSettings();
                }

                string json = File.ReadAllText(SettingsFilePath);
                return JsonSerializer.Deserialize<AppSettings>(json, _jsonOptions) ?? new AppSettings();
            }
            catch (Exception ex)
            {
                // Log error if you have logging, otherwise just return defaults
                System.Diagnostics.Debug.WriteLine($"Failed to load settings: {ex.Message}");
                return new AppSettings();
            }
        }

        /// <summary>
        /// Saves settings to file.
        /// </summary>
        public void Save()
        {
            try
            {
                // Ensure directory exists
                Directory.CreateDirectory(SettingsFolder);

                string json = JsonSerializer.Serialize(this, _jsonOptions);
                File.WriteAllText(SettingsFilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save settings: {ex.Message}");
                throw; // Re-throw so caller can handle it
            }
        }
    }
}