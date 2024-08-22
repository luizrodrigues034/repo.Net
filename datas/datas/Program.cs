using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite os numeros:");
        var numerosDigitados = Console.ReadLine();
        var listaNumeros = numerosDigitados.Split(' ');

        foreach(var numero in listaNumeros)
        {
            var listNubemrsInt = Convert.ToInt32(numero);
            var dobro = listNubemrsInt * 2;
        }
    }
}