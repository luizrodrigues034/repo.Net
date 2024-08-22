using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public abstract class Pessoa
    {
        public Pessoa(string nome, string documento, DateTime dataNascimento)
        {
            Nome = nome;
            Documento = documento;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; protected set; }
        public string Documento { get; protected set; }
        public DateTime DataNascimento { get; protected set; }

        public virtual void SeApresentar()
        {
            Console.WriteLine($"Meu nome eh:{Nome}, meu documento eh: {Documento}, e nasci em {DataNascimento}");
        }
    }
}
