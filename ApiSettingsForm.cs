using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiChat
{
    public partial class ApiSettingsForm : Form
    {
        public string ApiBaseUrl { get; set; }
        public string ApiModelName { get; set; }

        public ApiSettingsForm(string baseUrl, string modelName)
        {
            InitializeComponent();
            ApiBaseUrl = baseUrl;
            ApiModelName = modelName;   
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ApiBaseUrl = txtApiBaseUrl.Text.Trim();
            ApiModelName = txtApiModelName.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtApiBaseUrl.Text = ApiBaseUrl;
            txtApiModelName.Text = ApiModelName;
        }
    }
}
