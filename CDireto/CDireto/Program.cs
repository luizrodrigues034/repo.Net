using System;

namespace CDireto
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataDeEntrada = new DateTime(2020, 1, 1);
            DateTime  dataDeHoje = DateTime.Now;
            TimeSpan tempoDeEmpresa = dataDeEntrada - dataDeHoje;
            Console.WriteLine(tempoDeEmpresa);


            int maiorValorInt = int.MaxValue;
            int menorValorInt = int.MinValue;

            double maiorValorDouble = double.MaxValue;
            double menorValorDouble = double.MinValue;

            string nome = "Luiz";
            char letra = 'l';
            
            var dataTeste = new DateTime(2023, 2, 4);


        }
    }
}