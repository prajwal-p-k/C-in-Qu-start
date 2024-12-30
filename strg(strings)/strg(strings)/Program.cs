using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace strg_strings_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Start: //any name is insed od strat
            //    string location = "Mysore";
            //    Console.WriteLine("enter the your name");
            //    string name = Console.ReadLine();
            //    if (name.Trim().Length < 3) //it will remove white space at both side
            //    {
            //        Console.WriteLine("the character is less than 3");
            //        goto Start;
            //    }
            //    Console.WriteLine("---------------------------------------");

            //    Console.WriteLine("the location length " + name.Length);
            //    Console.WriteLine("---------------------------------------");
            //    Console.WriteLine(name.ToUpper());
            //    Console.WriteLine("---------------------------------------");


            //part 2

            //string name = "    prajwal   ";
            //Console.WriteLine("actual string "+name+"p K");
            //Console.WriteLine("actual string with right trim " + name.TrimStart() + "p K");
            //Console.WriteLine("actual string with left trim " + name.TrimEnd() + "p K");
            //Console.WriteLine("actual string both side " + name.Trim() + "p K");
            //Console.ReadLine();

            //part 3

            //Console.WriteLine("12.21".PadLeft(15)); //padding is added extra space to given string rigth are left
            //Console.WriteLine("102.34".PadLeft(15));
            //Console.WriteLine("123456.0".PadRight(15));
            //Console.WriteLine("1234567898765.0".PadLeft(15));
            //Console.WriteLine("1234.0".PadLeft(15));
            //Console.WriteLine("-----------------------------------------------------------------");

            //Console.WriteLine("Name  " .PadRight(16)+ ": prajwal");
            //Console.WriteLine("email  ".PadRight(16) + ": prajwalpkgmail.com");
            //Console.WriteLine("Qualification  ".PadRight(16) + ": BE");
            //Console.WriteLine("number  ".PadRight(16) + ": 9109022525");


            //part 4

            //string pwd = "Mysore";
            ////string conf = "mysore";
            //string conf = null;

            //if (pwd != conf)
            //{
            //    Console.WriteLine("password does not mach");
            //    Console.ReadLine();
            //    return;
            //}
            //Console.WriteLine("account created");
            //Console.WriteLine("--------------------------");
            //Console.ReadLine();

            //part 5


            //string pwd = "Mysore";
            //string conf = "MYSORE";
            ////string conf = null;

            //if (pwd.Equals( conf)) //if first compere is not  null its an error  eg.pwd=null error ,if conf=null its ok
            //{
            //    Console.WriteLine("account created");
            //    Console.ReadLine();
            //    return;
            //}
            //Console.WriteLine("password does not mach");
            //Console.WriteLine("--------------------------");
            //Console.ReadLine();


            //part 6


            //string pwd = "Mysore";
            //string conf = "Mysore";
            ////string conf = null;

            //if ((pwd.CompareTo(conf))==0) //it will return  0,1,-1  both are equal 0 if its not eqaul 1 or -1
            //                              //and pwd is not be null
            //{
            //    Console.WriteLine("account created");
            //    Console.ReadLine();

            //}
            //else
            //{

            //    Console.WriteLine(" not account created");
            //    Console.ReadLine();


            //}
            //Console.WriteLine("password does not mach");
            //Console.WriteLine("--------------------------");
            //Console.ReadLine();


            //part 7

            //string pwd = "Mysore";
            //string conf = "MYSORE";

            ////string conf = null;

            //if ((String.Compare(pwd,conf,true)) == 0) //it will return  0,1,-1  both are equal 0 if its not eqaul 1 or -1 
            //                                //and pwd is not be null 
            //                                //true will used to ignore the case
            //{
            //    Console.WriteLine("account created");
            //    Console.ReadLine();

            //}
            //else
            //{

            //    Console.WriteLine(" not account created");
            //    Console.ReadLine();


            //}
            //Console.WriteLine("password does not mach");
            //Console.WriteLine("--------------------------");
            //Console.ReadLine();


            //part 7

            //string data = "Mysore is beautifull city";
            //Console.WriteLine(data);
            //Console.WriteLine("------------------------------------------------------------------------------");
            //for (int  i = data.Length;i>0; i--)
            //{
            //    Console.WriteLine(data.Remove(i-1,data.Length-i));
            //}
            ////Console.WriteLine("------------------------------------------------------------------------------");
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Console.WriteLine(data.Remove(i-1,data.Length-i));
            //}
            //Console.WriteLine("------------------------------------------------------------------------------");
            //Console.WriteLine(data.Remove(7,14)); //remove 14 character from 7th index
            //Console.WriteLine(data.Remove(7)); //remove  from 7th index to till end
            //Console.WriteLine(data);

            //Console.ReadLine();


            //part 8



            //string data = "Mysore is beautifull city";
            //Console.WriteLine(data);

            //Console.WriteLine(data.Substring(7,14)); //returns 14 character starting from 7th index
            //Console.WriteLine(data.Substring(7)); //returns  starting from 7th index to till end
            //Console.WriteLine(data);

            //Console.ReadLine();


            //part 9


            //reverse a number

            //Console.WriteLine("enter your name");
            //string data = Console.ReadLine();
            //string rev = "";
            //for (int i = data.Length; i > 0; i--)
            //{
            //    rev += data.Substring(i-1,1);
            //}
            //Console.WriteLine(rev);


            //part 10

            //Console.WriteLine("enter your first name: ");
            //string  a=Console.ReadLine();
            //string name=a.Substring(0,1).ToUpper()+a.Substring(1).ToLower();  //this called tital character
            //Console.WriteLine(name);



            //part  11


            //string info = "alone in the filed yon solitary reaper reaping and singing a meloncholy;strain";
            //char[] sep = { ' ', ',', '.', ';', '!' }; //array of sapareters
            //string[] words=info.Split(sep);
            //Console.WriteLine("no of words are : "+words.Length);

            //foreach (string word in words)
            //{
            //    Console.WriteLine(word);
            //}
            //Console.ReadLine();


            //part 12

            //string info = "your children are not your childern they come from you they dont belong to you you can house their bodies not their souls";
            //string[] words = info.Split(' ');
            //string res = "";
            //for (int i = 0; i < words.Length; i++)
            //{
            //    res += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower() + " ";
            //}
            //Console.WriteLine(res.Trim());
            //Console.ReadLine();


            string info = "Your children are  not your children they come from you they dont belong to you you can house thier bodies not their soul";

            //string[] chars = info.Split(' ');
            //Hashtable hashtable = new Hashtable();

            //HashSet<string> names = new HashSet<string>();

            //foreach (string s in chars)

            //{

            //    if (names.Add(s))

            //    {

            //        Console.Write(s+' ');

            //    }

            //}


            //count occurance

            //foreach (string c in chars)
            //{
            //    int i = 1;


            //    try
            //    {
            //        hashtable.Add(c, i);
            //    }
            //    catch
            //    {
            //        hashtable[c]=i+1;

            //    }
            //}
            //foreach (DictionaryEntry c in hashtable)
            //{
            //    Console.WriteLine(c.Key+" : "+c.Value);
            //}


            //part 13

            //Console.WriteLine(info.Replace("children","child"));
            //string[] nameList = { "manoj", "rahul", "krishna", "darshan", "hima" };
            //Console.WriteLine( string.Join(" ", nameList)); //it used to join the list are any think


            //part 14

            //string x = "";
            //string y = " ";
            //string z = null;
            //Console.WriteLine(String.IsNullOrEmpty(x));
            //Console.WriteLine(String.IsNullOrEmpty(y));
            //Console.WriteLine(String.IsNullOrEmpty(z));

            //Console.WriteLine("--------------------------------------------------------");

            //Console.WriteLine(String.IsNullOrWhiteSpace(x));
            //Console.WriteLine(String.IsNullOrWhiteSpace(y));
            //Console.WriteLine(String.IsNullOrWhiteSpace(z));

            //Console.WriteLine("--------------------------------------------------------");

            //Console.WriteLine( info.IndexOf("abc",25,7));//25 is start index and till next 7 character
            //Console.WriteLine(info.LastIndexOf("a"));


            //part 15

            Console.WriteLine("enter the gmail");
            string a=Console.ReadLine();
            try
            {
                int b = a.IndexOf("@", 1);
                int d=a.LastIndexOf("@");
                int c = a.IndexOf(".", b+5);
                
                if (c != -1 && b != -1 && b==d )
                {
                    Console.WriteLine("valid email");
                    
                }
                else
                {
                    Console.WriteLine(" not valid email");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("invaild email");
            }
            
            





            Console.ReadLine();
      
        }

    }
}
