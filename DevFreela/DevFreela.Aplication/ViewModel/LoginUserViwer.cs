namespace DevFreela.Aplication.ViewModel
{
    public class LoginUserViwer
    {
        public LoginUserViwer(string email, string token)
        {
            Email = email;
            Token = token;
        }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}