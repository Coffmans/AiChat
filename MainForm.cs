using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiChat
{
    public partial class MainForm : Form
    {
        private readonly ChatAIClient _client;
        private readonly List<Message> _messageHistory = [];
        private readonly CancellationTokenSource _cts;
        private readonly AppSettings _settings;

        public MainForm()
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
            _client = new ChatAIClient();
            
            // Load settings
            _settings = AppSettings.Load();
            
            UpdateTokenEstimate();
        }

        // ── Send ────────────────────────────────────────────────────────────
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            string userText = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            SetUiEnabled(false);
            txtInput.Clear();

            _messageHistory.Add(new Message("user", userText));
            AppendToChatLog("You", userText, Color.SteelBlue);



            try
            {
                string systemPrompt = txtSystemPrompt.Text.Trim();
                string reply = await _client.SendAsync(_messageHistory, systemPrompt, 
                    _settings.ApiBaseUrl, _settings.ApiModelName, _cts.Token);

                _messageHistory.Add(new Message("assistant", reply));
                AppendToChatLog("Chat AI", reply, Color.ForestGreen);
            }
            catch (OperationCanceledException)
            {
                AppendToChatLog("System", "Request cancelled.", Color.Gray);
            }
            catch (Exception ex)
            {
                AppendToChatLog("Error", ex.Message, Color.Crimson);
            }
            finally
            {
                SetUiEnabled(true);
                UpdateTokenEstimate();
            }
        }

        // ── Cancel ──────────────────────────────────────────────────────────
        private void BtnCancel_Click(object sender, EventArgs e) => _cts?.Cancel();

        // ── Clear History ────────────────────────────────────────────────────
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _messageHistory.Clear();
            rtbChat.Clear();
            UpdateTokenEstimate();
            AppendToChatLog("System", "Conversation cleared. Starting fresh.", Color.Gray);
        }

        // ── View Raw History ─────────────────────────────────────────────────
        private void BtnViewHistory_Click(object sender, EventArgs e)
        {
            using var dlg = new HistoryForm(_messageHistory, txtSystemPrompt.Text.Trim());
            dlg.ShowDialog(this);
        }

        // ── Allow Enter to send (Shift+Enter = newline) ──────────────────────
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                BtnSend_Click(sender, e);
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────────
        private void AppendToChatLog(string speaker, string text, Color color)
        {
            if (rtbChat.InvokeRequired)
            {
                rtbChat.Invoke(new Action(() => AppendToChatLog(speaker, text, color)));
                return;
            }

            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;

            // Speaker label
            rtbChat.SelectionColor = color;
            rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Bold);
            rtbChat.AppendText($"{speaker}:\n");

            // Body
            rtbChat.SelectionColor = rtbChat.ForeColor;
            rtbChat.SelectionFont = rtbChat.Font;
            rtbChat.AppendText($"{text}\n\n");

            rtbChat.ScrollToCaret();
        }

        private void SetUiEnabled(bool enabled)
        {
            btnSend.Enabled = enabled;
            btnCancel.Enabled = !enabled;
            txtInput.Enabled = enabled;
            btnClear.Enabled = enabled;
            btnViewHistory.Enabled = enabled;
            lblStatus.Text = enabled ? "Ready" : "Waiting for response…";
        }

        private void UpdateTokenEstimate()
        {
            // Rough estimate: ~4 chars per token
            int chars = txtSystemPrompt.Text.Length;
            foreach (var m in _messageHistory) chars += m.Content.Length;
            int estimate = chars / 4;
            lblTokens.Text = $"~{estimate:N0} tokens in context";
        }

        private void TxtSystemPrompt_TextChanged(object sender, EventArgs e) => UpdateTokenEstimate();

        // ── ApiSettingsButton ─────────────────────────────────────────────
        private void BtnApiSettings_Click(object sender, EventArgs e)
        {
            ApiSettingsForm settingsForm = new(_settings.ApiBaseUrl, _settings.ApiModelName);
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                _settings.ApiBaseUrl = settingsForm.ApiBaseUrl;
                _settings.ApiModelName = settingsForm.ApiModelName;
                
                // Save settings
                try
                {
                    _settings.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save settings: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── OnFormClosing ──────────────────────────────────────────────────
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            try
            {
                _settings.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save settings on close: {ex.Message}");
            }
        }
    }
}
