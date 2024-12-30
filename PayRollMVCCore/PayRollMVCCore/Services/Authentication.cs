using PayRollMVCCore.Data;
using PayRollMVCCore.Models;

namespace PayRollMVCCore.Services
{
    public class Authentication
    {
        int userid;
        string username;
        ApplicationDBContext context;
        public Authentication(ApplicationDBContext _context)
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
            Employee emp=context.employees.Where(e=>e.Email == email && e.Password==pwd).FirstOrDefault();
            if (emp != null)
            {
                userid=emp.Id;
                UserName = emp.Name;
                return true;
            }
            return false;
        }
    }
}
