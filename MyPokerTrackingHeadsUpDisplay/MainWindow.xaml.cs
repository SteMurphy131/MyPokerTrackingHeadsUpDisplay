using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using PokerStructures;
using PokerStructures.Calculation;
using PokerStructures.Enums;
using PokerStructures.ExtensionMethods;

namespace MyPokerTrackingHeadsUpDisplay
{
    public partial class MainWindow
    {
        private readonly Controller _controller;
        private readonly PokerScoreOuts _noOuts = new PokerScoreOuts(0, 0, false);

        public MainWindow()
        {
            InitializeComponent();
            _controller = Controller.Instance;
            _controller.SetHttpSender();
            InitEvents();

            //LogIn();

            if (Injector.InjectDll())
                UpdateTextBox("Dll Injected");
            //else
            //    Application.Current.Shutdown(0);
        }

        private void InitEvents()
        {
            _controller.UpdateHoleEvent += UpdateHole;
            _controller.UpdateBoardEvent += UpdateBoard;
            _controller.UpdateOutsEvent += UpdateOuts;
            _controller.ClearBoardEvent += ClearCards;
            _controller.ClearOutsEvent += ClearOuts;
            _controller.UpdateCurrentScoreEvent += UpdateCurrentScoreLabel;
            _controller.UpdateBestPossibleEvent += UpdateBestPossibleLabel;
            _controller.UpdateOutsToBestEvent += UpdateOutsToBestLabel;
            _controller.UpdateBestChanceEvent += UpdateBestChanceLabel;
            _controller.UpdateHandsPlayedEvent += UpdateHandsPlayed;
            _controller.UpdatePreFlopRaiseEvent += UpdatePreFlopRaise;
            _controller.UpdateContBetsEvent += UpdateContBets;
        }

        private void LogIn()
        {
            LogInWindow window = new LogInWindow();
            window.ShowDialog();
            _controller.User = window.User;
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            _controller.StopSession();
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            _controller.Start();
        }

