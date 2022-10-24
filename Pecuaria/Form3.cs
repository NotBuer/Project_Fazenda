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
                NomeAnimal = txt_animalName.Text,
                Preco = decimal.Parse(txt_animalPrice.Text), // TODO: Numbers-only field, needs validation against other characters.
            };

            using (HttpClient client = new HttpClient())
            {
                var serializedAnimal = JsonConvert.SerializeObject(animal);
                var content = new StringContent(serializedAnimal, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }

            this.Close();
            Thread T = new Thread(() => Application.Run(new Form1()));
            T.Start();
        }
    }
}
