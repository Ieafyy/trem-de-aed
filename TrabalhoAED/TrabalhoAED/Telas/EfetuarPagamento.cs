using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoAED.Classes;
using System.Globalization;

namespace TrabalhoAED.Telas
{
    public partial class EfetuarPagamento : Form
    {

        class DataItem
        {
            public int id { get; set; }
            public DateTime data { get; set; }

            public string status { get; set; }

            public DataItem(int id, DateTime timestamp)
            {
                this.id = id;
                data = timestamp;
            }
        }

        public EfetuarPagamento()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gerenciador gerenciador = new Gerenciador();
            gerenciador.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(@"../../Dados/Cache/cache.txt");

            string linha;
            string saida = "";
            DateTime data = DateTime.Now;
            string data_formato = data.ToString("dd/MM/yyyy HH:mm:ss");
            saida += $"{read.ReadLine()}\n";

            while ((linha = read.ReadLine()) != null)
            {
                string[] valores = linha.Split(';');
                
                if (valores[0] != this.ticket.Text && valores[2] == "ABERTO") saida += $"{valores[0]};{valores[1]};ABERTO\n";
                
                else if (valores[0] != this.ticket.Text && valores[2] == "FECHADO") saida += $"{valores[0]};{valores[1]};FECHADO\n";

                else if (valores[0] == this.ticket.Text && valores[2] == "ABERTO")
                {
                    saida += $"{valores[0]};{valores[1]};FECHADO\n";
                    this.saida.Text = "PAGO COM SUCESSO!";
                }

                else if (valores[0] == this.ticket.Text && valores[2] == "FECHADO")
                {
                    saida += $"{valores[0]};{valores[1]};FECHADO\n";
                    this.saida.Text = "JÁ ESTÁ PAGO!";
                }
            }

            
            read.Close();
            Console.WriteLine(saida);
            StreamWriter write = new StreamWriter(@"../../Dados/Cache/cache.txt");
            write.Write(saida);
            write.Close();
        }

        private void ticket_TextChanged(object sender, EventArgs e)
        {
            String ticket = this.ticket.Text;

            bool sucesso = int.TryParse(ticket, out int ticketInt);
            if (sucesso)
            {
                Console.WriteLine(ticketInt); // Saída: 456
            }
            else
            {
                Console.WriteLine("A conversão falhou.");
            }


            string path = @"../../Dados/Cache/cache.txt";

            List<DataItem> lista = new List<DataItem>();

            try
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        int id = int.Parse(parts[0]);
                        DateTime timestamp = DateTime.ParseExact(parts[1], "yyyyMMddHHmmss", null);
                        lista.Add(new DataItem(id, timestamp));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
            }

            foreach (var item in lista)
            {
                Console.WriteLine($"Id: {item.id} data: {item.data}");
            }

            Boolean achou = false;
            int posicao = -1;

            for (int i = 0; i < lista.Count(); i++)
            {
                Console.WriteLine($"Buceta de lista: {lista[i].id}");


                if (ticketInt.Equals(lista[i].id))
                {
                    achou = true;
                    posicao = i;
                    break;
                }
            }

            Console.WriteLine($"{achou} aki {posicao}");


            StreamReader read = new StreamReader(@"../../Dados/Cache/cache.txt");

            string linha;
            int ok = 0;
            DateTime data = DateTime.Now;
            string data_formato = data.ToString("dd/MM/yyyy HH:mm:ss");
            bool nao_achou = true;
            bool fechado = false;

            read.ReadLine();

            while ((linha = read.ReadLine()) != null)
            {
                string[] valores = linha.Split(';');
                if (valores[0] != this.ticket.Text) ok += 1;

                else
                {
                    nao_achou = false;

                    if (valores[2] == "FECHADO") fechado = true;

                    DateTime pData = DateTime.ParseExact(valores[1], "yyyyMMddHHmmss", null);
                    string data_formato_entrada = pData.ToString("dd/MM/yyyy HH:mm:ss");

                    DateTime data_entrada = DateTime.ParseExact(data_formato_entrada, "dd/MM/yyyy HH:mm:ss", null);
                    DateTime data_saida = DateTime.ParseExact(data_formato, "dd/MM/yyyy HH:mm:ss", null);

                    TimeSpan diferenca = data_saida - data_entrada;
                    double minutos = diferenca.TotalMinutes;

                    this.saida.Visible = true;
                    //pra mudar o valor altere a formula com o multiplicador de 0.2
                    this.saida.Text = $"Horario de entrada: {data_formato_entrada}\nHorario de saida:{data_formato}\nTempo de estadia:{minutos} minutos\nValor a ser cobrado:{(0.2 * minutos).ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}\nStatus:{valores[2]}";
                }
            }

            if (nao_achou)
            {
                this.saida.Visible = true;
                this.saida.Text = "ID NÃO ENCONTRADO!";
                this.button3.Enabled = false;
            }

            else if (fechado) this.button3.Enabled = false;
            
            else this.button3.Enabled = true;

            read.Close();
        }
    }
}
