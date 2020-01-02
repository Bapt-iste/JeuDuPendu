using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> mots = new List<string>();
            Console.WriteLine("Choisissez un mot :");
            string wordToGuessTmp = Console.ReadLine();
            char[] wordToGuess = new char[wordToGuessTmp.Length];
            char[] wordGuessed = new char[wordToGuessTmp.Length];
            char userInput;
            Console.Clear();

            for (int i = 0; i < wordToGuessTmp.Length; i++)
            {
                wordToGuess[i] = wordToGuessTmp[i];
                wordGuessed[i] = (char)35;
            }

            while (!(wordToGuess.Equals(wordGuessed)))
            {
                Console.WriteLine("\n*********************");
                Console.WriteLine("Choisissez une lettre : ");
                userInput = Convert.ToChar(Console.ReadLine());
                Console.Write("Ton mot : ");
                for(int i = 0; i < wordToGuessTmp.Length; i++)
                {
                    if (wordToGuess[i].Equals(userInput))
                    {
                        wordGuessed[i] = userInput;
                    }
                    else
                    {
                        
                    }
                    Console.Write(wordGuessed[i]);
                }

                

            }

        }
    }
}
