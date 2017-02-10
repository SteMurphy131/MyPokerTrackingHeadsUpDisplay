using System.Collections.Generic;

namespace PokerStructures
{
    public class Round
    {
        public Dictionary<int, Card> Hole = new Dictionary<int, Card>();
        public Dictionary<int, Card> Flop = new Dictionary<int, Card>();
        public Dictionary<int, Card> AllCards = new Dictionary<int, Card>();

        public Card Turn;
        public Card River;

        public bool PreFlopRaise;
        
        public void SetHoleCard(Card c, int position)
        {
            Hole[position] = c;
            AllCards[position] = c;
        }

        public void SetFlopCard(Card c, int position)
        {
            Flop[position] =  c;
            AllCards[position+2] = c;
        }

        public void SetTurnCard(Card c)
        {
            Turn = c;
            AllCards[5] = c;
        }

        public void SetRiverCard(Card c)
        {
            River = c;
            AllCards[6] =  c;
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
