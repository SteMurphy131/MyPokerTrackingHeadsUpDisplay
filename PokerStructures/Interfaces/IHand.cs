using System.Collections.Generic;
using PokerStructures.Enums;

namespace PokerStructures.Interfaces
{
    public interface IHand
    {
        void Sort();
        int CountFlush();
        Suit CalculateMaxSuit(int max);
        Suit GetMaxSuit();
    }
}