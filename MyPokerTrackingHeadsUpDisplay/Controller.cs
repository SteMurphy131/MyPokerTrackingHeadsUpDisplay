using System.Collections.Generic;
using System.Linq;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;
using UserStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class Controller
    {
        public MainWindow MainWindow { get; set; }
        public MessageHandler MessageHandler { get; set; }

        private static volatile Controller _instance;
        private static readonly object Mutex = new object();

        public User User;
        private Session _session = new Session();
        private readonly Round _currentRound = new Round();
        private readonly List<Round> _rounds = new List<Round>();

        //this boolean keeps track of whether or not the user is still betting on the round (ie they haven't folded yet)
        private bool _inPlay;
        private PokerGameState _gameState;
        private Pokerscore _pokerScore;

        private Controller(){}

        public static Controller Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Mutex)
                {
                    if (_instance == null)
                    {
                        _instance = new Controller();
                    }
                }
                return _instance;
            }
        }

        public void InitEvents()
        {
            MessageHandler.UpdateHoleEvent += UpdateHoleEventCard;
            MessageHandler.UpdateBoardEvent += UpdateBoardEventCard;
            MessageHandler.RaiseEvent += HandleRaiseEvent;
            MessageHandler.FoldEvent += HandleFoldEvent;
        }

        public void UpdateHoleEventCard(Card c, int num)
        {
            switch (num)
            {
                case 0:
                    _rounds.Add(_currentRound);
                    _currentRound.ClearRoundData();
                    MainWindow.UpdateHoleOne(c);
                    _currentRound.SetHoleCard(c, num);
                    _inPlay = true;
                    break;
                case 1:
                    MainWindow.UpdateHoleTwo(c);
                    _currentRound.SetHoleCard(c, num);
                    MainWindow.ClearBoardCards();
                    _gameState = PokerGameState.PreFlop;
                    PokerOutsCalculator.CalculatePreFlopOdds(_currentRound.Hole.Values.ToList());
                    break;
            }
        }

        public void UpdateBoardEventCard(Card c, int num)
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
                    _gameState = PokerGameState.Flop;
                    _pokerScore = PokerEvaluator.CalculateFlopScore(_currentRound.AllCards.Values.ToList().GetRange(0,5));
                    PokerOutsCalculator.CalculateTurnOuts(
                        new FiveCardHand(_currentRound.AllCards.Values.ToList().GetRange(0,5)), _pokerScore);
                    return;
                case 3:
                    _currentRound.SetTurnCard(c);
                    MainWindow.UpdateBoardFour(c);
                    _gameState = PokerGameState.Turn;
                    _pokerScore = PokerEvaluator.CalculateTurnScore(_currentRound.AllCards.Values.ToList().GetRange(0, 6));
                    PokerOutsCalculator.CalculateRiverOuts(
                        new SixCardHand(_currentRound.AllCards.Values.ToList().GetRange(0,6)), _pokerScore);
                    return;
                case 4:
                    _currentRound.SetRiverCard(c);
                    MainWindow.UpdateBoardFive(c);
                    _gameState = PokerGameState.River;
                    _pokerScore = PokerEvaluator.CalculateRiverScore(_currentRound.AllCards.Values.ToList().GetRange(0, 7));
                    PokerOutsCalculator.CalculateFinalWinChance(_currentRound.AllCards.Values.ToList());
                    return;
            }
        }

        private void HandleRaiseEvent()
        {
            if (_gameState == PokerGameState.PreFlop)
                _session.Statistics.PreFlopRaises++;
            if (_gameState > PokerGameState.PreFlop)
                _session.Statistics.ContinuationBets++;
        }

        private void HandleFoldEvent()
        {
            _inPlay = false;
        }
    }
}