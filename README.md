# AiChat

<b>AiChat</b> is a small desktop AI chat client that communicates with any OpenAI-compatible API endpoint. It's designed to be provider-agnostic — you configure the API URL and model name at runtime, which is exactly why it works with Ollama, LM Studio, etc. It can be easily adapted to work with OpenAI and Claude.

<b>Key Files:</b>
- ChatAIClient.cs — The core HTTP client that handles communication with the AI API. It uses HttpClient to POST to your configured endpoint, builds the OpenAI-style message format (with system prompt + conversation history), and parses the response. It has a 120-second timeout.
- MainForm.cs — The main chat UI window
- ApiSettingsForm.cs — The settings form where you configure your API base URL and model name
- AppSettings.cs — Handles saving/loading your settings
- HistoryForm.cs — A form for viewing chat history
- Program.cs — The app entry point

The ChatAIClient builds a standard OpenAI-format request with a system message followed by the conversation history, then POSTs it directly to whatever full endpoint URL you provide. 

<b>Examples:</b>
- LM Studio
  - Endpoint: http://localhost:1234/v1/chat/completions
  - Model Name: lmstudio-community/Qwen2.5-Coder-7B-Instruct-GGUF
- Ollama
  - http://localhost:11434/v1/chat/completions
  - qwen3:4b
