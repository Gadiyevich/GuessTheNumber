using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GuessNumberGame(guessingPlayer: GuessingPlayer.Human);
            game.Start();

            Console.ReadLine();
        }
    }
}
