using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadoca.Model
{
    internal class Cliente
    {

        private int id;
        private string nome;
        private string cpf;
        private string telefone;
        private string endereco;
        private int pontos;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public int Pontos { get => pontos; set => pontos = value; }

        public Cliente(int id, string nome, string cpf, string telefone, string endereco, int pontos)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }
        public Cliente(string nome, string cpf, string telefone, string endereco, int pontos)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Pontos = pontos;
        }

        public void AdicionarPontos(int pontos)
        {
            this.Pontos += pontos;
        }

        internal static Cliente? listarPorId(int idCliente)
        {
            throw new NotImplementedException();
        }
    }
}
