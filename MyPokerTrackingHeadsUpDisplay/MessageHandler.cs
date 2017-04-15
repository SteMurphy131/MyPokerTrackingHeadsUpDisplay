using PokerStructures;
using PokerStructures.Enums;
using UserStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class MessageHandler
    {
        public delegate void UpdateHole(Card c, int pos);
        public delegate void UpdateBoard(Card c, int pos);
        public delegate void Raise();
        public delegate void Fold();
        public delegate void Call();
        public delegate void Bet();
        public delegate void Check();
        public delegate void OpponentRaise(string name);
        public delegate void OpponentFold(string name);
        public delegate void OpponentCall(string name);
        public delegate void OpponentBet(string name);
        public delegate void OpponentCheck(string name);
        public delegate void SetHandNum(string num);
        public delegate void SetGameNum(string num);
        public delegate void SetHandHistoryState(string state);
        public delegate void SetHandWon();
        public delegate void ResetOpponents();
        
        public event UpdateHole UpdateHoleEvent;
        public event UpdateBoard UpdateBoardEvent;
        public event Raise RaiseEvent;
        public event Fold FoldEvent;
        public event Call CallEvent;
        public event Bet BetEvent;
        public event Check CheckEvent;
        public event OpponentRaise OpponentRaiseEvent;
        public event OpponentFold OpponentFoldEvent;
        public event OpponentCall OpponentCallEvent;
        public event OpponentBet OpponentBetEvent;
        public event OpponentCheck OpponentCheckEvent;
        public event SetHandNum SetHandNumEvent;
        public event SetGameNum SetGameNumEvent;
        public event SetHandHistoryState SetHandHistoryStateEvent;
        public event SetHandWon SetHandWonEvent;
        public event ResetOpponents ResetOpponentsEvent;

        public string UserName { get; set; }
        public readonly Controller Controller;

        private bool _summary;

        public MessageHandler()
        {
            Controller = Controller.Instance;
            Controller.MessageHandler = this;
            Controller.InitEvents();
        }

        public void ProcessUpdateBoardMessage(string message)
        {
            var splitMessage = message.Split(' ');

            var position = (int)char.GetNumericValue(splitMessage[2][1]);
            var card = CreateCardFromText(splitMessage[1]);

            UpdateBoardEvent?.Invoke(card, position);
        }

        public void ProcessUpdateHoleCardMessage(string message)
        {
            var splitMessage = message.Split(' ');

            var position = (int)char.GetNumericValue(splitMessage[1][0]);
            var card = CreateCardFromText(splitMessage[2]);

            UpdateHoleEvent?.Invoke(card, position);
        }

        public void HandleHandHistory(string handHistory)
        {
            _summary = false;
            ResetOpponentsEvent?.Invoke();

            foreach (var line in handHistory.Split('\n'))
            {
                if (line.Contains("Seat") && !line.Contains("button") && !_summary)
                {
                    var split = line.Split(':');
                    var name = split[1].Substring(1, split[1].IndexOf('(')-2);
                    if (name == "SteMurphy131")
                        continue;

                    if (!Controller.Opponents.ContainsKey(name))
                        Controller.Opponents[name] = new Opponent {Name = name, HandsPlayed = 1};
                    else
                    {
                        Controller.Opponents[name].HandsPlayed++;
                        Controller.Opponents[name].InPlay = true;
                    }
                }
                else if(line.Contains("HOLE") || line.Contains("FLOP") || line.Contains("TURN") ||
                   line.Contains("RIVER") || line.Contains("SHOW DOWN") || line.Contains("SUMMARY"))
                {
                    var split = line.Split(' ');
                    SetHandHistoryStateEvent?.Invoke(split[1]);

                    if (line.Contains("SUMMARY"))
                        _summary = true;
                }
                else if (line.Contains("SteMurphy131") && line.Contains("collected"))
                {
                    SetHandWonEvent?.Invoke();
                }
                else if (line.Contains("SteMurphy131"))
                {
                    if (line.Contains("calls"))
                    {
                        CallEvent?.Invoke();
                    }
                    else if (line.Contains("bets"))
                    {
                        BetEvent?.Invoke();
                    }
                    else if (line.Contains("raises"))
                    {
                        RaiseEvent?.Invoke();
                    }
                    else if (line.Contains("checks"))
                    {
                        CheckEvent?.Invoke();
                    }
                    else if (line.Contains("folds"))
                    {
                        FoldEvent?.Invoke();
                    }
                }
                else if (line.Contains("Hand #"))
                {
                    var split = line.Split(' ');
                    SetHandNumEvent?.Invoke(split[2]);
                }
                else if (line.Contains("calls"))
                {
                    var user = line.Split(':')[0];
                    OpponentCallEvent?.Invoke(user);
                }
                else if (line.Contains("checks"))
                {
                    var user = line.Split(':')[0];
                    OpponentCheckEvent?.Invoke(user);
                }
                else if (line.Contains("bets"))
                {
                    var user = line.Split(':')[0];
                    OpponentBetEvent?.Invoke(user);
                }
                else if (line.Contains("raises"))
                {
                    var user = line.Split(':')[0];
                    OpponentRaiseEvent?.Invoke(user);
                }
                else if (line.Contains("folds"))
                {
                    var user = line.Split(':')[0];
                    OpponentFoldEvent?.Invoke(user);
                }
            }
        }

        public void ProcessGameNumber(string gameNum)
        {
            var splitMessage = gameNum.Split(' ');
            SetGameNumEvent?.Invoke(splitMessage[1]);
        }

        public Card CreateCardFromText(string cardString)
        {
            var rankString = cardString.Substring(0, cardString.Length - 1);
            var suitString = cardString.Substring(cardString.Length - 1);

            Rank rank = (Rank)int.Parse(rankString);
            Suit suit = PokerHelper.SuitDictionary[suitString];

            return new Card(rank, suit);
        }
    }
}
