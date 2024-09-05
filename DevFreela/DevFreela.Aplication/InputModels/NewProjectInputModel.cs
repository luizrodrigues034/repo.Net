namespace DevFreela.Aplication.InputModels
{
    public class NewProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { set; get; }
        public int OwnedId { set; get; }
        public int FreelanceId { get; set; }

    }
}