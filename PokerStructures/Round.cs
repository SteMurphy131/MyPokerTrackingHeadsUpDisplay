using System.Collections.Generic;

namespace PokerStructures
{
    public class Round
    {
        public List<Card> Hole = new List<Card>();
        public List<Card> Flop = new List<Card>();
        public Card Turn;
        public Card River;
        public List<Card> AllCards = new List<Card>();

        public void SetHoleCard(Card c, int position)
        {
            Hole[position] = c;
            AllCards[position] = c;
        }

        public void SetFlopCard(Card c, int position)
        {
            Flop[position] = c;
            AllCards[position + 2] = c;
        }

        public void SetTurnCard(Card c)
        {
            Turn = c;
            AllCards[5] = c;
        }

        public void SetRiverCard(Card c)
        {
            River = c;
            AllCards[6] = c;
        }

        public void ClearRoundData()
        {
            Hole.Clear();
            Flop.Clear();
            AllCards.Clear();
            Turn = null;
            River = null;
        }
    }
}
