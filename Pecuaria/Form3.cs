using Newtonsoft.Json;
using Pecuaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pecuaria
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private async void btnCadastrarAnimal_Click(object sender, EventArgs e)
        {
            string URI = Services.Services.API_URL + Services.Services.ANIMAL_POST_Route;

            Animal animal = new Animal
            {
                Id = 0,
                NomeAnimal = txt_animalName.Text,
                Preco = decimal.Parse(txt_animalPrice.Text), // TODO: Numbers-only field, needs validation against other characters.
            };

            using (HttpClient client = new HttpClient())
            {
                var serializedAnimal = JsonConvert.SerializeObject(animal);
                var content = new StringContent(serializedAnimal, Encoding.UTF8, "application/json");
                using(HttpResponseMessage responseMessage = await client.PostAsync(URI, content))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseContent = await responseMessage.Content.ReadAsStringAsync();
                        Animal animalResponse = JsonConvert.DeserializeObject<Animal>(responseContent);
                        animal.Id = animalResponse.Id;
                    }
                }
            }   

            // Retrieve CompraGadoItem
            CompraGadoItem compraGadoItemDataTemp = Form2.compraGadoItemsList.Last();
            CompraGadoItem compraGadoItem = new CompraGadoItem()
            {
                Id = compraGadoItemDataTemp.Id,
                IdCompraGado = compraGadoItemDataTemp.IdCompraGado,
                //CompraGado = compraGadoItemDataTemp.CompraGado,
                IdAnimal = animal.Id,
                //Animal = animal,
                Quantidade = compraGadoItemDataTemp.Quantidade
            };

            // POST CompraGadoItem
            string URI_POST_CompraGadoItem = Services.Services.API_URL + Services.Services.COMPRAGADOITEM_POST_Route;
            using (HttpClient client = new HttpClient())
            {
                var serializedData = JsonConvert.SerializeObject(compraGadoItem);
                var content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync(URI_POST_CompraGadoItem, content))
                {
                    string test = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Não foi possivel fazer o cadastro do 'CompraGadoItem.Model', por favor tente novamente!" +
                                        "\nErro: " + response.StatusCode);
                    }
                }
            }

            this.Close();
            Thread T = new Thread(() => Application.Run(new Form2()));
            T.Start();
        }
    }
}
