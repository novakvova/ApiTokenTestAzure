using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAppClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> p= new Dictionary<string, string>();
            var url = "https://aspnet27.azurewebsites.net/Token";
            p.Add("username", txtEmail.Text);
            p.Add("password", txtPassword.Text);
            p.Add("grant_type", "password");

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders
                //    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = 
                    client.PostAsync(url, new FormUrlEncodedContent(p)).Result;
                var tokne = response.Content.ReadAsStringAsync().Result;
            }

            //Get response as expected
            //HttpClient client = new HttpClient();
            //string jsonObject = JsonConvert.SerializeObject(new
            //{
            //    Email = txtEmail.Text,
            //    Password = txtPassword.Text
            //});
            //string url = @"https://aspnet27.azurewebsites.net/api/Account/Register";
            //var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
            //var result = client.PostAsync(url, content).Result;
            //client.DefaultRequestHeaders
        }
    }
}
