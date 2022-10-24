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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnCadastrarP_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread T = new Thread(() => Application.Run(new Form2()));
            T.Start();
        }
    }
}
