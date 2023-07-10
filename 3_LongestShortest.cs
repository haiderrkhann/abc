using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSmallest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string wordarray = Console.ReadLine();
            string[] word = wordarray.Split(' ');

            int min = word[0].Length;
            int max = word[0].Length;
            string largest = word[0];
            string smallest = word[0];
            for (int i = 1; i <= word.Length - 1; i++)
            {
                int length = word[i].Length;
                if (length > max)
                {
                    largest = word[i];
                    max = length;
                }
                if (length < min)
                {
                    smallest = word[i];
                    min = length;
                }
            }
            Console.WriteLine("Longest:   " + largest);
            Console.WriteLine("Shortest:   " + smallest);
            Console.ReadKey();
        }
    }
}
