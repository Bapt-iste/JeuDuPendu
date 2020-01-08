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
                int nbLine = Fonction.CountLines("liste_francais.txt");
                string strWordToGuess = Fonction.ChoisirMot(nbLine);
                char[] charWordToGuess = new char[strWordToGuess.Length];
                char[] charWordGuessed = new char[strWordToGuess.Length];
                char[] charWrongLetter = new char[26];
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

                for (int i = 0; i < 26; i++)
                {
                    charWrongLetter[i] = (char)32;
                }

                //Init userInput for the first loop
                userInput = (char)32;
                Fonction.TestCharactere(charWordToGuess, charWordGuessed, userInput, charWrongLetter, life);

                while (!Fonction.TestGagne(charWordGuessed, charWordToGuess) && life != 0)
                {
                    Console.WriteLine();
                    Fonction.ShowHangMan(life);
                    userInput = Fonction.GetCharactere();
                    Console.WriteLine("\n");

                    getWrong = Fonction.TestCharactere(charWordToGuess, charWordGuessed, userInput, charWrongLetter, life);

                    if (getWrong)
                    {
                        life -= 1;
                    }

                    Console.Write("\n{0} chance left.", life);
                }
                Fonction.EndMessage(life);
                Console.WriteLine("\nThe word was \"{0}\"", strWordToGuess);
                keepPlaying = Fonction.KeepPlaying();

            }
        }
    }
}