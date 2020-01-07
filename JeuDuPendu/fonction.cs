using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                //Compare the uppercase of user input and all letter of the word to guess
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

            //Verify if the letter was already tried
            // If yes, user don't loose life
            for (int i = 0; i < charWrongLetter.Length -1; i++)
            {
              if (charWrongLetter[i] == userInput)
              {
                getWrong = false;
              }
            }

            //Store the wrong letter
            if (getWrong)
            {
              charWrongLetter[life-1] = userInput;
            }
            

            //Print all wrong letter tried
            Console.Write("\nWrong letters : ");
            for (int i = charWrongLetter.Length-1; i > 0; i--)
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

        public static string ChoisirMot(int max)
        {
            Random rnd = new Random();
            long index = rnd.Next(0, max);

            string[] mot = File.ReadAllLines("liste_francais.txt");

          /*
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
          */

            return mot[index-1];
        }

        public static void EndMessage (int life)
        {
            Console.Clear();
            if (!(life != 0))
            {
                Console.WriteLine("You loose dumb ass");
                ShowHangMan(0);
            }
            else
            {
                Console.Write("\nCongrats !");
                }
        }


        public static int CountLines(string fileName)
        {
            char[] buffer = new char[32 * 1024]; //lit 32K char à chaque fois
            System.IO.TextReader reader;
            int total = 1; //tout fichier contient au moins une ligne
            int read;
            if (System.IO.File.Exists(fileName))
            {
                reader = System.IO.File.OpenText(fileName);
                while ((read=reader.Read(buffer, 0, buffer.Length)) > 0)
              {
                  for (int i = 0; i < read; i++)
                    {
                        if (buffer[i] == '\n')
                        {
                            total++;
                        }
                    }
                 }
                //nettoyage des variables
                reader.Close();
                reader.Dispose();
                reader = null;
            }
            return total;
        }

        public static void ShowHangMan(int i)
        {
            string [] hangMan = new string [11];

            hangMan[10] = "\n"
                        +"\n"
                        +"\n"
                        +"\n"
                        +"\n"
                        +"\n"
                        +"\n";

            hangMan[9] = "\n"
                        +"\n"
                        +"\n"
                        +"\n"
                        +"\n"
                        +"\n"
                        +"__/\\__";

            hangMan[8] = "  /\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[7] = "  /----\\\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[6] = "  /----\\\n"
                        +"  |    |\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[5] = "  /----\\\n"
                        +"  |    |\n"
                        +"  |    o\n"
                        +"  |\n"
                        +"  |\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[4] = "  /----\\\n"
                        +"  |    |\n"
                        +"  |    o\n"
                        +"  |    |\n"
                        +"  |\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[3] = "  /----\\\n"
                        +"  |    |\n"
                        +"  |    o\n"
                        +"  |   -|-\n"
                        +"  |\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[2] = "  /----\\\n"
                        +"  |    |\n"
                        +"  |    o\n"
                        +"  |   -|-\n"
                        +"  |   / \\\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[1] = "  /----\\\n"
                        +"  |    |     Derniere chance,\n"
                        +"  |    o\n"
                        +"  |   -|-     Apres c'est finit\n"
                        +"  |   / \\\n"
                        +"  |\n"
                        +"__/\\__";

            hangMan[0] = "  /---\\       _                               \n"
                        +"  |    |     | |                              \n"
                        +"  |    o     | |     ___   ___  ___  ___ _ __ \n"
                        +"  |   -|-    | |    / _ \\ / _ \\/ __|/ _ \\ '__|\n"
                        +"  |   / \\    | |___| (_) | (_) \\__ \\  __/ |   \n"
                        +"  |          \\_____/\\___/ \\___/|___/\\___|_|    \n"
                        +"__/\\__";

            Console.WriteLine(hangMan[i]);
        }
    
    }
}