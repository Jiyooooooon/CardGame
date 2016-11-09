using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public enum Rank
    {
        Deuce = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the card game");
            Console.WriteLine();
            Random myRandom = new Random(); // random num generating 

            Queue<Rank> playerHand = DealFive(myRandom); // first in first out DealFive(myRandom)
            Queue<Rank> computerHand = DealFive(myRandom); // DealFive(myRandom)

            int numberTurns = 0;
            while ((playerHand.Count > 0 && computerHand.Count > 0 && numberTurns < 50)) //numberTurns < 50 &&
            {
                Console.WriteLine("You have {0} cards, Computer has {1} cards", playerHand.Count, computerHand.Count);
                Console.WriteLine("press enter to play next hand");
                Console.ReadLine();
                PlayOneTurn(playerHand, computerHand, numberTurns); // whatt actually do ?
                numberTurns = numberTurns + 1;
            }
            Console.ReadLine();
        }

        private static Queue<Rank> DealFive(Random myRandom)
        {
            Queue<Rank> methodQueue = new Queue<Rank>();
            for (int i = 0; i < 5; i++)
            {
                methodQueue.Enqueue((Rank)myRandom.Next(2, 15));
            }
            return methodQueue;
        }

        private static void PlayOneTurn(Queue<Rank> playerHand, Queue<Rank> computerHand, int numberTurns)
        {
            Console.WriteLine("Hand number: {0}", numberTurns + 1);
            Rank playerCard = playerHand.Dequeue();
            Rank computerCard = computerHand.Dequeue();
            if (playerCard > computerCard)
            {
                Console.WriteLine();
                Console.WriteLine("You played a {0} and computer played a {1}", playerCard, computerCard);
                Console.WriteLine("You won this turn");
                playerHand.Enqueue(playerCard);
                playerHand.Enqueue(computerCard);

            }
            else if (computerCard > playerCard)
            {
                Console.WriteLine();
                Console.WriteLine("You played a {0} and computer played a {1}", playerCard, computerCard);
                Console.WriteLine("You lost this turn");
                computerHand.Enqueue(computerCard);
                computerHand.Enqueue(playerCard);
            }
            else
            {
                Console.WriteLine("It's a tie");
            }


        }
    }
}
