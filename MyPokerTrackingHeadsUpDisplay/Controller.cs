using System.Collections.Generic;
using PokerStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class Controller
    {
        public MainWindow _mainWindow { get; set; }
        public MessageHandler _messageHandler { get; set; }

        private static volatile Controller _instance = null;
        private static readonly object _mutex = new object();

        private Round _currentRound = new Round();
        private List<Round> _rounds = new List<Round>();
        private PokerCalculator _calculator = new PokerCalculator();

        private Controller(){}

        public static Controller Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_mutex)
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
            _messageHandler.updateHole += UpdateHoleCard;
            _messageHandler.updateBoard += UpdateBoardCard;
        }

        public void UpdateHoleCard(Card c, int num)
        {
            if (num == 0)
            {
                _rounds.Add(_currentRound);
                _currentRound.ClearRoundData();
                _mainWindow.UpdateHoleOne(c);
                _currentRound.SetHoleCard(c, num);
            }
            else if (num == 1)
            {
                _mainWindow.UpdateHoleTwo(c);
                _currentRound.SetHoleCard(c, num);
                _mainWindow.ClearBoardCards();
                _calculator.CalculatePreFlopOdds(_currentRound.Hole);
            }
        }

        public void UpdateBoardCard(Card c, int num)
        {
            switch (num)
            {
                case 0:
                    _currentRound.SetFlopCard(c, num);
                    _mainWindow.UpdateBoardOne(c);
                    return;
                case 1:
                    _currentRound.SetFlopCard(c, num);
                    _mainWindow.UpdateBoardTwo(c);
                    return;
                case 2:
                    _currentRound.SetFlopCard(c, num);
                    _mainWindow.UpdateBoardThree(c);
                    _calculator.CalculateTurnOuts(_currentRound.AllCards.GetRange(0,5));
                    return;
                case 3:
                    _currentRound.SetTurnCard(c);
                    _mainWindow.UpdateBoardFour(c);
                    _calculator.CalculateRiverOuts(_currentRound.AllCards.GetRange(0,6));
                    return;
                case 4:
                    _currentRound.SetRiverCard(c);
                    _mainWindow.UpdateBoardFive(c);
                    _calculator.CalculateFinalWinChance(_currentRound.AllCards);
                    return;
            }
        }
    }
}
