using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string:");
        string s = Console.ReadLine();
        string[] words = s.Split(' ');
        Console.WriteLine("\n");
        Console.WriteLine("Word frequencies:");
        for (int i = 0; i < words.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < i; j++)
            {
                if (words[i] == words[j])
                {
                    count++;
                    break;
                }
            }

            if (count > 0)
                continue;
            for (int j = i; j < words.Length; j++)
            {
                if (words[i] == words[j])
                {
                    count++;
                }
            }
            Console.WriteLine($"{words[i]}: {count}");
            Console.ReadKey();
        }
    }
}
