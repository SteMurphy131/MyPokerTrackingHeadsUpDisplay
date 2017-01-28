using System.Collections.Generic;
using PokerStructures;
using UserStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class Controller
    {
        public MainWindow MainWindow { get; set; }
        public MessageHandler MessageHandler { get; set; }

        private static volatile Controller _instance;
        private static readonly object Mutex = new object();

        private Session _session = new Session();
        private readonly Round _currentRound = new Round();
        private readonly List<Round> _rounds = new List<Round>();
        private readonly PokerCalculator _calculator = new PokerCalculator();

        private Controller(){}

        public static Controller Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Mutex)
                    {
                        if (_instance == null)
                        {
                            _instance = new Controller();
                        }
                    }
                }
                return _instance;
            }
        }

        public void InitEvents()
        {
            MessageHandler.updateHole += UpdateHoleCard;
            MessageHandler.updateBoard += UpdateBoardCard;
        }

        public void UpdateHoleCard(Card c, int num)
        {
            if (num == 0)
            {
                _rounds.Add(_currentRound);
                _currentRound.ClearRoundData();
                MainWindow.UpdateHoleOne(c);
                _currentRound.SetHoleCard(c, num);
            }
            else if (num == 1)
            {
                MainWindow.UpdateHoleTwo(c);
                _currentRound.SetHoleCard(c, num);
                MainWindow.ClearBoardCards();
                _calculator.CalculatePreFlopOdds(_currentRound.Hole);
            }
        }

        public void UpdateBoardCard(Card c, int num)
        {
            switch (num)
            {
                case 0:
                    _currentRound.SetFlopCard(c, num);
                    MainWindow.UpdateBoardOne(c);
                    return;
                case 1:
                    _currentRound.SetFlopCard(c, num);
                    MainWindow.UpdateBoardTwo(c);
                    return;
                case 2:
                    _currentRound.SetFlopCard(c, num);
                    MainWindow.UpdateBoardThree(c);
                    _calculator.CalculateTurnOuts(_currentRound.AllCards.GetRange(0,5));
                    return;
                case 3:
                    _currentRound.SetTurnCard(c);
                    MainWindow.UpdateBoardFour(c);
                    _calculator.CalculateRiverOuts(_currentRound.AllCards.GetRange(0,6));
                    return;
                case 4:
                    _currentRound.SetRiverCard(c);
                    MainWindow.UpdateBoardFive(c);
                    _calculator.CalculateFinalWinChance(_currentRound.AllCards);
                    return;
            }
        }
    }
}
