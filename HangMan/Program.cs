using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome in HangMan Game!!!");

            string winFolder = "C:/Users/Konrad Witczak/Desktop/Motorola Academy - Recruitment Task/";
            string nameOfWinFile = "winners.txt";
            string fullPathWin = winFolder + nameOfWinFile;
            string nameWinner = null;



            string pathToRead = "C:/Users/Konrad Witczak/Desktop/Motorola Academy - Recruitment Task/countries_and_capitals.txt";
            var dict = File.ReadLines(pathToRead).Select(line => line.Split('|')).ToDictionary(line => line[0], line => line[1]);

            List<string> listCapitals = new List<string>();
            List<string> listCountries = new List<string>();

            listCountries = dict.Keys.ToList();

            listCapitals = dict.Values.ToList();
            int number = -1;
            foreach (var item in listCapitals)
            {
                number++;
            }

            bool newGame = true;
            while (newGame)
            {
                int guessNumber = 0;
                bool win = false;
                Random random = new Random();
                var idx = random.Next(0, number);
                string randomWord = listCapitals[idx];
                string mysteryWord = randomWord.Trim();


                Console.WriteLine(mysteryWord);

                char[] guess = new char[mysteryWord.Length];

                for (int p = 0; p < mysteryWord.Length; p++)
                {
                    int index = mysteryWord.IndexOf(' ');
                    if (p == index)
                        guess[p] = '_';
                    else
                        guess[p] = '*';

                }
                Console.WriteLine(guess);

                bool game = true;
                while (game)
                {
                    int lifePoints = 5;
                    Console.WriteLine("Life Points: " + lifePoints);
                    //bool play = true;

                    List<string> guessGoodList = new List<string>();
                    List<string> guessBadList = new List<string>();
                    while (lifePoints >0)
                    {
                        Console.WriteLine("Would like to guess a letter or whole word(s)? [letter/word] ");
                        guessNumber++;
                        string info = Console.ReadLine();
                        if (info == "word")
                        {
                           
                                Console.WriteLine("Give me a word:");
                                string answer1 = Console.ReadLine();
                                if (mysteryWord == answer1)
                                {
                                    Console.WriteLine("You win!");
                                    Console.WriteLine("What is your name?");
                                 nameWinner = Console.ReadLine();
                                    
                                
                                    win = true;

                                    break;
                                }
                                else
                                {
                                    lifePoints -= 2;
                                    Console.WriteLine("Life Points: " + lifePoints);
                                }
                               
                        }
                        else if (info == "letter")
                        {
                            Console.WriteLine("Give me a letter:");

                                bool goodGuess = false;
                                char playerGuess = char.Parse(Console.ReadLine());
                                for (int j = 0; j < mysteryWord.Length; j++)
                                {

                                    if (playerGuess == mysteryWord[j])
                                    {
                                        guess[j] = playerGuess;

                                        guessGoodList.Add(playerGuess.ToString());

                                        goodGuess = true;
                                        if (guessGoodList.Count == mysteryWord.Length)
                                        {
                                            Console.WriteLine("You win!!!");
                                            Console.WriteLine("What is your name?");
                                             nameWinner = Console.ReadLine();
                                            
                                            win = true;
                                            break;
                                        }
                                    }


                                }
                                if (goodGuess == false)
                                {
                                    lifePoints--;
                                    guessBadList.Add(playerGuess.ToString());
                                    Console.Write("Not in word: ");
                                    foreach (var item in guessBadList)
                                    {
                                        Console.Write(item + ",");
                                    }
                                    Console.WriteLine("\nLife Points: " + lifePoints);
                                }
                                if (win)
                                    break;
                                Console.WriteLine(guess);
                               // play = false;
                           
                        }
                        else
                            Console.WriteLine("Choose on more time. [letter/word]");
                        if (win == true)
                            break;
                    }
                    bool question2 = true;
                    if (win == true)
                        break;
                    else
                    {
                        string country = listCountries[idx];
                        Console.WriteLine("The game is over. Hint: The capital of " + country);
                        Console.WriteLine("Do you want try one more time? [YES/NO]");
                        while (question2)
                        {
                            string answer2 = Console.ReadLine();
                            if (answer2 == "YES")
                            {
                                game = true;
                                question2 = false;
                            }
                            else if (answer2 == "NO")
                            {
                                game = false;
                                question2 = false;
                            }
                            else
                                Console.WriteLine("Choose on more time. [YES/NO]");
                        }
                    }

                }

                using (StreamWriter winFile = File.AppendText(fullPathWin))
                {
                    winFile.WriteLine(nameWinner + " | " + DateTime.Now + " | "+ guessNumber + " | " + mysteryWord);
                }
                

                Console.WriteLine("Do you want start new game? [YES/NO]");
                bool question3 = true;
                while (question3)
                {
                    string answer3 = Console.ReadLine();
                    if (answer3 == "YES")
                    {
                        newGame = true;
                        question3 = false;
                    }
                    else if (answer3 == "NO")
                    {
                        newGame = false;
                        question3 = false;
                    }
                    else
                        Console.WriteLine("Choose on more time. [YES/NO]");
                }

            } 
        }

       
        
    }
}
