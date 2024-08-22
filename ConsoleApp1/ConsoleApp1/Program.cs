class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student>();
        {
            students.Add(new Student(1, "Luiz", "2132333123", 100));
            students.Add(new Student(2, "Roberto", "565665546", 35));
            students.Add(new Student(3, "Roberto", "565665546", 60));
            students.Add(new Student(4, "Alfredo", "459438654", 70));
            students.Add(new Student(5, "Joao", "485438790", 35));
        }
        var any = students.Any(s => s.Name == "Luiz");
        Console.WriteLine(any);

        var single = students.Single(s => s.Id == 2);
        var singleOrDefault = students.SingleOrDefault(s => s.Id == 10);

        var first = students.First(s => s.Name == "Roberto");
        var firstOrDefault = students.FirstOrDefault(s => s.Name == "Alfredo");

        var orderedByGrade = students.OrderBy(s => s.Grade);
        var orderedByGradeDescending = students.OrderByDescending(s => s.Grade);
        Console.WriteLine(orderedByGradeDescending);


        var aprovados = students.Where(s => s.Grade >= 70);

        var select = students.Select(s => s.Grade);
        foreach ( var a in aprovados) {  Console.WriteLine(a.Name); }
        var selectMany = students.SelectMany(s => s.PhoneNumbers);
        foreach (string phone in selectMany)
        {

        Console.WriteLine(phone); 
        }
        Console.ReadKey();
    }
        

        
 }

    public class Student
    {
        public Student(int id, string name, string document, int grade)
        {
            Id = id;
            Name = name;
            Document = document;
            Grade = grade;

            PhoneNumbers = new List<string> { "123234554", "3434432442342", "1232233123" };
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public int Grade { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
