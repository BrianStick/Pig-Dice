using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pig_Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int NumOfPlayers;
            bool PlayerTurn = true;
            int CurrentRoll;
            char BankOrRoll;
            int TurnScore = 0;
            int CurrentPlayerNumber = 0;
            bool GameInPlay = true;

            Console.WriteLine("Lets Play Pig Dice!");
            Console.WriteLine("How many players?");
            NumOfPlayers = int.Parse(Console.ReadLine());
            

            Player[] Players = new Player[NumOfPlayers];
            for (int i = 0; i < NumOfPlayers; i++)
            {
                Players[i] = new Player();
            }

            while (GameInPlay)
            {
                Console.WriteLine($"It's Player {(CurrentPlayerNumber + 1)}'s turn!");
                Console.WriteLine($"Your current score is { Players[CurrentPlayerNumber].Score}");
                Console.WriteLine();
                while (PlayerTurn)
                {
                    CurrentRoll = DiceRoll(r);
                    Console.WriteLine($"The Dice Roll was {CurrentRoll}");
                    if (CurrentRoll == 1)
                    {
                        PlayerTurn = false;
                        Console.WriteLine("Aw, you rolled a 1!Your turn ends!");
                        Console.WriteLine();
                    }
                    else
                    {
                        TurnScore = TurnScore + CurrentRoll;

                        if (Players[CurrentPlayerNumber].Score + TurnScore >= 100)
                        {
                            Console.WriteLine("You have at least 100 points! You Win!!");
                            Players[CurrentPlayerNumber].Score += TurnScore;
                            GameInPlay = false;
                            break;
                        }

                        Console.WriteLine($"Your score this turn is currently {TurnScore}, Which would make your score {(Players[CurrentPlayerNumber].Score + TurnScore)} if you bank now");
                        Console.WriteLine();
                        Console.Write($"Would you like to bank your {TurnScore} or roll again? ");
                        Console.WriteLine("Please enter B or R");
                        BankOrRoll = char.Parse(Console.ReadLine());
                        Console.WriteLine();
                        while (BankOrRoll != 'B' && BankOrRoll != 'b' && BankOrRoll != 'R' && BankOrRoll != 'r')
                        {
                            Console.WriteLine("Please enter B or R");
                            BankOrRoll = char.Parse(Console.ReadLine());
                        }

                        if (BankOrRoll == 'B' || BankOrRoll == 'b')
                        {
                            Players[CurrentPlayerNumber].Score += TurnScore;
                            PlayerTurn = false;
                        }

                    }
                }
                Console.WriteLine("It's not your turn anymore");

                int PlayerNumber = 1;
                foreach (var people in Players)
                {
                    Console.WriteLine($"Player {PlayerNumber}'s score is {people.Score}");
                    PlayerNumber++;
                }
                if (GameInPlay)
                {
                    Console.WriteLine("Press Enter for next turn");
                }
                Console.ReadLine();
                Console.Clear();

                if (CurrentPlayerNumber == NumOfPlayers - 1)
                {
                    CurrentPlayerNumber = 0;
                }
                else
                {
                    CurrentPlayerNumber++;
                }
                TurnScore = 0;
                PlayerTurn = true;
            }
        }

        static int DiceRoll(Random r)
        {
            int Roll = r.Next(1, 7);
            return Roll;
        }
    }

    public class Player
    {
        public int Score = 0;
    }
}

