using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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
            string json  = File.ReadAllText(@"../../Dados/funcionarios.json");
            Dictionary<string, string> usuarios = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            int erros = 0;  

            if(this.user.Text == "admin" && this.key.Text == "admin")
            {
                this.Hide();
                Gerenciador formulario2 = new Gerenciador();
                formulario2.Show();
                return;
            }

            if(usuarios != null) 
            { 
                foreach(KeyValuePair<string, string> usuario in usuarios)
                {
                    if (this.user.Text == usuario.Key && this.key.Text == usuario.Value)
                    {
                        this.Hide();
                        Gerenciador formulario2 = new Gerenciador();
                        formulario2.Show();
                    }
                    else this.erro.Show();
                }
            }
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
