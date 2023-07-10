using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelConsonant
{
    class Program
    {
        static void Main(string[] args)
        {
            int vowel = 0, consonant = 0;
            Console.WriteLine("Enter a sentence: ");
            string sentence = Console.ReadLine();
            Console.Write("\n");
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == 'a' || sentence[i] == 'e' || sentence[i] == 'i' || sentence[i] == 'o' || sentence[i] == 'u' || sentence[i] == 'A' || sentence[i] == 'E' || sentence[i] == 'I' || sentence[i] == 'O' || sentence[i] == 'U')
                {
                    vowel++;
                }
                else if ((sentence[i] >= 'a' && sentence[i] <= 'z') || (sentence[i] >= 'A' && sentence[i] <= 'Z'))
                {
                    consonant++;
                }
            }
            Console.WriteLine("Number of vowels: " + vowel);
            Console.WriteLine("Number of consonants: " + consonant);
            Console.ReadKey();
        }
    }
}
