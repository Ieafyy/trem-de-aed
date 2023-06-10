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

namespace TrabalhoAED.Telas
{
    public partial class CadastroUser : Form
    {
        public CadastroUser()
        {
            InitializeComponent();
        }

        private string json;
        private Dictionary<string, string> usuarios;

        private void CadastroUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            json = File.ReadAllText(@"../../Dados/funcionarios.json");
            usuarios = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            if(this.user.Text != "" && this.senha.Text != "") 
            { 

                if(usuarios != null)
                { 
                    foreach (KeyValuePair<string, string> usuario in usuarios)
                    {
                        if (this.user.Text == usuario.Key)
                        {
                            this.resultado.ForeColor = Color.Red;
                            this.resultado.Visible = true;
                            this.resultado.Text = "Já possui cadastro! Clique aqui para remover";
                            return;
                        }
                    }

                    usuarios.Add(this.user.Text, this.senha.Text);

                }

                else
                {
                    usuarios = new Dictionary<string, string>();
                    usuarios.Add(this.user.Text, this.senha.Text);
                }

                this.resultado.Visible = true;
                this.resultado.ForeColor = Color.Green;
                this.resultado.Text = "Cadastrado com sucesso!";

                string jsonString = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
                File.WriteAllText(@"../../Dados/funcionarios.json", jsonString);
            }

            else
            {
                this.resultado.Visible = true;
                this.resultado.ForeColor = Color.Red;
                this.resultado.Text = "Campos vazios!";
            }

        }

        private void resultado_Click(object sender, EventArgs e)
        {
            if(this.resultado.Text == "Já possui cadastro! Clique aqui para remover")
            {
                foreach(KeyValuePair<string, string> usuario in usuarios)
                {
                    if (this.user.Text == usuario.Key && this.senha.Text == usuario.Value)
                    {
                        usuarios.Remove(usuario.Key);
                        this.resultado.ForeColor = Color.Green;
                        this.resultado.Text = "Usuário removido!";
                        string jsonString = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
                        File.WriteAllText(@"../../Dados/funcionarios.json", jsonString);
                        return;
                    }
                }
                
                this.resultado.Text = "Senha incorreta";

            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gerenciador form1 = new Gerenciador();
            form1.Show();
        }
    }
}
