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


        public Cliente(int id, string nome, string cpf, string telefone, string endereco, int pontos)
        {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
            this.pontos = pontos;
        }
        public Cliente(string nome, string cpf, string telefone, string endereco, int pontos)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
            this.pontos = pontos;
        }

        public void AdicionarPontos(int pontos)
        {
            this.pontos += pontos;
        }

        //kjoijghtyhhjgy
    }
}
