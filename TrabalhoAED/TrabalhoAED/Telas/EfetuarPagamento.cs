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

namespace TrabalhoAED.Telas
{
    public partial class EfetuarPagamento : Form
    {

        class DataItem
        {
            public int id { get; set; }
            public DateTime data { get; set; }

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

        private void button1_Click(object sender, EventArgs e)
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
                Console.WriteLine ($"Id: {item.id} data: {item.data}");
            }

            Boolean achou = false;
            int posicao = -1;

            for (int i=0; i < lista.Count(); i++)
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

            if (achou)
            {
                lista.RemoveAt(posicao);
            }
           
            foreach (var item in lista)
            {
                Console.WriteLine($"Id: {item.id} data: {item.data}");
            }
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
    }
}
