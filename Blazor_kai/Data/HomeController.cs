using Blazor_kai.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
                User newUser = GetUser(user.Id);
                db.Historye.Add(new History { Record = newUser.Status, UserId = newUser.Id, Time = DateTime.Now });
                db.SaveChanges();
            }
        }

        public User GetUser(string email)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                foreach(var us in db.Users)
                {
                    if (email == us.eMail)
                    {
                        return us;
                    }
                }
                return null;
            }
        }

        public User GetUser(int Id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var us in db.Users)
                {
                    if (Id == us.Id)
                    {
                        return us;
                    }
                }
                return null;
            }
        }

        [HttpPost]
        public void Edit(User user)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> usrs = db.Users.AsNoTracking().ToList();
                db.Users.Update(user);
                string findUserStatus = "";
                foreach (var us in usrs)
                {
                    if (user.Id == us.Id)
                    {
                        findUserStatus = us.Status;
                    }
                }
                if (findUserStatus != user.Status)
                {
                    db.Historye.Add(new History { Record = user.Status, UserId = user.Id, Time = DateTime.Now });
                }
                
                db.SaveChanges();
            }
        }

        public List<History> GetHistory(User user)
        {
            List<History> ret = new List<History>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach(History his in db.Historye)
                {
                    if (his.UserId == user.Id)
                        ret.Add(his);
                }
                return ret;
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

        public List<User> List()
        {
            using (ApplicationContext db = new ApplicationContext ())
            {
                return db.Users.ToList();
            }
        }
    }
}