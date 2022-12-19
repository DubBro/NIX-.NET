using System;
using System.Globalization;

namespace NIX_HW_Practice1
{
    internal class Program
    {
        private const string Numbers = "0123456789";
        private const string Symbols = "!@#$%;:?.,'`\"\\|/<>[]{}()";

        private static void Main(string[] args)
        {
            Console.Write("Enter the text: ");
            string text = Console.ReadLine();

            // Deleting numbers and reversing odd words
            text = DeleteNumbers(text);
            text = ReverseOddWords(text);
            Console.WriteLine("1) " + text);

            // Changing first characters of each word to the upper case
            text = ToTitle(text);
            Console.WriteLine("2) " + text);

            // Replacing letters
            text = ReplaceLetters(text);
            Console.WriteLine("3) " + text);

            Console.ReadKey();
        }

        // Funtion that deletes numbers from the text
        private static string DeleteNumbers(string text)
        {
            // Deleting numbers from the text
            foreach (var number in Numbers)
            {
                text = text.Replace(number.ToString(), string.Empty);
            }

            string[] words = text.Split(' ');

            // Deleting empty words from the text
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == string.Empty)
                {
                    for (int j = i; j < words.Length - 1; j++)
                    {
                        words[j] = words[j + 1];
                    }

                    Array.Resize(ref words, words.Length - 1);
                }
            }

            text = string.Join(" ", words);
            return text;
        }

        // Funtion that reverses odd words
        private static string ReverseOddWords(string text)
        {
            char tmpFirstSymbol = '\0';
            char tmpLastSymbol = '\0';

            string[] words = text.Split(' ');

            // Reversing odd words
            // If the word starts or ends with a symbol, this symbol won't be reversed
            // For example, the word "#brother" after reversing will look like "#rehtorb"
            // Or the word "friday!" after reversing will look like "yadirf!"
            // Or the word "sometimes," after reversing will look like "semitemos,"
            // However, if the word contains the symbol, it will reverse
            // For example, the word "sund@y" after reversing will look like "y@dnus"
            for (int i = 0; i < words.Length; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }

                string word = words[i];

                // Detecting special symbols in the word and putting them to the temporary buffer
                foreach (var symbol in Symbols)
                {
                    if (word.Contains(symbol.ToString()))
                    {
                        if (word.StartsWith(symbol.ToString()))
                        {
                            tmpFirstSymbol = symbol;

                            word = word.Replace(symbol.ToString(), string.Empty);
                        }
                        else if (word.EndsWith(symbol.ToString()))
                        {
                            tmpLastSymbol = symbol;

                            word = word.Replace(symbol.ToString(), string.Empty);
                        }
                    }
                }

                // Reversing
                char[] chars = word.ToCharArray();
                Array.Reverse(chars);
                word = new string(chars);

                // Adding the special symbol to the beginning of the word
                if (tmpFirstSymbol != '\0')
                {
                    word = tmpFirstSymbol + word;
                    tmpFirstSymbol = '\0';
                }

                // Adding the special symbol to the end of the word
                if (tmpLastSymbol != '\0')
                {
                    word = word + tmpLastSymbol;
                    tmpLastSymbol = '\0';
                }

                words[i] = word;
            }

            text = string.Join(" ", words);
            return text;
        }

        // Function that turns the text into the lower case and changes first characters of each word to the upper case
        private static string ToTitle(string text)
        {
            var textInfo = new CultureInfo("en-EN").TextInfo;

            // Changing text to the lower case
            text = textInfo.ToLower(text);

            // Changing first letter of each word to the upper case
            text = textInfo.ToTitleCase(text);

            return text;
        }

        // Function that replaces some letters in the word with other letters
        private static string ReplaceLetters(string text)
        {
            char tmpFirstSymbol = '\0';
            char tmpLastSymbol = '\0';

            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                // Detecting special symbols in the word and putting them to the temporary buffer
                foreach (var symbol in Symbols)
                {
                    if (word.Contains(symbol.ToString()))
                    {
                        if (word.StartsWith(symbol.ToString()))
                        {
                            tmpFirstSymbol = symbol;

                            word = word.Replace(symbol.ToString(), string.Empty);
                        }
                        else if (word.EndsWith(symbol.ToString()))
                        {
                            tmpLastSymbol = symbol;

                            word = word.Replace(symbol.ToString(), string.Empty);
                        }
                    }
                }

                char[] chars = word.ToCharArray();

                // If word starts with 'P' or 'p', this symbol will replace with 'S'
                if (chars[0] == 'P' || chars[0] == 'p')
                {
                    chars[0] = 'S';
                    word = new string(chars);
                }

                // If word ends with 'N' or 'n', this symbol will replace with 'O'
                if (chars[chars.Length - 1] == 'N' || chars[chars.Length - 1] == 'n')
                {
                    chars[chars.Length - 1] = 'O';
                    word = new string(chars);
                }

                // Adding the special symbol to the beginning of the word
                if (tmpFirstSymbol != '\0')
                {
                    word = tmpFirstSymbol + word;
                    tmpFirstSymbol = '\0';
                }

                // Adding the special symbol to the end of the word
                if (tmpLastSymbol != '\0')
                {
                    word = word + tmpLastSymbol;
                    tmpLastSymbol = '\0';
                }

                words[i] = word;
            }

            text = string.Join(" ", words);
            return text;
        }
    }
}
