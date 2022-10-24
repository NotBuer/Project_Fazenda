using Newtonsoft.Json;
using Pecuaria.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

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
            string URI = Services.Services.API_URL + Services.Services.ANIMAL_GETAll_Route;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Animal[] animal = JsonConvert.DeserializeObject<Animal[]>(json);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel fazer a requisição de obter todos animais, por favor tente novamente!");
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form1()));
            T.Start();
        }

        private void btn_addAnimal_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form3()));
            T.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
