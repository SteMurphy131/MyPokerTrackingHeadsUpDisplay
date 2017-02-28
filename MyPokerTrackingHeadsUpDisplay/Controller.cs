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
        public string LastRoundNumber;
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
            MessageHandler.SetGameNumEvent += HandleGameNum;
            MessageHandler.SetHandNumEvent += HandleHandNum;
            MessageHandler.SetHandHistoryStateEvent += HandleHandHistoryState;
            MessageHandler.SetHandWonEvent += HandleHandWon;
        }

        public void UpdateHoleEventCard(Card c, int num)
        {
            switch (num)
            {
                case 0:
                    Rounds.Add(CurrentRound);
                    CurrentRound.ClearRoundData();
                    Session.Statistics.HandsPlayed++;
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
                    return;
                case 3:
                    CurrentRound.SetTurnCard(c);
                    UpdateBoardEvent?.Invoke(c, num);
                    HandleTurn();
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

        public void HandleHandNum(string hand)
        {
            LastRoundNumber = hand;
        }

        public void HandleGameNum(string game)
        {
            CurrentRound.HandNumber = game;
        }

        public void HandleHandHistoryState(string message)
        {
            switch (message)
            {
                case "HOLE":
                    Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber)?.SetState(PokerGameState.PreFlop);
                    break;
                case "FLOP":
                    Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber)?.SetState(PokerGameState.Flop);
                    break;
                case "TURN":
                    Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber)?.SetState(PokerGameState.Turn);
                    break;
                case "RIVER":
                    Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber)?.SetState(PokerGameState.River);
                    break;
                case "SHOW":
                    Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber)?.SetState(PokerGameState.Show);
                    Session.Statistics.HandsPlayedToRiver++;
                    break;
                case "SUMMARY":
                    Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber)?.SetState(PokerGameState.Show);
                    break;
                default:
                    throw new ArgumentException("Unexpected value for hand history state");
            }
        }

        public void HandleHandWon()
        {
            var lastHand = Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber);

            if (lastHand != null && lastHand.PreFlopRaise)
                Session.Statistics.PreFlopRaiseWin++;
            if (lastHand != null && lastHand.ContinuationBet)
                Session.Statistics.ContinuationBetsWin++;
            
            Session.Statistics.HandsWon++;
            switch (lastHand?.State)
            {
                case PokerGameState.PreFlop:
                    Session.Statistics.HandsWonBeforeFlop++;
                    break;
                case PokerGameState.Flop:
                    Session.Statistics.HandsWonBeforeRiver++;
                    break;
                case PokerGameState.Turn:
                    Session.Statistics.HandsWonBeforeRiver++;
                    break;
                case PokerGameState.River:
                    Session.Statistics.HandsWonBeforeRiver++;
                    break;
                case PokerGameState.Show:
                    Session.Statistics.HandsWonAtRiver++;
                    break;
                case null:
                    throw new ArgumentException("Game state should never occur");
                default:
                    throw new ArgumentException("Game state should never occur");
            }
        }

        private void HandleRaiseEvent()
        {
            if (GameState == PokerGameState.PreFlop)
            {
                Session.Statistics.PreFlopRaises++;
                CurrentRound.PreFlopRaise = true;
            }
            if (GameState == PokerGameState.Flop && CurrentRound.PreFlopRaise)
            {
                CurrentRound.ContinuationBet = true;
                Session.Statistics.ContinuationBets++;                
            }
        }

        private void HandleFoldEvent()
        {
            InPlay = false;
            if (GameState == PokerGameState.PreFlop)
                Session.Statistics.HandsFoldedBeforeFlop++;
            if (GameState < PokerGameState.Show)
                Session.Statistics.HandsFoldedBeforeRiver++;
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
                ClearOutsEvent?.Invoke();
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
                ClearOutsEvent?.Invoke();
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
                ClearOutsEvent?.Invoke();
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