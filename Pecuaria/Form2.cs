using Newtonsoft.Json;
using Pecuaria.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Pecuaria
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            // Populate Pecuarista ComboBox
            string URI = Services.Services.API_URL + Services.Services.PECUARISTA_GETAll_Route;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Pecuarista> pecuaristas = JsonConvert.DeserializeObject<Pecuarista[]>(json).ToList();
                        List<string> pecuaristaNomes = new List<string>();
                        for (int i = 0; i < pecuaristas.Count; i++)
                        {
                            pecuaristaNomes.Add(pecuaristas[i].NomePecuarista);
                        }
                        pecuarista_combobox.DataSource = pecuaristaNomes;
                        object test = pecuarista_combobox.SelectedValue;
                    }
                    else
                    {
                        MessageBox.Show($"Não foi possivel fazer a requisição de obter todos pecuaristas, por favor tente novamente!" +
                        "\nErro: " + response.StatusCode);
                    }
                }
            }

            //string URI = Services.Services.API_URL + Services.Services.ANIMAL_GETAll_Route;
            //using (HttpClient client = new HttpClient())
            //{
            //using (HttpResponseMessage response = await client.GetAsync(URI))
            //{
            //if (response.IsSuccessStatusCode)
            //{
            //string json = await response.Content.ReadAsStringAsync();
            //dgvAnimais.DataSource = JsonConvert.DeserializeObject<Animal[]>(json).ToList();
            //}
            //else
            //{
            //MessageBox.Show($"Não foi possivel fazer a requisição de obter todos animais, por favor tente novamente!" +
            //"\nErro: " + response.StatusCode);
            //}
            //}
            //}
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form1()));
            T.Start();
        }

        private void btn_addAnimal_Click(object sender, EventArgs e)
        {



            CompraGado compraGado = new CompraGado()
            {
                Id = 0,
                // TODO:
            };

            Thread T = new Thread(() => Application.Run(new Form3()));
            T.Start();
        }

        private void btnCadastrarP_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form4()));
            T.Start();
        }
    }
}
