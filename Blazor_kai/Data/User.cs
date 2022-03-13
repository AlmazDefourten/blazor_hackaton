namespace Blazor_kai.Data
{
    public class User
    {
        public User(string name, string status, string email)
        {
            Name = name;
            Status = status;
            eMail = email;
        }

        public User()
        {

        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; } = "sofinder";
        public string? Progress { get; set; } = "sofinder";
        public string? eMail { get; set; }

        public string? Info { get; set; }

        public string? Vacansion { get; set; }

        public string? Password { get; set; }
    }
}
