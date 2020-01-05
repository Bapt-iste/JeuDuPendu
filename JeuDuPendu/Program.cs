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
            bool keepPlaying = true;

            while (keepPlaying)
            {
                /*
                 * User select a word to guess.
                 * This word is a string
                 * Then it converted into two array of char,
                 *  one with the word, one empty that will be filled with user input.
                 */
                Console.Clear();
                Console.WriteLine("Choisissez un mot :");
                //string strWordToGuess = Console.ReadLine();
                string strWordToGuess = Fonction.ChoisirMot();
                char[] charWordToGuess = new char[strWordToGuess.Length];
                char[] charWordGuessed = new char[strWordToGuess.Length];
                char userInput;
                int life = 10;
                bool getWrong;

                Console.Clear();

                //Fill charWordGuessed with a correct number of '#'
                for (int i = 0; i < strWordToGuess.Length; i++)
                {
                    charWordToGuess[i] = strWordToGuess[i];
                    charWordGuessed[i] = (char)35;
                }


                //Init userInput for the first loop
                userInput = '#';
                Fonction.TestCaractere(charWordToGuess, charWordGuessed, userInput);

                while (!Fonction.TestGagne(charWordGuessed, charWordToGuess) && life != 0)
                {
                    userInput = Fonction.GetCaractere();
                    Console.WriteLine("\n");

                   getWrong = Fonction.TestCaractere(charWordToGuess, charWordGuessed, userInput);

                    if (getWrong)
                    {
                        life -= 1;
                    }
                    
                    if (life < 2)
                    {
                        Console.Write("\nIl vous reste {0} vie.", life);
                    }
                    else
                    {
                        Console.Write("\nIl vous reste {0} vies.", life);
                    }
                }

                Fonction.EndMessage(life);
                Console.WriteLine("The word was {0}", strWordToGuess); 
                keepPlaying = Fonction.KeepPlaying();

            }
        }
    }
}
