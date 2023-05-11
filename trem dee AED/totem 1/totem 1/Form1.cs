using System.Diagnostics;
using System.IO;

namespace totem_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int id = 0;
        public Dictionary<int, long> dic = new Dictionary<int, long>();

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value < 100) this.progressBar1.Value += 1;
            if (this.progressBar1.Value > 1 && this.progressBar1.Value < 50) this.label1.Text = "GERANDO...";
            else if (this.progressBar1.Value >= 50 && this.progressBar1.Value < 99) this.label1.Text = "IMPRIMINDO...";
            if (this.progressBar1.Value == 51)
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python";
                start.Arguments = string.Format(@"../../cupom.py {0}", this.id);
                Debug.WriteLine(string.Format(@"../../cupom.py {0}", this.id));
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                using (Process process = Process.Start(start))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    Debug.WriteLine($"Erro: {error}");
                }
            }
            else if (this.progressBar1.Value == 100)
            {
                this.label1.Text = $"PRONTO! ID = {this.id}";
                StreamWriter write = new StreamWriter(@"../../cache.txt");

                DateTime agora = DateTime.Now;
                long dataEHora = long.Parse(agora.ToString("yyyyMMddHHmmss"));
                dic.Add(id, dataEHora);
                write.WriteLine(this.id);
                foreach (KeyValuePair<int, long> item in dic) write.WriteLine($"{item.Key};{item.Value}");

                write.Close();

                this.progressBar1.Value = 0;
                this.timer1.Enabled = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(@"../../cache.txt");
            this.id = int.Parse(read.ReadLine()) + 1;
            string linha;
            int error = 0;
            while ((linha = read.ReadLine()) != null)
            {
                string[] valores = linha.Split(';');
                try
                {
                    dic.Add(int.Parse(valores[0]), long.Parse(valores[1]));
                }
                catch(Exception){
                    error += 1;
                }
            }
            this.timer1.Enabled = true;
            read.Close();
        }
    }
}