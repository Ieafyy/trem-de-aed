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

namespace TrabalhoAED.Telas
{
    public partial class Saida : Form
    {
        public Saida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string id = this.input.Text;

            StreamReader read = new StreamReader(@"../../Dados/Cache/cache.txt");

            string linha;
            string saida = "";
            saida += $"{read.ReadLine()}\n";

            while ((linha = read.ReadLine()) != null)
            {
                string[] valores = linha.Split(';');

                if (id != valores[0]) saida += $"{linha}\n";
                
            }


            this.status.ForeColor = Color.Goldenrod;
            this.status.Text = "OK! VOLTE SEMPRE!";

            read.Close();
            Console.WriteLine(saida);
            StreamWriter write = new StreamWriter(@"../../Dados/Cache/cache.txt");
            write.Write(saida);
            write.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gerenciador gerenciador = new Gerenciador();
            gerenciador.Show();
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            string id = this.input.Text;
            bool nao_encontrado = true;

            StreamReader read = new StreamReader(@"../../Dados/Cache/cache.txt");

            string linha;
            read.ReadLine();

            while ((linha = read.ReadLine()) != null)
            {
                string[] valores = linha.Split(';');
                if (valores[0] == id && valores[2] == "FECHADO")
                {
                    this.status.ForeColor = Color.Green;
                    this.status.Text = "JÁ ESTÁ PAGO! CONFIRME A SAIDA";
                    this.status.Visible = true;
                    this.button1.Enabled = true;
                    nao_encontrado = false;
                }

                else if (valores[0] == id && valores[2] == "ABERTO")
                {
                    this.status.ForeColor = Color.Red;
                    this.status.Text = "PAGUE O TICKET ANTES DE SAIR!";
                    this.status.Visible = true;
                    this.button1.Enabled = false;
                    nao_encontrado = false;
                }
            }

            if (nao_encontrado)
            {
                this.status.ForeColor = Color.Black;
                this.status.Text = "ID NÃO ENCONTRADO!";
                this.status.Visible = true;
                this.button1.Enabled = false;
            }

            read.Close();

        }
    }
}
