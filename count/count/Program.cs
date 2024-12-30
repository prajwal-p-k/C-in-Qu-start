using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count
{
    internal class Program
    {
        static int WordCount(string s)
        {
            int wordCount = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (Char.IsWhiteSpace(s[i]) && !Char.IsWhiteSpace(s[i + 1]) && i > 0)
                    wordCount++;
            }
            return ++wordCount;  // Add one for the last word (if any)
        }

        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            string line = Console.ReadLine();

            // Collecting lines until an empty line is entered
            while (!string.IsNullOrEmpty(line))
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            // Calculate and display word count for each line
            int totalWordCount = 0;
            int sent = 0;
            foreach (string l in lines)
            {
                int count = WordCount(l);
                Console.WriteLine($"Line: \"{l}\" - Word count: {count}");
                totalWordCount += count;
                sent += 1;
            }

            Console.WriteLine($"Total word count: {totalWordCount}");
            Console.WriteLine("the total number of sentence is :"+sent);
        }
    }
}

