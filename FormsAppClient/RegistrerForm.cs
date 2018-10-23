using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppClient
{
    public partial class RegistrerForm : Form
    {
        public RegistrerForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string jsonObject = JsonConvert.SerializeObject(new
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text
            });
            string url = @"https://aspnet27.azurewebsites.net/api/Account/Register";
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).Result;
            //client.DefaultRequestHeaders
        }
    }
}
