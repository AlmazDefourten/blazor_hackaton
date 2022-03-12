using Blazor_kai.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blazor_kai.Controllers
{
    public class HomeController
    {
        [HttpPost]
        public void Registration(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                user.Password = HashPassword.GetPasswordHash(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public bool Login(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                user.Password = HashPassword.GetPasswordHash(user.Password);
                foreach (var us in db.Users.ToList())
                {
                    if (us.eMail == user.eMail && us.Password == user.Password)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public IEnumerable<User> List()
        {
            using (ApplicationContext db = new ApplicationContext ())
            {
                return db.Users.ToList();
            }
        }
    }
}