        public void UpdateTextBox(string text)
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                //textBox.Text = text;
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
            Dispatcher.BeginInvoke((Action) delegate
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
            Dispatcher.BeginInvoke((Action) delegate
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
            Dispatcher.BeginInvoke((Action) delegate
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
            Dispatcher.BeginInvoke((Action) delegate
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
            Dispatcher.BeginInvoke((Action) delegate
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
            Dispatcher.BeginInvoke((Action) delegate
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
            Dispatcher.BeginInvoke((Action) delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                BoardImageFive.Source = bitmap;
            });
        }

        public void UpdateRunnerRunnerImage(Image image, bool isRunner)
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.RunnerRunnerDictionary[isRunner].UriSource;
                bitmap.EndInit();
                image.Source = bitmap;
            });
        }

        public void UpdateCurrentScoreLabel(Pokerscore score)
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                YourScoreLabel.Text = score.ToNiceString();
            });
        }

        public void UpdateBestPossibleLabel(Pokerscore score)
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                BestPossibleLabel.Text = score.ToNiceString();
            });
        }

        public void UpdateOutsToBestLabel(PokerScoreOuts outs)
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                OutsToBestLabel.Text = outs.Outs.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateBestChanceLabel(PokerScoreOuts outs)
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                ChanceOfBestLabel.Text = outs.Percentage.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateHandsPlayed(int played)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                HandsPlayedLabel.Text = played.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdatePreFlopRaise(int pfr)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                PreFlopRaisesLabel.Text = pfr.ToString(CultureInfo.CurrentCulture);
            });
        }

        public void UpdateContBets(int cBets)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                ContBetsLabel.Text = cBets.ToString(CultureInfo.CurrentCulture);
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
                UpdateRunnerRunnerImage(PairRRImage, pairOuts.RunnerRunner);
                PairOutsLabel.Text = pairOuts.Outs.ToString(CultureInfo.CurrentCulture);
                PairPercentageLabel.Text = pairOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateTwoPairOuts(PokerScoreOuts twoPairOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                TwoPairProgressBar.Value = twoPairOuts.Percentage;
                TwoPairProgressBar.SetColour(twoPairOuts.Percentage);
                UpdateRunnerRunnerImage(TwoPairRRImage, twoPairOuts.RunnerRunner);
                TwoPairOutsLabel.Text = twoPairOuts.Outs.ToString(CultureInfo.CurrentCulture);
                TwoPairPercentageLabel.Text = twoPairOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateThreeOfAKindOuts(PokerScoreOuts tripsOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                TripsProgressBar.Value = tripsOuts.Percentage;
                TripsProgressBar.SetColour(tripsOuts.Percentage);
                UpdateRunnerRunnerImage(TripsRRImage, tripsOuts.RunnerRunner);
                TripsOutsLabel.Text = tripsOuts.Outs.ToString(CultureInfo.CurrentCulture);
                TripsrPercentageLabel.Text = tripsOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateStraightOuts(PokerScoreOuts straightOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                StraightProgressBar.Value = straightOuts.Percentage;
                StraightProgressBar.SetColour(straightOuts.Percentage);
                UpdateRunnerRunnerImage(StraightRRImage, straightOuts.RunnerRunner);
                StraightOutsLabel.Text = straightOuts.Outs.ToString(CultureInfo.CurrentCulture);
                StraightPercentageLabel.Text = straightOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateFlushOuts(PokerScoreOuts flushOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                FlushProgressBar.Value = flushOuts.Percentage;
                FlushProgressBar.SetColour(flushOuts.Percentage);
                UpdateRunnerRunnerImage(FlushRRImage, flushOuts.RunnerRunner);
                FlushOutsLabel.Text = flushOuts.Outs.ToString(CultureInfo.CurrentCulture);
                FlushPercentageLabel.Text = flushOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateFourOfAKindOuts(PokerScoreOuts quadOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                QuadsProgressBar.Value = quadOuts.Percentage;
                QuadsProgressBar.SetColour(quadOuts.Percentage);
                UpdateRunnerRunnerImage(QuadsRRImage, quadOuts.RunnerRunner);
                QuadsOutsLabel.Text = quadOuts.Outs.ToString(CultureInfo.CurrentCulture);
                QuadsPercentageLabel.Text = quadOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateFullHouse(PokerScoreOuts fullHouseOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                FullHouseProgressBar.Value = fullHouseOuts.Percentage;
                FullHouseProgressBar.SetColour(fullHouseOuts.Percentage);
                UpdateRunnerRunnerImage(FullHouseRRImage, fullHouseOuts.RunnerRunner);
                FullHouseOutsLabel.Text = fullHouseOuts.Outs.ToString(CultureInfo.CurrentCulture);
                FullHousePercentageLabel.Text = fullHouseOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateStraightFlushOuts(PokerScoreOuts sFlushOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                SFlushProgressBar.Value = sFlushOuts.Percentage;
                SFlushProgressBar.SetColour(sFlushOuts.Percentage);
                UpdateRunnerRunnerImage(SFlushRRImage, sFlushOuts.RunnerRunner);
                SFlushOutsLabel.Text = sFlushOuts.Outs.ToString(CultureInfo.CurrentCulture);
                SFlushPercentageLabel.Text = sFlushOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }

        public void UpdateRoyalFlushOuts(PokerScoreOuts rFlushOuts)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                RFlushProgressBar.Value = rFlushOuts.Percentage;
                RFlushProgressBar.SetColour(rFlushOuts.Percentage);
                UpdateRunnerRunnerImage(RFlushRRImage, rFlushOuts.RunnerRunner);
                RFlushOutsLabel.Text = rFlushOuts.Outs.ToString(CultureInfo.CurrentCulture);
                RFlushPercentageLabel.Text = rFlushOuts.Percentage.ToString(CultureInfo.CurrentCulture) + "%";
            });
        }
    }
}