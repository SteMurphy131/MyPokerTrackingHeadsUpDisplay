using System;
using System.Windows;
using System.Windows.Media.Imaging;
using PokerStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public partial class MainWindow : Window
    {
        private readonly Controller _controller;
        private readonly MessageHandler _messageHandler = new MessageHandler();

        public MainWindow()
        {
            InitializeComponent();
            _controller = new Controller(this, _messageHandler);
        }

        public void UpdateTextBox(string text)
        {
            textBox.Text = text;
        }

        public void UpdateHoleOne(Card c)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
            bitmap.EndInit();
            holeImageOne.Source = bitmap;
        }

        public void UpdateHoleTwo(Card c)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
            bitmap.EndInit();
            holeImageTwo.Source = bitmap;
        }

        public void UpdateBoardOne(Card c)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
            bitmap.EndInit();
            boardImageOne.Source = bitmap;
        }

        public void UpdateBoardTwo(Card c)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
            bitmap.EndInit();
            boardImageTwo.Source = bitmap;
        }

        public void UpdateBoardThree(Card c)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
            bitmap.EndInit();
            boardImageThree.Source = bitmap;
        }

        public void UpdateBoardFour(Card c)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
            bitmap.EndInit();
            boardImageFour.Source = bitmap;
        }

        public void UpdateBoardFive(Card c)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = PokerImageHelper.CardImageDictionary[c.ToString()].UriSource;
            bitmap.EndInit();
            boardImageFive.Source = bitmap;
        }
    }
}
