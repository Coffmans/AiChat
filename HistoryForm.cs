using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AiChat
{
    /// <summary>
    /// Shows the raw JSON-style message history so you can see exactly
    /// what gets sent to the API each turn.
    /// </summary>
    public class HistoryForm : Form
    {
        public HistoryForm(IEnumerable<Message> history, string systemPrompt)
        {
            Text          = "Raw Message History";
            Size          = new Size(700, 500);
            MinimumSize   = new Size(500, 300);
            StartPosition = FormStartPosition.CenterParent;

            var rtb = new RichTextBox
            {
                Dock      = DockStyle.Fill,
                ReadOnly  = true,
                Font      = new Font("Consolas", 9.5F),
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.FromArgb(220, 220, 220),
                WordWrap  = true,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            // System prompt block
            AppendColored(rtb, "SYSTEM PROMPT\n", Color.Gold);
            AppendColored(rtb, systemPrompt + "\n\n", Color.LightYellow);

            // Message turns
            AppendColored(rtb, "MESSAGE HISTORY\n", Color.Gold);
            int i = 1;
            foreach (var msg in history)
            {
                Color labelColor = msg.Role == "user" ? Color.SteelBlue : Color.MediumSeaGreen;
                AppendColored(rtb, $"[{i++}] {msg.Role.ToUpper()}\n", labelColor);
                AppendColored(rtb, msg.Content + "\n\n", Color.FromArgb(220, 220, 220));
            }

            Controls.Add(rtb);
        }

        private static void AppendColored(RichTextBox rtb, string text, Color color)
        {
            rtb.SelectionStart  = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionColor  = color;
            rtb.AppendText(text);
        }
    }
}
