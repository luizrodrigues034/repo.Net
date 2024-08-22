using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Estudante : Pessoa
    {
        public Estudante(string turma, float nota, DateTime dataNascimento, string nome, string documento) : base(nome, documento, dataNascimento) { 
        
            Turma = turma;
            Nota = nota;
        }
        public string Turma {  get; set; }
        public float Nota { get; set; }
        
        public override void SeApresentar()
        {
            base.SeApresentar();
            Console.WriteLine($"Ola sou estudande, minha nota eh:,");
        }
    }
}
