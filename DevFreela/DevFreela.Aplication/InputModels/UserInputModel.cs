using DevFreela.Aplication.ViewModel;
using DevFreela.Core.Entities;

namespace DevFreela.Aplication.InputModels
{
    public class UserInputModel
    {
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public DateTime BirthDay { get;  set; }
        public DateTime CreatedAt { get; set; }

    }
}