using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;
using UserStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class Controller
    {
        public readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public delegate void UpdateHole(Card c, int pos);
        public delegate void UpdateBoard(Card c, int pos);
        public delegate void UpdateOuts(OutsCollection outs);
        public delegate void ClearBoard();
        public delegate void ClearOuts();
        public delegate void UpdateCurrentScore(Pokerscore score);
        public delegate void UpdateBestPossible(Pokerscore score);
        public delegate void UpdateBestOuts(PokerScoreOuts outs);
        public delegate void UpdateBestChance(PokerScoreOuts outs);
        public delegate void UpdateHandsPlayed(int played);
        public delegate void UpdatePreFlopRaise(int pfr);
        public delegate void UpdateContBets(int cBets);
        public delegate void CloseApp();

        public event UpdateHole UpdateHoleEvent;
        public event UpdateBoard UpdateBoardEvent;      
        public event UpdateOuts UpdateOutsEvent;
        public event ClearBoard ClearBoardEvent;
        public event ClearOuts ClearOutsEvent;
        public event UpdateCurrentScore UpdateCurrentScoreEvent;
        public event UpdateBestPossible UpdateBestPossibleEvent;
        public event UpdateBestOuts UpdateOutsToBestEvent;
        public event UpdateBestChance UpdateBestChanceEvent;
        public event UpdateHandsPlayed UpdateHandsPlayedEvent;
        public event UpdatePreFlopRaise UpdatePreFlopRaiseEvent;
        public event UpdateContBets UpdateContBetsEvent;
        public event CloseApp CloseAppEvent;

        public MessageHandler MessageHandler { get; set; }
        public HttpSender HttpSender { get; set; }

        private static volatile Controller _instance;
        private static readonly object Mutex = new object();

        public User User;
        public Session Session = new Session();
        public string LastRoundNumber;
        public string CurrentRoundNumber;
        public readonly Round CurrentRound = new Round();
        public readonly List<Round> Rounds = new List<Round>();

        public bool InPlay;
        public PokerGameState GameState;
        public Pokerscore PokerScore;
        public OutsCollection Outs;
        private readonly PokerScoreOuts _noOuts = new PokerScoreOuts(0, 0, false);

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

        public void SetHttpSender()
        {
            HttpSender = new HttpSender(this);
        }

        public void Start()
        {
            InitEvents();
        }

        public void StopSession()
        {
            DisconnectEvents();
            HttpSender.Send();
            CloseAppEvent?.Invoke();
        }

        public void InitEvents()
        {
            MessageHandler.UpdateHoleEvent += UpdateHoleEventCard;
            MessageHandler.UpdateBoardEvent += UpdateBoardEventCard;
            MessageHandler.RaiseEvent += HandleRaiseEvent;
            MessageHandler.FoldEvent += HandleFoldEvent;
            MessageHandler.BetEvent += HandleBetEvent;
            MessageHandler.CallEvent += HandleCallEvent;
            MessageHandler.CheckEvent += HandleCheckEvent;
            MessageHandler.SetGameNumEvent += HandleGameNum;
            MessageHandler.SetHandNumEvent += HandleHandNum;
            MessageHandler.SetHandHistoryStateEvent += HandleHandHistoryState;
            MessageHandler.SetHandWonEvent += HandleHandWon;
        }

        public void DisconnectEvents()
        {
            MessageHandler.UpdateHoleEvent -= UpdateHoleEventCard;
            MessageHandler.UpdateBoardEvent -= UpdateBoardEventCard;
            MessageHandler.RaiseEvent -= HandleRaiseEvent;
            MessageHandler.FoldEvent -= HandleFoldEvent;
            MessageHandler.BetEvent -= HandleBetEvent;
            MessageHandler.CallEvent -= HandleCallEvent;
            MessageHandler.CheckEvent -= HandleCheckEvent;
            MessageHandler.SetGameNumEvent -= HandleGameNum;
            MessageHandler.SetHandNumEvent -= HandleHandNum;
            MessageHandler.SetHandHistoryStateEvent -= HandleHandHistoryState;
            MessageHandler.SetHandWonEvent -= HandleHandWon;
        }

        public void UpdateHoleEventCard(Card c, int num)
        {
            Log.Info($"Hole Card {num} {c}");

            switch (num)
            {
                case 0:
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
            Log.Info($"Board Card {num} {c}");

            switch (num)
            {
                case 0:
                    if (CurrentRound.Hole[0].Rank != Rank.None)
                    {
                        Session.Statistics.HandsPlayed++;
                        UpdateHandsPlayedEvent?.Invoke(Session.Statistics.HandsPlayed);
                    }
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
            Log.Info($"Last Hand Num {hand}");
            LastRoundNumber = hand.Remove(hand.Length - 1);
            AddRound(CurrentRound.Copy());
        }

        public void HandleGameNum(string game)
        {
            if (CurrentRoundNumber == game)
                return;

            CurrentRoundNumber = game;
            Log.Info($"This Hand Num {game}");
            CurrentRound.HandNumber = game;
            Log.Info($"Changed Hand number to {CurrentRound.HandNumber}");          
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
                    Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber)?.SetState(PokerGameState.Summary);
                    break;
                case "Hand":
                    break;
                default:
                    throw new ArgumentException("Unexpected value for hand history state");
            }
        }

        public void HandleHandWon()
        {
            var lastHand = Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber);

            if (lastHand == null)
            {
                Log.Error($"Last Hand should not be null {LastRoundNumber}");
                return;
            }
            lastHand.Won = true;

            if (lastHand.PreFlopRaise)
                Session.Statistics.PreFlopRaiseWin++;
            if (lastHand.ContinuationBet)
                Session.Statistics.ContinuationBetsWin++;
            if (lastHand.Vpip)
                Session.Statistics.VpipWin++;
            
            Session.Statistics.HandsWon++;
            switch (lastHand.State)
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
                case PokerGameState.Summary:
                    break;
                default:
                    throw new ArgumentException("Game state should never occur");
            }
        }

        private void HandleRaiseEvent()
        {
            var lastHand = Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber);
            if (lastHand == null)
            {
                Log.Error($"Last Hand should not be null {LastRoundNumber}");
                return;
            }

            if (lastHand.State == PokerGameState.PreFlop)
            {
                Session.Statistics.PreFlopRaises++;
                Session.Statistics.VoluntaryPutInPot++;
                lastHand.Vpip = true;
                lastHand.PreFlopRaise = true;
                UpdatePreFlopRaiseEvent?.Invoke(Session.Statistics.PreFlopRaises);
            }
            if (lastHand.State == PokerGameState.Flop && lastHand.PreFlopRaise)
            {
                lastHand.ContinuationBet = true;
                UpdateContBetsEvent?.Invoke(Session.Statistics.ContinuationBets);
                Session.Statistics.ContinuationBets++;                
            }
            if(lastHand.State > PokerGameState.PreFlop)
                Session.Statistics.TotalRaises++;
        }

        private void HandleFoldEvent()
        {
            var lastHand = Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber);
            if (lastHand == null)
            {
                Log.Error($"Last Hand should not be null {LastRoundNumber}");
                return;
            }

            if (lastHand.State == PokerGameState.PreFlop)
                Session.Statistics.HandsFoldedBeforeFlop++;
            if (lastHand.State < PokerGameState.Show)
                Session.Statistics.HandsFoldedBeforeRiver++;
            if (lastHand.State > PokerGameState.PreFlop)
                Session.Statistics.TotalFolds++;
        }

        private void HandleBetEvent()
        {
            var lastHand = Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber);
            if (lastHand == null)
            {
                Log.Error($"Last Hand should not be null {LastRoundNumber}");
                return;
            }

            if (lastHand.State == PokerGameState.PreFlop)
            {
                lastHand.PreFlopRaise = true;
                lastHand.Vpip = true;
                Session.Statistics.PreFlopRaises++;
                Session.Statistics.VoluntaryPutInPot++;
            }
            if (lastHand.State == PokerGameState.Flop && lastHand.PreFlopRaise)
                Session.Statistics.ContinuationBets++;
            if (lastHand.State > PokerGameState.PreFlop)
                Session.Statistics.TotalBets++;
        }

        private void HandleCallEvent()
        {
            var lastHand = Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber);
            if (lastHand == null)
            {
                Log.Error($"Last Hand should not be null {LastRoundNumber}");
                return;
            }

            if (lastHand.State == PokerGameState.PreFlop && !lastHand.Vpip)
            {
                lastHand.Vpip = true;
                Session.Statistics.VoluntaryPutInPot++;
            }
            if (lastHand.State > PokerGameState.PreFlop)
                Session.Statistics.TotalCalls++;
        }

        private void HandleCheckEvent()
        {
            var lastHand = Rounds.FirstOrDefault(r => r.HandNumber == LastRoundNumber);
            if (lastHand == null)
            {
                Log.Error($"Last Hand should not be null {LastRoundNumber}");
                return;
            }

            if (lastHand.State > PokerGameState.PreFlop)
                Session.Statistics.TotalChecks++;
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
                UpdateCurrentScoreEvent?.Invoke(PokerScore);
                UpdateBestPossibleEvent?.Invoke(Outs.BestScore());
                UpdateBestChanceEvent?.Invoke(Outs.BestPossible());
                UpdateOutsToBestEvent?.Invoke(Outs.BestPossible());
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
                UpdateCurrentScoreEvent?.Invoke(PokerScore);
                UpdateBestPossibleEvent?.Invoke(Outs.BestScore());
                UpdateBestChanceEvent?.Invoke(Outs.BestPossible());
                UpdateOutsToBestEvent?.Invoke(Outs.BestPossible());
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
                UpdateCurrentScoreEvent?.Invoke(PokerScore);
                UpdateBestPossibleEvent?.Invoke(Pokerscore.None);
                UpdateBestChanceEvent?.Invoke(_noOuts);
                UpdateOutsToBestEvent?.Invoke(_noOuts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void AddRound(Round round)
        {
            if (round.AllCards[0].Rank == Rank.None || round.AllCards[1].Rank == Rank.None)
                return;

            if (Rounds.Count == 0)
            {
                Rounds.Insert(0, round);
                Log.Info($"Added Hand Number {round.HandNumber}");
            }
            else
            {
                if (Rounds.Any(r => r.HandNumber == round.HandNumber))
                {
                    return;
                }
                Rounds.Insert(0, round);
                Log.Info($"Added Hand Number {round.HandNumber}");
            }
        }
    }
}