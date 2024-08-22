using System;

class Program
{
    static void Main(string[] args)
    {
        int notaAluno = 10;
        string notaAlunoString = "10";
        string notaAlunoString2 = "10a";

        double notaAlunoDouble = notaAluno;

        int notaAlunoInt = (int)notaAlunoDouble;

        int notaAlunoInt2 = Convert.ToInt32(notaAlunoDouble);
        int notaAlunoInt3 = Convert.ToInt32(notaAlunoString);
        var test = Convert.ToDouble(notaAlunoInt3);

        Console.WriteLine(notaAlunoInt3);
        
        int notaAlunoInt4 = int.Parse(notaAlunoString);
        if (int.TryParse(notaAlunoString2, out int notaAlunoParse)){

        } else {
            Console.WriteLine("Conversao mal sucedida");
        }
    }
}