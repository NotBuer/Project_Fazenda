using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Pecuaria.Models;

namespace Pecuaria
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private async void btnCadastrarP_Click(object sender, EventArgs e)
        {
            string URI_POST = Services.Services.API_URL + Services.Services.PECUARISTA_POST_Route;

            bool pecuaristaJaExiste = false;
            string nomePecuarista = txtNomeP.Text;
            Pecuarista pecuarista = new Pecuarista()
            {
                Id = 0,
                NomePecuarista = nomePecuarista,
                CompraGados = null,
            };

            using (HttpClient client = new HttpClient())
            {

                // First check against all pecuaristas entries if no one have the same name.
                string URI_GET = Services.Services.API_URL + Services.Services.PECUARISTA_GETAll_Route;
                using (HttpResponseMessage response = await client.GetAsync(URI_GET))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Pecuarista> pecuaristas = JsonConvert.DeserializeObject<Pecuarista[]>(json).ToList();
                        pecuaristaJaExiste = pecuaristas.Where(p => p.NomePecuarista == nomePecuarista).Any();

                        if (pecuaristaJaExiste)
                        {
                            MessageBox.Show($"Um pecuarista com esse nome já existe, por favor tente outro nome!");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Não foi possivel fazer a requisição de obter todos pecuaristas!" +
                            "\nErro: " + response.StatusCode);
                    }
                }

                // If no pecuarista found with the same name, then can create a new one.
                if (!pecuaristaJaExiste)
                {
                    var serializedData = JsonConvert.SerializeObject(pecuarista);
                    var content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.PostAsync(URI_POST, content))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Não foi possivel fazer o cadastro do pecuarista, por favor tente novamente!" +
        "\nErro: " + response.StatusCode);
                        }
                    }
                }

            }

            this.Close();
            Thread T = new Thread(() => Application.Run(new Form1()));
            T.Start();
        }
    }
}
