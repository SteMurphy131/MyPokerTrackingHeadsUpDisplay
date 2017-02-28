using System;
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
        public delegate void UpdateHole(Card c, int pos);
        public delegate void UpdateBoard(Card c, int pos);
        public delegate void UpdateOuts(OutsCollection outs);
        public delegate void ClearBoard();
        public delegate void ClearOuts();

        public event UpdateHole UpdateHoleEvent;
        public event UpdateBoard UpdateBoardEvent;      
        public event UpdateOuts UpdateOutsEvent;
        public event ClearBoard ClearBoardEvent;
        public event ClearOuts ClearOutsEvent;

        public MessageHandler MessageHandler { get; set; }

        private static volatile Controller _instance;
        private static readonly object Mutex = new object();

        public User User;
        public Session Session = new Session();
        public readonly Round CurrentRound = new Round();
        public readonly List<Round> Rounds = new List<Round>();

        public bool InPlay;
        public PokerGameState GameState;
        public Pokerscore PokerScore;
        public OutsCollection Outs;

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
                    Rounds.Add(CurrentRound);
                    CurrentRound.ClearRoundData();
                    UpdateHoleEvent?.Invoke(c, num);
                    CurrentRound.SetHoleCard(c, num);
                    InPlay = true;
                    break;
                case 1:
                    UpdateHoleEvent?.Invoke(c, num);
                    CurrentRound.SetHoleCard(c, num);
                    HandlePreFlop();
                    break;
                default:
                    throw new ArgumentException("Hole card position must be 0 or 1");
            }
        }

        public void UpdateBoardEventCard(Card c, int num)
        {
            switch (num)
            {
                case 0:
                    CurrentRound.SetFlopCard(c, num);
                    UpdateBoardEvent?.Invoke(c, num);
                    return;
                case 1:
                    CurrentRound.SetFlopCard(c, num);
                    UpdateBoardEvent?.Invoke(c, num);
                    return;
                case 2:
                    CurrentRound.SetFlopCard(c, num);
                    UpdateBoardEvent?.Invoke(c, num);
                    HandleFlop();
                    //_workerThread = new Thread(HandleFlop);
                    //_workerThread.Start();
                    return;
                case 3:
                    CurrentRound.SetTurnCard(c);
                    UpdateBoardEvent?.Invoke(c, num);
                    HandleTurn();
                    //_workerThread = new Thread(HandleTurn);
                    //_workerThread.Start();
                    return;
                case 4:
                    CurrentRound.SetRiverCard(c);
                    UpdateBoardEvent?.Invoke(c, num);
                    HandleRiver();
                    return;
                default:
                    throw new ArgumentException("Board card position must be 0 - 4");
            }
        }

        private void HandleRaiseEvent()
        {
            if (GameState == PokerGameState.PreFlop)
            {
                Session.Statistics.PreFlopRaises++;
                CurrentRound.PreFlopRaise = true;
            }
            if (GameState == PokerGameState.Flop)
            {
                if (CurrentRound.PreFlopRaise)
                    Session.Statistics.ContinuationBets++;
            }
        }

        private void HandleFoldEvent()
        {
            InPlay = false;
        }

        private void HandlePreFlop()
        {
            try
            {
                ClearBoardEvent?.Invoke();
                ClearOutsEvent?.Invoke();
                GameState = PokerGameState.PreFlop;
                PokerOutsCalculator.CalculatePreFlopOdds(CurrentRound.Hole.Values.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void HandleFlop()
        {
            try
            {
                GameState = PokerGameState.Flop;
                PokerScore = PokerEvaluator.CalculateFlopScore(CurrentRound.AllCards.Values.ToList().GetRange(0, 5));
                Outs = PokerOutsCalculator.CalculateTurnOuts(
                    new FiveCardHand(CurrentRound.AllCards.Values.ToList().GetRange(0, 5)), PokerScore);
                UpdateOutsEvent?.Invoke(Outs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }

        private void HandleTurn()
        {
            try
            {
                GameState = PokerGameState.Turn;
                PokerScore = PokerEvaluator.CalculateTurnScore(CurrentRound.AllCards.Values.ToList().GetRange(0, 6));
                Outs = PokerOutsCalculator.CalculateRiverOuts(
                    new SixCardHand(CurrentRound.AllCards.Values.ToList().GetRange(0, 6)), PokerScore);
                UpdateOutsEvent?.Invoke(Outs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }

        private void HandleRiver()
        {
            try
            {
                GameState = PokerGameState.River;
                PokerScore = PokerEvaluator.CalculateRiverScore(CurrentRound.AllCards.Values.ToList().GetRange(0, 7));
                PokerOutsCalculator.CalculateFinalWinChance(CurrentRound.AllCards.Values.ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}