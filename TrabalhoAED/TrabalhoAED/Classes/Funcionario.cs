using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Classes
{
    internal class Funcionario : Dados
    {
        public Funcionario(int id, string nome, string email, string cell, string password) : base(id, nome, email, cell, password)
        {
        }
    }
}
