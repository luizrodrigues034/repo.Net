class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite um sequencia de numeros");
        var numerosText = Console.ReadLine();
        var numeros = numerosText.Split();

        var i = 0;

        while(i < numeros.Length)
        {
            Console.WriteLine(numeros[i]);
            i++;
        }
        
    }
}