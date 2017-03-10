using System;
using System.Collections.Generic;
using PokerStructures.Enums;

namespace PokerStructures
{
    public class Round : IEquatable<Round>
    {
        public Dictionary<int, Card> Hole = new Dictionary<int, Card>();
        public Dictionary<int, Card> Flop = new Dictionary<int, Card>();
        public Dictionary<int, Card> AllCards = new Dictionary<int, Card>();

        public Card Turn;
        public Card River;

        public bool PreFlopRaise;
        public bool ContinuationBet;
        public bool Won;
        public PokerGameState State;

        public string HandNumber { get; set; }

        public Round Copy()
        {
            return new Round
            {
                Hole = Hole,
                Flop = Flop,
                AllCards = AllCards,
                Turn = Turn,
                River = River,
                PreFlopRaise = PreFlopRaise,
                ContinuationBet = ContinuationBet,
                Won = Won,
                State = State,
                HandNumber = HandNumber
            };
        }

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

        public void SetState(PokerGameState state)
        {
            State = state;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Round);
        }


        public bool Equals(Round other)
        {
            if (Hole[0].Suit != other?.Hole[0].Suit || Hole[0].Rank != other.Hole[0].Rank)
                return false;
            if (Hole[1].Suit != other.Hole[1].Suit || Hole[1].Rank != other.Hole[1].Rank)
                return false;

            if (Flop[0].Suit != other.Flop[0].Suit || Flop[0].Rank != other.Flop[0].Rank)
                return false;
            if (Flop[1].Suit != other.Flop[1].Suit || Flop[1].Rank != other.Flop[1].Rank)
                return false;
            if (Flop[2].Suit != other.Flop[2].Suit || Flop[2].Rank != other.Flop[2].Rank)
                return false;

            if (Turn.Suit != other.Turn.Suit || Turn.Rank != other.Turn.Rank)
                return false;
            if (River.Suit != other.River.Suit || River.Rank != other.River.Rank)
                return false;

            if (AllCards[0].Suit != other.AllCards[0].Suit || AllCards[0].Rank != other.AllCards[0].Rank)
                return false;
            if (AllCards[1].Suit != other.AllCards[1].Suit || AllCards[1].Rank != other.AllCards[1].Rank)
                return false;
            if (AllCards[2].Suit != other.AllCards[2].Suit || AllCards[2].Rank != other.AllCards[2].Rank)
                return false;
            if (AllCards[3].Suit != other.AllCards[3].Suit || AllCards[3].Rank != other.AllCards[3].Rank)
                return false;
            if (AllCards[4].Suit != other.AllCards[4].Suit || AllCards[4].Rank != other.AllCards[4].Rank)
                return false;
            if (AllCards[5].Suit != other.AllCards[5].Suit || AllCards[5].Rank != other.AllCards[5].Rank)
                return false;
            if (AllCards[6].Suit != other.AllCards[6].Suit || AllCards[6].Rank != other.AllCards[6].Rank)
                return false;

            if (PreFlopRaise != other.PreFlopRaise)
                return false;
            if (ContinuationBet != other.ContinuationBet)
                return false;
            if (Won != other.Won)
                return false;
            if (State != other.State)
                return false;
            if (HandNumber != other.HandNumber)
                return false;
            return true;
        }
    }
}
