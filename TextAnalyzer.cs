using System;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            // Part 1: Word Frequencies
            Console.WriteLine("\nWord frequencies:");
            PrintWordFrequencies(input);

            // Part 2: Random Sentences
            Console.WriteLine("\nInput a number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Random sentences:");
            GenerateRandomSentences(n, input);

            // Part 3: Longest and Shortest Words
            Console.WriteLine("\nLongest and Shortest Words:");
            FindLongestAndShortestWords(input);

            // Part 4: Word Search
            Console.WriteLine("\nEnter the word you want to find:");
            string wordToFind = Console.ReadLine();
            int count = CountWordOccurrences(input, wordToFind);
            Console.WriteLine($"{wordToFind} appears {count} time(s)");

            // Part 5: Palindrome Words
            Console.WriteLine("\nPalindrome(s):");
            PrintPalindromes(input);

            // Part 6: Vowel and Consonant Count
            Console.WriteLine("\nNumber of vowels and consonants:");
            CountVowelsAndConsonants(input);
        }

        // Part 1: Word Frequencies
        static void PrintWordFrequencies(string input)
        {
            // Split the input string into an array of words
            string[] words = input.Split(' ');

            Console.WriteLine("Word frequencies:");

            for (int i = 0; i < words.Length; i++)
            {
                int count = 0;

                // Check if the current word has been counted before
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

                // Count the occurrences of the current word in the remaining words
                for (int j = i; j < words.Length; j++)
                {
                    if (words[i] == words[j])
                    {
                        count++;
                    }
                }

                Console.WriteLine($"{words[i]}: {count}");
            }
        }

        // Part 2: Random Sentences
        static void GenerateRandomSentences(int n, string input)
        {
            // Split the input string into an array of words
            string[] sArray = input.Split(' ');
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                string randomSentence = "";
                for (int j = 0; j < 5; j++)
                {
                    // Generate a random index to select a word from the array
                    int randomGenerate = random.Next(sArray.Length);
                    string word = sArray[randomGenerate];
                    randomSentence = randomSentence + word + " ";
                }
                Console.WriteLine(randomSentence);
            }
        }

        // Part 3: Longest and Shortest Words
        static void FindLongestAndShortestWords(string input)
        {
            // Split the input string into an array of words
            string[] words = input.Split(' ');

            // Initialize the longest and shortest words with the first word in the array
            string longest = words[0];
            string shortest = words[0];

            for (int i = 1; i < words.Length; i++)
            {
                // Compare the length of the current word with the longest and shortest words found so far
                if (words[i].Length > longest.Length)
                    longest = words[i];

                if (words[i].Length < shortest.Length)
                    shortest = words[i];
            }

            Console.WriteLine("Longest: " + longest);
            Console.WriteLine("Shortest: " + shortest);
        }

        // Part 4: Word Search
        static int CountWordOccurrences(string sentence, string word)
        {
            // Split the sentence into an array of words
            string[] sentenceArray = sentence.Split(' ');

            int count = 0;

            for (int i = 0; i < sentenceArray.Length; i++)
            {
                // Check if the current word in the array matches the target word
                if (sentenceArray[i] == word)
                    count++;
            }

            return count;
        }

        // Part 5: Palindrome Words
        static void PrintPalindromes(string input)
        {
            // Split the input string into an array of words
            string[] words = input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                // Check if the current word is a palindrome
                if (IsPalindrome(words[i]))
                    Console.WriteLine(words[i]);
                else
                {
                    Console.WriteLine("No Palindrome!");
                }
            }
        }

        static bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                // Compare the characters from both ends of the word
                if (word[left] != word[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        // Part 6: Vowel and Consonant Count
        static void CountVowelsAndConsonants(string sentence)
        {
            int vowel = 0, consonant = 0;
            Console.Write("\n");
            int i = 0;
            while (i < sentence.Length)
                {
                    // Check if the current character is a vowel (lowercase or uppercase)
                    if (sentence[i] == 'a' || sentence[i] == 'e' || sentence[i] == 'i' || sentence[i] == 'o' || sentence[i] == 'u' || sentence[i] == 'A' || sentence[i] == 'E' || sentence[i] == 'I' || sentence[i] == 'O' || sentence[i] == 'U')
                    {
                        vowel++;
                    }
                    // Check if the current character is a consonant (lowercase or uppercase)
                    else if ((sentence[i] >= 'a' && sentence[i] <= 'z') || (sentence[i] >= 'A' && sentence[i] <= 'Z'))
                    {
                        consonant++;
                    }

                    i++;
                }
            Console.WriteLine("Number of vowels: " + vowel);
            Console.WriteLine("Number of consonants: " + consonant);
            Console.ReadKey();
        }
    }
}
