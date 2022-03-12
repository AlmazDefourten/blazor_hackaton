using Blazor_kai.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blazor_kai.Data
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


        [HttpGet]
        public bool Login(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var us in db.Users.ToList())
                {
                    if (HashPassword.IsPasswordsEquals(us.Password, user.Password))
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