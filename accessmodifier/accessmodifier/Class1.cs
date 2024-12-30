using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accessmodifier
{

     public   class Department //to asseccss out side assemebly it should be public
    {
        //internal protected void ListDepartment()
        //internal void ListDepartment() //this is for internal
        // protected internal void ListDepartment() //the protected internal same as internal assembly and outside assembley we can acess througth intheritence but not througth with object/instence
        public void ListDepartment()  //public member can access with in the accessmbley and outside the assemebly througth an inheritence and also througth an object
                                      

        {
            Console.WriteLine("admin");
            Console.WriteLine("account");
            Console.WriteLine("sales");
            Console.WriteLine("production");
            Console.WriteLine("hr");
        }
        void Getinfo()
        {
            ListDepartment();
        }


    }
}
