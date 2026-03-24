namespace AiChat
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            splitMain = new System.Windows.Forms.SplitContainer();
            pnlLeft = new System.Windows.Forms.Panel();
            BtnApiSettings = new System.Windows.Forms.Button();
            txtSystemPrompt = new System.Windows.Forms.RichTextBox();
            lblSystemPrompt = new System.Windows.Forms.Label();
            btnViewHistory = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            lblTokens = new System.Windows.Forms.Label();
            pnlRight = new System.Windows.Forms.Panel();
            pnlInput = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            txtInput = new System.Windows.Forms.RichTextBox();
            btnSend = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            lblStatus = new System.Windows.Forms.Label();
            rtbChat = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // splitMain
            // 
            splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitMain.Location = new System.Drawing.Point(0, 0);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(pnlLeft);
            splitMain.Panel1MinSize = 220;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(pnlRight);
            splitMain.Size = new System.Drawing.Size(899, 645);
            splitMain.SplitterDistance = 220;
            splitMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(BtnApiSettings);
            pnlLeft.Controls.Add(txtSystemPrompt);
            pnlLeft.Controls.Add(lblSystemPrompt);
            pnlLeft.Controls.Add(btnViewHistory);
            pnlLeft.Controls.Add(btnClear);
            pnlLeft.Controls.Add(lblTokens);
            pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLeft.Location = new System.Drawing.Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new System.Windows.Forms.Padding(8);
            pnlLeft.Size = new System.Drawing.Size(220, 645);
            pnlLeft.TabIndex = 0;
            // 
            // BtnApiSettings
            // 
            BtnApiSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            BtnApiSettings.Location = new System.Drawing.Point(9, 601);
            BtnApiSettings.Name = "BtnApiSettings";
            BtnApiSettings.Size = new System.Drawing.Size(200, 25);
            BtnApiSettings.TabIndex = 5;
            BtnApiSettings.Text = "API Settings";
            BtnApiSettings.UseVisualStyleBackColor = true;
            BtnApiSettings.Click += BtnApiSettings_Click;
            // 
            // txtSystemPrompt
            // 
            txtSystemPrompt.Dock = System.Windows.Forms.DockStyle.Top;
            txtSystemPrompt.Font = new System.Drawing.Font("Consolas", 9F);
            txtSystemPrompt.Location = new System.Drawing.Point(8, 112);
            txtSystemPrompt.Name = "txtSystemPrompt";
            txtSystemPrompt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            txtSystemPrompt.Size = new System.Drawing.Size(204, 180);
            txtSystemPrompt.TabIndex = 0;
            txtSystemPrompt.Text = "You are a helpful assistant. Be concise and clear.";
            txtSystemPrompt.TextChanged += TxtSystemPrompt_TextChanged;
            // 
            // lblSystemPrompt
            // 
            lblSystemPrompt.Dock = System.Windows.Forms.DockStyle.Top;
            lblSystemPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSystemPrompt.Location = new System.Drawing.Point(8, 90);
            lblSystemPrompt.Name = "lblSystemPrompt";
            lblSystemPrompt.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            lblSystemPrompt.Size = new System.Drawing.Size(204, 22);
            lblSystemPrompt.TabIndex = 1;
            lblSystemPrompt.Text = "System Prompt";
            // 
            // btnViewHistory
            // 
            btnViewHistory.Dock = System.Windows.Forms.DockStyle.Top;
            btnViewHistory.Location = new System.Drawing.Point(8, 60);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new System.Drawing.Size(204, 30);
            btnViewHistory.TabIndex = 2;
            btnViewHistory.Text = "View Raw History";
            btnViewHistory.Click += BtnViewHistory_Click;
            // 
            // btnClear
            // 
            btnClear.Dock = System.Windows.Forms.DockStyle.Top;
            btnClear.Location = new System.Drawing.Point(8, 30);
            btnClear.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(204, 30);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear History";
            btnClear.Click += BtnClear_Click;
            // 
            // lblTokens
            // 
            lblTokens.Dock = System.Windows.Forms.DockStyle.Top;
            lblTokens.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblTokens.ForeColor = System.Drawing.Color.Gray;
            lblTokens.Location = new System.Drawing.Point(8, 8);
            lblTokens.Name = "lblTokens";
            lblTokens.Size = new System.Drawing.Size(204, 22);
            lblTokens.TabIndex = 4;
            lblTokens.Text = "~0 tokens in context";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(pnlInput);
            pnlRight.Controls.Add(rtbChat);
            pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlRight.Location = new System.Drawing.Point(0, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new System.Drawing.Size(675, 645);
            pnlRight.TabIndex = 0;
            // 
            // pnlInput
            // 
            pnlInput.Controls.Add(label1);
            pnlInput.Controls.Add(txtInput);
            pnlInput.Controls.Add(btnSend);
            pnlInput.Controls.Add(btnCancel);
            pnlInput.Controls.Add(lblStatus);
            pnlInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlInput.Location = new System.Drawing.Point(0, 466);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new System.Windows.Forms.Padding(6);
            pnlInput.Size = new System.Drawing.Size(675, 179);
            pnlInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(79, 15);
            label1.TabIndex = 4;
            label1.Text = "Chat Window";
            // 
            // txtInput
            // 
            txtInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtInput.Location = new System.Drawing.Point(6, 28);
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            txtInput.Size = new System.Drawing.Size(660, 130);
            txtInput.TabIndex = 0;
            txtInput.Text = "";
            txtInput.KeyDown += TxtInput_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSend.Location = new System.Drawing.Point(991, 6);
            btnSend.Name = "btnSend";
            btnSend.Size = new System.Drawing.Size(80, 36);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.Click += BtnSend_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Enabled = false;
            btnCancel.Location = new System.Drawing.Point(991, 48);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(80, 36);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblStatus.ForeColor = System.Drawing.Color.Gray;
            lblStatus.Location = new System.Drawing.Point(6, 161);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(38, 13);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Ready";
            // 
            // rtbChat
            // 
            rtbChat.BackColor = System.Drawing.Color.White;
            rtbChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            rtbChat.Dock = System.Windows.Forms.DockStyle.Fill;
            rtbChat.Font = new System.Drawing.Font("Segoe UI", 10F);
            rtbChat.Location = new System.Drawing.Point(0, 0);
            rtbChat.Name = "rtbChat";
            rtbChat.ReadOnly = true;
            rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            rtbChat.Size = new System.Drawing.Size(675, 645);
            rtbChat.TabIndex = 1;
            rtbChat.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(899, 645);
            Controls.Add(splitMain);
            MinimumSize = new System.Drawing.Size(700, 500);
            Name = "MainForm";
            Text = "AI Chat Explorer";
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblSystemPrompt;
        private System.Windows.Forms.RichTextBox txtSystemPrompt;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTokens;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button BtnApiSettings;
        private System.Windows.Forms.Label label1;
    }
}
