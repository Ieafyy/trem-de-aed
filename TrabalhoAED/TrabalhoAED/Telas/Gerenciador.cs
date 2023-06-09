﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoAED.Telas;


namespace TrabalhoAED
{
    public partial class Gerenciador : Form
    {
        public Gerenciador()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroUser formulario1 = new CadastroUser();
            formulario1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Saida formulario0 = new Saida();
            formulario0.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GeradorTicket formulario2 = new GeradorTicket();
            formulario2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            EfetuarPagamento formulario3 = new EfetuarPagamento();
            formulario3.Show();
        }
    }
}
