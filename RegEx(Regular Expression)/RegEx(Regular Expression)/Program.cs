using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;
using System.Collections;  //it is built in libaray function

namespace RegEx_Regular_Expression_
{
    internal class Program
    {


        static void Main(string[] args)
        {
            //Console.WriteLine("enter the mobile number");
            //string a=Console.ReadLine();
            //Regex r = new Regex("^[6789]{1}[0-9]{9}$");
            //if (r.IsMatch(a))
            //{
            //    Console.WriteLine("your enter the mobile number is correct");
            //} else {
            //    Console.WriteLine("your enter the mobile number is not correct");
            //}


            //Console.WriteLine("enter the email id");
            //string a = Console.ReadLine();
            //Regex r = new Regex("^[a-z]{1}\\w+@\\w+\\.[a-z]{3}$");
            //or
            //Regex r = new Regex(@"^[a-z]{1}\w+@\w+\.[a-z]{3}$"); //this is called varbatims
            //or
            // Regex r = new Regex(@"^[a-z]{1}\w+(\.\w+)*@\w+\.([a-z]{3})|([a-z]{2}\.[a-z]{2})$");
            //if (r.IsMatch(a))
            //{
            //    Console.WriteLine("your enter the gmail is correct");
            //}
            //else
            //{
            //    Console.WriteLine("your enter the gmail is not correct");
            //}

            //write a program to vaildate file path accept only pdf,doc,docs
            //Console.WriteLine("enter the file path");
            //string a = Console.ReadLine();
            ////C:\Users\PrajwalPK\Downloads
            //Regex r = new Regex(@"^[c-z C-Z]{1}:\\(\w+(\s\w+)*\\)*\w+\.((pdf)|(doc)|(docx))$");
            //if (r.IsMatch(a))
            //{
            //    Console.WriteLine("your enter the file path is correct");
            //}
            //else
            //{
            //    Console.WriteLine("your enter the file path is not correct");
            //}


            //string lst = "Ravi Rakesh Kavitha Bharath Hima Harshitha Manoj Indushree Kiran Ramya Chethan Bhavya Mahesh manjunath Meghana Sahana Prajwal Rahul Divya" +
            //    "Chandhana bhuvana ";
            //Regex r =new Regex(@"\w+na\b");
            //MatchCollection c=r.Matches(lst);
            //foreach (Match m in c)
            //{
            //    Console.WriteLine(m + " : " + m.Index);
            //}
            //Console.ReadLine();

            //string agremet = " This agreement is between technovice and qustrat,stating that technovice would provided service to qustrat for a period of 12 month ,this would involve 25 resources each resources to be paid rs 500 per hours";

            //Regex regex = new Regex(@"a"); //there any word with mach can replace
            //Console.WriteLine(regex.Replace(agremet,"xxxx"));
            //Console.ReadLine();



            //Regex regex = new Regex(@"\d+");
            //string[] lst = regex.Split(agremet);
            //foreach (string s in lst)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.ReadLine();


           
            //int sum = 0;
            //foreach (char arg in exp)
            //{
            //    if (char.IsDigit(arg))
            //    {
            //        sum = sumarg;
            //    }
            //    sum = sum + arg;


            //}
            //Console.WriteLine(sum);


            //string expression = "25/5*10+300-700%3";

            //// Split by +, -, *, or %

            //Regex regex = new Regex(@"[+\-*/%]");

            //string[] slNos = new string[expression.Length];



            //string[] lst = regex.Split(expression);

            //Console.WriteLine("Split Parts:");
            //int i = 0;
            //foreach (string part in lst)
            //{
            //    slNos[i] = part;
            //    i++;
            //}



            //string[] slNos1 = new string[expression.Length];
            //string exp = "25/5*10+300-700";
            //Regex regex1 = new Regex(@"\w+\b");

            //int j = 0;
            
            //string[] lst1 = regex1.Split(exp);
            //foreach (string s in lst1)
            //{
            //    slNos1[j]= s;
            //    j++;
               

            //}
            //foreach (string s in slNos)
            //{
            //    Console.WriteLine(s);   
            //}



            //Console.ReadLine();


            string expression = "25/5*10+300-700";

            // Split numbers and operators
            Regex regexNumbers = new Regex(@"[+\-*/%]");
            string[] slNos = regexNumbers.Split(expression);

            Regex regexOperators = new Regex(@"\d+");
            string[] operators = regexOperators.Split(expression);

            // Filter out empty strings from the operators array
            operators = operators.Where(op => !string.IsNullOrEmpty(op)).ToArray();

           
            double result = Convert.ToDouble(slNos[0]); 
            int operatorIndex = 0;

            
            for (int i = 1; i < slNos.Length; i++)
            {
                string op = operators[operatorIndex];
                double nextNumber = Convert.ToDouble(slNos[i]);

                
                switch (op)
                {
                    case "+":
                        result += nextNumber;
                        break;
                    case "-":
                        result -= nextNumber;
                        break;
                    case "*":
                        result *= nextNumber;
                        break;
                    case "/":
                        result /= nextNumber;
                        break;
                    case "%":
                        result %= nextNumber;
                        break;
                }

                operatorIndex++;
            }

            Console.WriteLine("Result: " + result);

        }
    }
}
