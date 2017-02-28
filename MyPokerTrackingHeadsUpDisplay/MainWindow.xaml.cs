using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PokerStructures;
using PokerStructures.Calculation;

namespace MyPokerTrackingHeadsUpDisplay
{
    public partial class MainWindow 
    {
        private readonly Controller _controller;
        private PokerScoreOuts _noOuts = new PokerScoreOuts(0,0,false);

        public MainWindow()
        {
            InitializeComponent();
            _controller = Controller.Instance;
            InitEvents();

            //LogIn();

            if (Injector.InjectDll())
            {
                UpdateTextBox("Dll Injected");
            }
        }

        private void InitEvents()
        {
            _controller.UpdateHoleEvent += UpdateHole;
            _controller.UpdateBoardEvent += UpdateBoard;
            _controller.UpdateOutsEvent += UpdateOuts;
            _controller.ClearBoardEvent += ClearCards;
            _controller.ClearOutsEvent += ClearOuts;
        }

        private void LogIn()
        {
            LogInWindow window = new LogInWindow();
            window.ShowDialog();
            _controller.User = window.User;
        }

        public void UpdateTextBox(string text)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                textBox.Text = text;
            });
        }

        public void ClearCards()
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary["na"].UriSource;
                bitmap.EndInit();

                BoardImageOne.Source = bitmap;
                BoardImageTwo.Source = bitmap;
                BoardImageThree.Source = bitmap;
                BoardImageFour.Source = bitmap;
                BoardImageFive.Source = bitmap;
            });
        }

        public void UpdateHole(Card c, int num)
        {
            switch (num)
            {
                case 0:
                    UpdateHoleOne(c);
                    break;
                case 1:
                    UpdateHoleTwo(c);
                    break;
                default:
                    throw new ArgumentException("Hole card position should be 0 or 1");
            }
        }

        public void UpdateBoard(Card c, int num)
        {
            switch (num)
            {
                case 0:
                    UpdateBoardOne(c);
                    break;
                case 1:
                    UpdateBoardTwo(c);
                    break;
                case 2:
                    UpdateBoardThree(c);
                    break;
                case 3:
                    UpdateBoardFour(c);
                    break;
                case 4:
                    UpdateBoardFive(c);
                    break;
                default:
                    throw new ArgumentException("Board card position should be 0 - 4");
            }
        }

        public void UpdateHoleOne(Card c)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                HoleImageOne.Source = bitmap;
            });
        }

        public void UpdateHoleTwo(Card c)
        { 
            Dispatcher.BeginInvoke((Action)delegate 
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                HoleImageTwo.Source = bitmap; 
            });
        }

        public void UpdateBoardOne(Card c)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                BoardImageOne.Source = bitmap;
            });
        }

        public void UpdateBoardTwo(Card c)
        { 
            Dispatcher.BeginInvoke((Action)delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                BoardImageTwo.Source = bitmap;
            });
        }

        public void UpdateBoardThree(Card c)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                BoardImageThree.Source = bitmap;
            });
        }

        public void UpdateBoardFour(Card c)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                BoardImageFour.Source = bitmap;
            });
        }

        public void UpdateBoardFive(Card c)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                BoardImageFive.Source = bitmap;
            });
        }

        public void UpdateOuts(OutsCollection outs)
        {
            UpdatePairOuts(outs.Pair ?? _noOuts);
            UpdateTwoPairOuts(outs.TwoPair ?? _noOuts);
            UpdateThreeOfAKindOuts(outs.ThreeOfAKind ?? _noOuts);
            UpdateStraightOuts(outs.Straight ?? _noOuts);
            UpdateFlushOuts(outs.Flush ?? _noOuts);
            UpdateFullHouse(outs.FullHouse ?? _noOuts);
            UpdateFourOfAKindOuts(outs.FourOfAKind ?? _noOuts);
            UpdateStraightFlushOuts(outs.StraightFlush ?? _noOuts);
            UpdateRoyalFlushOuts(outs.RoyalFlush ?? _noOuts);
        }

        public void ClearOuts()
        {
            UpdatePairOuts(_noOuts);
            UpdateTwoPairOuts(_noOuts);
            UpdateThreeOfAKindOuts(_noOuts);
            UpdateStraightOuts(_noOuts);
            UpdateFlushOuts(_noOuts);
            UpdateFullHouse(_noOuts);
            UpdateFourOfAKindOuts(_noOuts);
            UpdateStraightFlushOuts(_noOuts);
            UpdateRoyalFlushOuts(_noOuts);
        }

        public void UpdatePairOuts(PokerScoreOuts pairOuts)
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                PairProgressBar.Value = pairOuts.Percentage;
                PairProgressBar.SetColour(pairOuts.Percentage);
                PairOutsBox.Text = pairOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateTwoPairOuts(PokerScoreOuts twoPairOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                TwoPairProgressBar.Value = twoPairOuts.Percentage;
                TwoPairProgressBar.SetColour(twoPairOuts.Percentage);
                TwoPairOutsBox.Text = twoPairOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateThreeOfAKindOuts(PokerScoreOuts tripsOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                ThreeOfAKindProgressBar.Value = tripsOuts.Percentage;
                ThreeOfAKindProgressBar.SetColour(tripsOuts.Percentage);
                TripsOutsBox.Text = tripsOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateStraightOuts(PokerScoreOuts straightOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                StraightProgressBar.Value = straightOuts.Percentage;
                StraightProgressBar.SetColour(straightOuts.Percentage);
                StraightOutsBox.Text = straightOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateFlushOuts(PokerScoreOuts flushOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                FlushProgressBar.Value = flushOuts.Percentage;
                FlushProgressBar.SetColour(flushOuts.Percentage);
                FlushOutsBox.Text = flushOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateFourOfAKindOuts(PokerScoreOuts quadOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                FourOfAKindProgressBar.Value = quadOuts.Percentage;
                FourOfAKindProgressBar.SetColour(quadOuts.Percentage);
                QuadsOutsBox.Text = quadOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateFullHouse(PokerScoreOuts fullHouseOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                FullHouseProgressBar.Value = fullHouseOuts.Percentage;
                FullHouseProgressBar.SetColour(fullHouseOuts.Percentage);
                FullHouseOutsBox.Text = fullHouseOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateStraightFlushOuts(PokerScoreOuts sFlushOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                StraightFlushProgressBar.Value = sFlushOuts.Percentage;
                StraightFlushProgressBar.SetColour(sFlushOuts.Percentage);
                SFlushOutsBox.Text = sFlushOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateRoyalFlushOuts(PokerScoreOuts rFlushOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                RoyalFlushProgressBar.Value = rFlushOuts.Percentage;
                RoyalFlushProgressBar.SetColour(rFlushOuts.Percentage);
                RFlushOutsBox.Text = rFlushOuts.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }
    }
}