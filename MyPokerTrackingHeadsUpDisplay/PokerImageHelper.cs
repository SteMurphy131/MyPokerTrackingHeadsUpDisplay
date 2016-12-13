using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using PokerStructures;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class PokerImageHelper
    {
        public static Dictionary <string, BitmapImage> CardImageDictionary = new Dictionary<string, BitmapImage>
        {
            {"na", new BitmapImage(new Uri("../../Images/na.png", UriKind.Relative))},
            {new Card(Rank.Ace, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/ace_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/2_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/3_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/4_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/5_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/6_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/7_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/8_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/9_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/10_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/jack_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/queen_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/king_of_diamonds.png", UriKind.Relative)) },
            {new Card(Rank.Ace, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/ace_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/2_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/3_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/4_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/5_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/6_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/7_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/8_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/9_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/10_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/jack_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/queen_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/king_of_hearts.png", UriKind.Relative)) },
            {new Card(Rank.Ace, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/ace_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/2_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/3_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/4_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/5_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/6_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/7_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/8_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/9_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/10_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/jack_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/queen_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/king_of_clubs.png", UriKind.Relative)) },
            {new Card(Rank.Ace, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/ace_of_spades2.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/2_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/3_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/4_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/5_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/6_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/7_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/8_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/9_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/10_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/jack_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/queen_of_spades.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/king_of_spades.png", UriKind.Relative)) },
        };
    }
}
