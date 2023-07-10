using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string word = Console.ReadLine();
            string[] wordArray = word.Split(' ');
            string reverse = string.Empty;
            for (int i=0; i< wordArray.Length; i++)
            {
                for(int j= wordArray.Length-1-i;j>0;j--)
                {
                    if(wordArray[i] == wordArray[j])
                    {
                    
                    }
                    
                }
                Console.WriteLine("Palindrome(s): " + wordArray[i]);
            }
                Console.ReadKey();
        }
    }
}
