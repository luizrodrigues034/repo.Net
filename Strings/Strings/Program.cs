class Program
{
    static void Main(string[] args)
    {
        var paragrafo = "C# e uma linguagem moderna e versatil. " +
            "Com C# consigo desenvolver para Web, DeskTop, Jogos, e Mobile.     ";


        var tamanho = paragrafo.Length;
        var empty = string.Empty;
        var frase = paragrafo.Split('.');
        var remove = paragrafo.Trim();
        var removeStart = paragrafo.TrimStart();
        var removeEnd = paragrafo.TrimEnd();
        var substitui = paragrafo.Replace("C#", "C-SHARP");

        //buscas com C#

        var indexOf = paragrafo.IndexOf("C#"); //-> pega a primeira ocorrencia do caracter
        var lastIndexOf = paragrafo.LastIndexOf("C#", StringComparison.OrdinalIgnoreCase);// pega a ultima occorrencia do caracter
        var startWith = paragrafo.StartsWith("JAVA");// -> Comeca a frase com a palavra escolhida, podendo trocar por variavel
        var subsString = paragrafo.Substring(indexOf, lastIndexOf); //-> esta separando a string em outra string, separando a parte do incio e do fim
        var contains = paragrafo.Contains("jogos", StringComparison.OrdinalIgnoreCase); //verifica se a palavra esta contida na string
        Console.WriteLine("IndexOF:" + indexOf + "\nLast:" + lastIndexOf + "\nStar:" + startWith + " Subs: " + subsString + " Contains: " + contains);
        

        Console.ReadKey();
    }
}