using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void btnCadastrarAnimal_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form1()));
            T.Start();
        }
    }
}
