using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence: ");
            string sentence = Console.ReadLine();
            Console.Write("\n");
            string[] sentenceArray = sentence.Split(' ');
            Console.WriteLine("Enter the word you want to find: ");
            string word = Console.ReadLine();
            int count = 1;
            Console.Write("\n");
            for (int i=0; i<sentenceArray.Length;i++)
            {
                if (word==sentenceArray[i])
                {


                    count = count + i;

                }

                
                

            }
            Console.Write(word + " appears " + count+" time(s)");
            Console.ReadKey();
        }
    }
}
