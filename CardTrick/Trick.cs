using System;
using System.Linq;

namespace CardTrick
{
    public class Trick
    {
        public void Run()
        {
            var deck = new Deck();
            deck.Setup();

            bool running = true;
            var accepted = new[] { '1', '2', '3', 'X' };
            
            while (running)
            {
                deck.Print();
                Console.WriteLine($"Card 12: {deck.Cards[1][3]}");
                
                char? choice = null;
                
                while (choice == null || !accepted.Contains(choice.Value))
                {
                    Console.Write("Which column contains your card? [x to quit]:  ");
                    choice = Char.ToUpperInvariant(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                }

                switch (choice)
                {
                    case '1':
                        deck.MoveColumnToCenter(0);
                        deck.Transpose();
                        break;
                    case '2':
                        deck.Transpose();
                        break;
                    case '3':
                        deck.MoveColumnToCenter(2);
                        deck.Transpose();
                        break;
                    case 'X':
                        running = false;
                        break;
                }
            }
        }
    }
}
