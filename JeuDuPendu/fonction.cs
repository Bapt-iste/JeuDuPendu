using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDuPendu
{
    class Fonction
    {
        public static bool TestGagne(char[] input1, char[] input2)
        {
            bool isEqual = true;
            for (int i = 0; i < input1.Length; i++)
            {
                if (Char.ToUpper(input1[i]) != Char.ToUpper(input2[i]))
                {
                    isEqual = false;
                }
                
            }

            return isEqual;
        }

        public static bool TestCharactere(char[] charWordToGuess, char[] charWordGuessed, char userInput, char[] charWrongLetter, int life)
        {
            bool getWrong = true;

            Console.Clear();

            Console.Write("Word to guess : ");

            for (int i = 0; i < charWordToGuess.Length; i++)
            {
                if (Char.ToUpper(charWordToGuess[i]).Equals(Char.ToUpper(userInput)))
                {
                  charWordGuessed[i] = userInput;
                  getWrong = false;
                }
                else
                {
                  
                }

                Console.Write(charWordGuessed[i]);

            }

            if (getWrong)
            {
              charWrongLetter[life-1] = userInput;
            }

            Console.Write("\nWrong letters : ");

            for (int i = 9; i > 0; i--)
            {
                Console.Write(charWrongLetter[i]);
            }

            return getWrong;
        }

        public static bool KeepPlaying()
        {
            char userInput;
            bool keepPlaying = true;
            Console.WriteLine("KeepPlaying? [y/N]\n");

            do
            {
                userInput = Console.ReadKey().KeyChar;

                if (Char.ToUpper(userInput) == 'N')
                {
                    keepPlaying = false;
                }
            } while (Char.ToUpper(userInput) != 'Y' && Char.ToUpper(userInput) != 'N');

            return keepPlaying;
        }

        public static char GetCharactere()
        {
            Console.WriteLine("\nSubmit a letter : ");
            char userInput = Console.ReadKey().KeyChar;
            return userInput;
        }

        public static string ChoisirMot()
        {
            Random rnd = new Random();

            List<string> mots = new List<string>();
            mots.Add("un");
            mots.Add("deux");
            mots.Add("cinq");
            mots.Add("rouge");
            mots.Add("membre");
            mots.Add("conseil");
            mots.Add("donner");
            mots.Add("reponse");
            mots.Add("etat");
            mots.Add("son");
            mots.Add("armement");
            mots.Add("peu");
            mots.Add("apres");
            mots.Add("vacances");
            mots.Add("annonce");
            mots.Add("mercredi");
            mots.Add("evident");
            mots.Add("regime");
            mots.Add("affirmer");
            mots.Add("arme");

            return mots[rnd.Next(0,19)];
        }

        public static void EndMessage (int life)
        {
            Console.Clear();
            if (!(life != 0))
            {
                Console.WriteLine("You loose dumb ass");
            }
            else
            {
                Console.Write("\nCongrats !");
                }
        }
    
    }
}