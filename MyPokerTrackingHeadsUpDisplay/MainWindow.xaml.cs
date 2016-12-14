using System;
using System.Windows;
using System.Windows.Media.Imaging;
using PokerStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public partial class MainWindow : Window
    {
        private readonly Controller _controller;

        public MainWindow()
        {
            InitializeComponent();
            _controller = Controller.Instance;
            _controller._mainWindow = this;

            if (Injector.InjectDll())
            {
                UpdateTextBox("Dll Injected");
            }
        }

        public void UpdateTextBox(string text)
        {
            this.Dispatcher.BeginInvoke((Action)delegate
            {
                textBox.Text = text;
            });
        }

        public void ClearBoardCards()
        {
            Dispatcher.BeginInvoke((Action) delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary["na"].UriSource;
                bitmap.EndInit();

                boardImageOne.Source = bitmap;
                boardImageTwo.Source = bitmap;
                boardImageThree.Source = bitmap;
                boardImageFour.Source = bitmap;
                boardImageFive.Source = bitmap;
            });
        }

        public void UpdateHoleOne(Card c)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
                bitmap.EndInit();
                holeImageOne.Source = bitmap;
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
                holeImageTwo.Source = bitmap; 
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
                boardImageOne.Source = bitmap;
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
                boardImageTwo.Source = bitmap;
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
                boardImageThree.Source = bitmap;
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
                boardImageFour.Source = bitmap;
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
                boardImageFive.Source = bitmap;
            });
        }
    }
}
