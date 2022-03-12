namespace kai_hack.Models
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
        public string Name { get; set; }
        public string Status { get; set; }

        public string eMail { get; set; }
    }
}
