using System;
using System.Collections.Generic;
using System.Linq;

namespace CardTrick
{
    public class Deck
    {
        private const int Cols = 3;
        private const int Rows = 7;
        
        private static readonly Random Random = new Random();
        
        public Card[][] Cards { get; }

        public Deck()
        {
            Cards = new Card[Cols][];
            for (int i = 0; i < Cols; i++)
                Cards[i] = new Card[Rows];
        }

        public void Setup()
        {
            IEnumerable<Card> Source(int noCards)
            {
                var used = new HashSet<Card>();

                Card RandomCard() => new Card(
                    (Suit) Random.Next(1, Enum.GetValues<Suit>().Length),
                    (Face) Random.Next(1, Enum.GetValues<Face>().Length+1)
                );
                
                for (int i = 0; i < noCards; i++)
                {
                    var card = RandomCard();
                    while (used.Contains(card))
                        card = RandomCard();
                    used.Add(card);
                    yield return card;
                }
            }

            using var cardEnumerator = Source(Rows * Cols).GetEnumerator();
            
            for (int c = 0; c < Cols; c++)
            for (int r = 0; r < Rows; r++)
            {
                cardEnumerator.MoveNext();
                Cards[c][r] = cardEnumerator.Current;
            }
        }

        /// <summary>
        /// This is a tuple deconstruction trick to swap two variables by reference
        /// </summary>
        /// <param name="columnId">Zero based column ID to switch to center</param>
        public void MoveColumnToCenter(int columnId) => (Cards[1], Cards[columnId]) = (Cards[columnId], Cards[1]);

        public void Transpose()
        {
            IEnumerable<Card> Source()
            {
                for (int c = 0; c < Cols; c++)
                for (int r = 0; r < Rows; r++)
                    yield return Cards[c][r];
            }

            using var transposeEnumerator = Source().Reverse().ToList().GetEnumerator();

            for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Cols; c++)
            {
                transposeEnumerator.MoveNext();
                Cards[c][r] = transposeEnumerator.Current;
            }
        }

        public void Print()
        {
            Console.WriteLine();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                    Console.Write($"{Cards[c][r]} ");
                Console.WriteLine();
            }
        }
    }
}