using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiarsDice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] playerOneHand = new int[5];
            int[] playerTwoHand = new int[5];
            int playerDiceAmount = 0;
            int playerDice = 0;
            int tempCorrectDices = 0;
            bool tempRunning = true;
            bool tempCorrectInput = false;

            do
            {
                Console.WriteLine("Welcome! This is a game that requires a bit of luck. ");
                Console.WriteLine("The goal of the game is for you to guess the amout of dice of a single value.");
                playerOneHand = GenerateHand(playerOneHand);
                playerTwoHand = GenerateHand(playerTwoHand);
                Console.WriteLine("Your hand");
                for (int i = 0; i < playerOneHand.Length; i++)
                {
                    Console.WriteLine(playerOneHand[i]);
                }
                tempCorrectInput = false;
                while (tempCorrectInput == false)
                {
                    Console.WriteLine("Which dice value would you like to guess on?");

                    int.TryParse(Console.ReadLine(),out playerDice);
                    if (playerDice > 0 && playerDice < 7)
                    {
                        tempCorrectInput = true;
                    }
                    else
                    {
                        Console.WriteLine("You must type a number between 1-6");
                    }
                }
                tempCorrectInput = false;
                while (tempCorrectInput == false)
                {
                    Console.WriteLine("How many dices with the value " + playerDice + " do think there are?");
                    int.TryParse(Console.ReadLine(), out playerDiceAmount);
                    if (playerDiceAmount > 0 && playerDiceAmount < 11)
                    {
                        tempCorrectInput = true;
                    }
                    else
                    {
                        Console.WriteLine("You must type a number between 1-11");
                    }
                }
                tempCorrectInput = false;
                for (int i = 0; i < playerOneHand.Length; i++)
                {
                    if (playerOneHand[i] == playerDice)
                    {
                        tempCorrectDices++;
                    }
                }
                for (int i = 0; i < playerTwoHand.Length; i++)
                {
                    if (playerTwoHand[i] == playerDice)
                    {
                        tempCorrectDices++;
                    }
                }
                Console.Clear();
                if (tempCorrectDices == playerDiceAmount)
                {
                    Console.WriteLine("Congratulations!!! You guessed right!");
                    Console.WriteLine("You guessed correctly that there we're " + playerDiceAmount + " dices with the value " + playerDice + ". There were " + tempCorrectDices + ".");
                }
                else
                {
                    Console.WriteLine("Sorry! You lost. You guessed that there we're " + playerDiceAmount + " dices with the value " + playerDice + ". There were " + tempCorrectDices + ".");
                }
                while (tempCorrectInput == false)
                {
                    Console.WriteLine("Do you want to play again? Yes = 1, No = 2)");
                    int tempValue = Convert.ToInt32(Console.ReadLine());
                    if (tempValue == 1 || tempValue == 2)
                    {
                        tempCorrectInput = true;
                        if (tempValue == 1)
                        {
                            Console.Clear();
                            tempCorrectDices = 0;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You must type a 1 or 2");
                    }
                }
            } while (tempRunning == true);
        }

        static int[] GenerateHand(int[] anArray)
        {
            Random rNG = new Random();
            for (int i = 0; i < anArray.Length; i++)
            {
                anArray[i] = rNG.Next(1, 6);
            }
            return anArray;
        }
    }
}