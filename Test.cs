using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test13_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = "xxxoxoox";
            string[] words = S.Split();
            string final = "";
            for (int i = 0; i < words.Length; i++)
            {
                int countX = 0;
                int countO = 0;
                for(int j = 1;j < words.Length; j++)
                {
                    if (words[j]=="x")
                    {
                        countX++;

                    }
                    else if (words[j] == "o")
                    {
                        countO++;
                    }
                    
                }
                if (countX == 3)
                {
                    final = "X";
                }
                else if (countO == 3)
                {
                    final = "O";
                }
                else if (countX<=2 && countO <= 2) 
                {
                    final = "tie";
                }
            }
            Console.WriteLine(final);
            Console.ReadKey();
        }
    }
}
