using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Classes
{
    internal class Dados
    {
        private int id;
        private string nome;
        private string email;
        private string cell;
        private string password;
        
        public Dados(int id,string nome, string email, string cell, string password)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.cell = cell;
            this.password = password;
        }

        public int getId() { return id; }
        public string getNome() {  return nome; }
        public string getEmail() { return email; }
        public string getCell() { return cell; }   
        public string getPassword() { return password; }
        
        public void setId() { id = 0; }
        public void setNome(string nome) {  this.nome = nome; }
        public void setEmail(string email) {  this.email = email; }
        public void setCell(string cell) {  this.cell = cell; }
        public void setPassword(string password) {  this.password = password; }

        public void getAll()
        {
            Console.WriteLine($"id: {id}, nome: {nome}, email: {email}, cell: {cell}, password: {password}");
        }

    }
}
