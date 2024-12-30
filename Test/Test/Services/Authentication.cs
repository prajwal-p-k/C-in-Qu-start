using Test.Data;
using Test.Models;

namespace Test.Services
{
    public class Authentication
    {
        int userid;
        string username;
        ApplicationDbContext context;
        public Authentication(ApplicationDbContext _context)
        {
            context = _context;
        }
        public int User
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
            }
        }
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public bool IsUserValid(string email, string pwd)
        {
            User emp = context.Users.Where(e => e.Email == email && e.PWD == pwd).FirstOrDefault();
            if (emp != null)
            {
                userid = emp.Id;
                UserName = emp.Name;
                return true;
            }
            return false;
        }
    }
}
