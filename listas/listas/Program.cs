class Progam
{
    static void Main(string[] args)
    {
        var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var numbersCopy = new int[10];
        for (int i = 0; i < numbers.Length; i++) {
            numbersCopy[i] = numbers[i];
            Console.WriteLine(numbersCopy[i]);
        }
        var numbersString = "0 1 2 3 4 5 6 7 8 9";
        var numbersSplit = numbersString.Split(' ');
        var numbersCopyString = Array.ConvertAll(numbersSplit, Convert.ToInt32);
        foreach (int numero in numbersCopyString) {
            Console.WriteLine(numero);
        }

        var list = new List<int>{0, 1, 2, 3, 4};
        var listNumbers = new List<int>(numbers);

        list.Add(5);
        list.AddRange(new List<int> { 6, 7 });

        var quantidadeElementos = list.Count();
        var contem = list.Contains(11);
        var contem2 = list.Contains(5);

        Console.WriteLine("Revertendo");
        list.Reverse();
        list.ForEach(l => Console.WriteLine(l));

        Console.WriteLine(" Ordenando:");
        list.Sort();
        list.ForEach(l => Console.WriteLine(l));

        Console.WriteLine("Removendo:");
        list.Remove(2);
        list.RemoveAll(l => l > 3);
        list.ForEach(l => Console.WriteLine(l));
        Console.ReadKey();
    }
}