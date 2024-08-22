class Program
{
    static void Main(string[] args)
    {
        var numero = "sete";
        string valorNull = null;
        var typeLong = long.MaxValue.ToString();

        try
        {
            var formatException = int.Parse(numero);
            var argumentNullException = int.Parse(valorNull);
            var overFlowException = int.Parse(typeLong);
        }
        catch (FormatException exception)
        {
            Console.WriteLine($"Ocorreu um Format Exeception: {exception.Message}");
        }
        catch (OverflowException exception)
        {
            Console.WriteLine($"Ocorreu um OverFlow Exception: {exception.Message}");
        }
        catch (ArgumentNullException exception) {
            Console.WriteLine($"Ocorreu um Argument Null Exceotion: {exception.Message}");
        }
    }
}