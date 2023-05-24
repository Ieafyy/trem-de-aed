using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoAED
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.user.Text == "admin" && this.key.Text == "admin")
            {
                this.Hide();
                Gerenciador formulario2 = new Gerenciador();
                formulario2.Show();
            }
            else
            {
                this.erro.Show();
            }
        }
    }
}
