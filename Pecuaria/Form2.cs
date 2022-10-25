using Newtonsoft.Json;
using Pecuaria.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace Pecuaria
{
    public partial class Form2 : Form
    {

        public static List<CompraGadoItem> compraGadoItemsList;
        public List<Pecuarista> pecuaristas = new List<Pecuarista>();

        public Form2()
        {
            InitializeComponent();
            compraGadoItemsList = new List<CompraGadoItem>();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            pecuarista_combobox.DropDownClosed += DvgCompraGadoItem_Click;

            // GET All Pecuaristas and cache it.
            string URI_Get_Pecuarista = Services.Services.API_URL + Services.Services.PECUARISTA_GETAll_Route;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI_Get_Pecuarista))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        pecuaristas = JsonConvert.DeserializeObject<Pecuarista[]>(json).ToList();
                        List<string> pecuaristaNomes = new List<string>();
                        for (int i = 0; i < pecuaristas.Count; i++)
                        {
                            pecuaristaNomes.Add(pecuaristas[i].NomePecuarista);
                        }
                        pecuarista_combobox.DataSource = pecuaristaNomes;
                    }
                    else
                    {
                        MessageBox.Show($"Não foi possivel fazer a requisição de obter todos pecuaristas, por favor tente novamente!" +
                        "\nErro: " + response.StatusCode);
                    }
                }
            }

            LoadAllData();
        }

        private void DvgCompraGadoItem_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form1()));
            T.Start();
        }

        private async void btn_addAnimal_Click(object sender, EventArgs e)
        {

            // GET Pecuarista
            string nomePecuarista = pecuarista_combobox.SelectedValue.ToString();
            Pecuarista pecuarista = new Pecuarista();

            string URI_GET = Services.Services.API_URL + Services.Services.PECUARISTA_GETAll_Route;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI_GET))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string json = await response.Content.ReadAsStringAsync();
                        List<Pecuarista> pecuaristas = JsonConvert.DeserializeObject<Pecuarista[]>(json).ToList();
                        pecuarista = pecuaristas.FirstOrDefault(p => p.NomePecuarista == nomePecuarista);

                    }
                    else
                    {
                        MessageBox.Show($"Não foi possivel fazer a requisição do pecuarista por nome!" +
    "\nErro: " + response.StatusCode);
                    }
                }
            }

            int idPecuarista = 0;
            if (pecuarista == null) idPecuarista = 0;
            else idPecuarista = pecuarista.Id;
            CompraGado compraGado = new CompraGado()
            {
                Id = 0,
                DataEntrega = dateTime_picker.Value,
                IdPecuarista = idPecuarista,
                Pecuarista = pecuarista
            };

            // POST CompraGado
            string URI_POST_CompraGado = Services.Services.API_URL + Services.Services.COMPRAGADO_POST_Route;
            using (HttpClient client = new HttpClient())
            {
                var serializedData = JsonConvert.SerializeObject(compraGado);
                var content = new StringContent(serializedData, Encoding.UTF8, "application/json");
                using (HttpResponseMessage response = await client.PostAsync(URI_POST_CompraGado, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        CompraGado compraGadoResponse = JsonConvert.DeserializeObject<CompraGado>(responseContent);
                        compraGado.Id = compraGadoResponse.Id;
                    }
                    else
                    {
                        MessageBox.Show($"Não foi possivel fazer o cadastro do compra gado, por favor tente novamente!" +
                                        "\nErro: " + response.StatusCode);
                    }
                }
            }

            // Create the CompraGadoItem Model to pass forward.
            CompraGadoItem compraGadoItem = new CompraGadoItem()
            {
                Id = 0,
                IdCompraGado = compraGado.Id,
                CompraGado = compraGado,
                IdAnimal = 0,
                Animal = null,
                Quantidade = 0
            };
            compraGadoItemsList.Add(compraGadoItem);

            this.Close();
            Thread T = new Thread(() => Application.Run(new Form3()));
            T.Start();
        }

        private void btnCadastrarP_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form4()));
            T.Start();
        }

        private async void LoadAllData()
        {
            dvgCompraGadoItem.DataSource = null;
            dateTime_picker.Value = DateTime.Today;

            // GET the selected pecuarista
            Pecuarista selectedPecuarista = pecuaristas.Where(p => p.NomePecuarista == pecuarista_combobox.SelectedValue.ToString()).FirstOrDefault();

            // GET CompraGado
            string URI_Get_CompraGado = Services.Services.API_URL + Services.Services.COMPRAGADO_GETAll_Route;
            List<CompraGado> getAllCompraGado = new List<CompraGado>();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI_Get_CompraGado))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        getAllCompraGado = JsonConvert.DeserializeObject<CompraGado[]>(json).ToList();
                    }
                }
            }

            // GET the 'CompraGado' from the selected pecuarista
            List<CompraGado> selectedCompraGado = getAllCompraGado.Where(p => p.IdPecuarista == selectedPecuarista.Id).ToList();

            // GET CompraGadoItem
            string URI_Get_CompraGadoItem = Services.Services.API_URL + Services.Services.COMPRAGADOITEM_GETAll_Route;
            List<CompraGadoItem> getAllCompraGadoItem = new List<CompraGadoItem>();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI_Get_CompraGadoItem))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        getAllCompraGadoItem = JsonConvert.DeserializeObject<CompraGadoItem[]>(json).ToList();
                    }
                }
            }


            // GET the 'CompraGadoItem' related to the selected 'CompraGado'.
            List<CompraGadoItem> selectedCompraGadoItemList = new List<CompraGadoItem>();

            foreach (CompraGado compraGado in selectedCompraGado)
            {
                foreach (CompraGadoItem compraGadoItem in getAllCompraGadoItem)
                {
                    if (compraGado.Id == compraGadoItem.IdCompraGado)
                    {
                        selectedCompraGadoItemList.Add(compraGadoItem);
                    }
                }
            }

            // Get all animals Ids from 'selectedCompraGadoItemList'
            string URI_Get_Animal = Services.Services.API_URL + Services.Services.ANIMAL_GETAll_Route;
            List<Animal> selectedAnimalsList = new List<Animal>();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI_Get_Animal))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        selectedAnimalsList = JsonConvert.DeserializeObject<Animal[]>(json).ToList();
                    }
                }
            }

            List<AnimalCompraGadoItemOutput> animalCompraGadoItemOutput = new List<AnimalCompraGadoItemOutput>();
            foreach (CompraGadoItem compraGadoItem in selectedCompraGadoItemList)
            {
                foreach (Animal animal in selectedAnimalsList)
                {
                    if (compraGadoItem.IdAnimal == animal.Id)
                    {
                        decimal valorTotal = compraGadoItem.Quantidade * animal.Preco;
                        animalCompraGadoItemOutput.Add(new AnimalCompraGadoItemOutput()
                        {
                            NomeAnimal = animal.NomeAnimal,
                            Quantidade = compraGadoItem.Quantidade,
                            Preco = animal.Preco,
                            ValorTotal = valorTotal,
                        });
                    }
                }
            }

            // Populate the GridView with the selectedCompraGado data.
            dvgCompraGadoItem.DataSource = animalCompraGadoItemOutput;
        }
    }
}
