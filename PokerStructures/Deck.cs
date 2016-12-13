using System;

namespace PokerStructures
{
    public class Deck
    {
        // array of Card of object (the real deck)
        private Card[] d;
        // current card index
        private int cc;
        // shuffle variable
        private Random rand = new Random();

        public Deck()
        {
            init();
        }

        private void init()
        {
            cc = 0;
            d = new Card[52];
            int counter = 0;
            // nice way to initialize the Deck, using
            // builtin functionality of Enum
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                    if (r != Rank.None && s != Suit.None)
                        d[counter++] = new Card(r, s);
        }

        public Card pullCard()
        {
            return d[cc++];
        }

        public Card peekCard()
        {
            return d[cc];
        }

        private void swapCards(int i, int j)
        {
            Card tmp = d[i];
            d[i] = d[j];
            d[j] = tmp;
        }

        /*
         * shuffle the deck and reset the current card
         * index to the beginning
         */
        public void shuffle(int count)
        {
            cc = 0;
            for (int i = 0; i < count; ++i)
            {
                for (int j = 0; j < 52; ++j)
                {
                    int idx = rand.Next(52);
                    swapCards(j, idx);
                }
            }
        }

        /*
         * 10 is overkill, 8 should be enough
         */
        public void shuffle()
        {
            shuffle(10);
        }

        public void print()
        {
            foreach (Card c in d)
                Console.WriteLine(c);
        }
    }
}