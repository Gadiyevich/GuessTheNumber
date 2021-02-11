using System;
using System.Collections.Generic;
using System.Text;

namespace GuessTheNumber
{


    public enum GuessingPlayer
    {
        Human,
        Mashine
    }

    class GuessNumberGame
    {
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayer GuessingPlayer;

        public GuessNumberGame(int max = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.GuessingPlayer = guessingPlayer;
        }


        public void Start()
        {
            if (GuessingPlayer == GuessingPlayer.Human)
            {
                HumanGuesses();
            }

            else
            {
                MashineGuesses();
            }
        }

        private void MashineGuesses()
        {
            try
            {
                Console.WriteLine("Enter a number within 0-100 that is going to be guessed by computer.");
                int guessedNumber = -1;
                while (guessedNumber == -1)
                {
                    int parsedNumber = int.Parse(Console.ReadLine());
                    if (parsedNumber >= 0 && parsedNumber <= this.max)
                    {
                        guessedNumber = parsedNumber;
                    }
                }

                int lastGuess = -1;
                int min = 0;
                int max = this.max;
                int tries = 0;

                while (lastGuess != guessedNumber && tries < maxTries)
                {
                    lastGuess = (max + min) / 2;
                    Console.WriteLine($"Did you guess this number : {lastGuess} ?");
                    Console.WriteLine("If yes, enter 'y' if your number is greater - enter 'g', if less - 'l'");

                    string answer = Console.ReadLine();

                    if (answer == "y")
                    {
                        Console.WriteLine("Super! I guessed your number, man! :)");
                        break;
                    }

                    else if (answer == "g")
                    {
                        min = lastGuess;
                    }

                    else
                    {
                        max = lastGuess;
                    }

                    if (lastGuess == guessedNumber)
                    {
                        Console.WriteLine("Don't cheat, man! :)");
                    }
                    tries++;
                    if (tries == maxTries)
                    {
                        Console.WriteLine("No tries anymore. I lost :(");
                    }

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void HumanGuesses()
        {

            try
            {
                Random random = new Random();
                int guessedNumber = random.Next(0, max);

                int lastGuess = -1;
                int tries = 0;
                while (lastGuess != guessedNumber && tries < maxTries)
                {
                    Console.WriteLine("You have 5 tries to guess the number within 0-100 that i took.\n So let's start \n Guess the number!");
                    lastGuess = int.Parse(Console.ReadLine());


                    if (lastGuess == guessedNumber)
                    {
                        Console.WriteLine("Congrats! You guessed the number");
                        break;
                    }

                    else if (lastGuess < guessedNumber)
                    {
                        Console.WriteLine("My number is greater!");
                    }

                    else
                    {
                        Console.WriteLine("My number is less!");
                    }
                    tries++;

                    if (tries == maxTries)
                    {
                        Console.WriteLine($"The number i guessed was { guessedNumber}. You lost!");
                    }

                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
