using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace user_define_exception
{
    internal class InvalidSlotException:ApplicationException
    {
        public string Message
        {
            get
            {
                return " This is not your scheduled time ; contact the local administrator";
            }
        }
        public void Reason()
        {
            Console.WriteLine("Exam is schedule in two slots");
            Console.WriteLine("Odd reg nos are schedlued in the moring");
            Console.WriteLine("even reg nos are scheduled at noon");
        }
    }
}
