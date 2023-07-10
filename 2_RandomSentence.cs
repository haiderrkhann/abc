using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Input a number: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a sentence: ");
            string s = Console.ReadLine();
            string[] sArray = s.Split(' ');
            Random random = new Random();
            Console.WriteLine("random sentences: ");
            Console.WriteLine("\n");
            for(int i=0;i<n;i++)
            {
                string randomSentence = "";
                for (int j=0; j<5;j++)
                {
                    int randomGenerate = random.Next(sArray.Length);
                    string words = sArray[randomGenerate];
                    randomSentence = randomSentence+ words + " ";
                }
                Console.WriteLine(randomSentence+ " ");
            }
            Console.ReadKey();
        }
    }
}
