using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class PokerCalculator
    {
        public void CalculatePreFlopOdds(List<Card> cards)
        {
            cards.Sort();
        }

        public void CalculateTurnOuts(List<Card> cards)
        {
            cards.Sort();
        }

        public void CalculateRiverOuts(List<Card> cards)
        {
            cards.Sort();
        }

        public void CalculateFinalWinChance(List<Card> cards)
        {

        }
    }

    public class FlushCalculator
    {
        public void CalculateFlushOutsPreFlop(List<Card> cards)
        {

        }
    }
}
