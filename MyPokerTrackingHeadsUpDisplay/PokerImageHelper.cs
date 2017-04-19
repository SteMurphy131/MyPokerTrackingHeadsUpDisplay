using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using PokerStructures;
using PokerStructures.Enums;

namespace MyPokerTrackingHeadsUpDisplay
{
    public class PokerImageHelper
    {
        public static Dictionary<bool, BitmapImage> RunnerRunnerDictionary = new Dictionary<bool, BitmapImage>
        {
            {true,  new BitmapImage(new Uri(@"../../Images/GreenTick.png", UriKind.Relative))},
            {false, new BitmapImage(new Uri(@"../../Images/RedX.png", UriKind.Relative)) }
        };

        public static Dictionary <string, BitmapImage> CardImageDictionary = new Dictionary<string, BitmapImage>
        {
            {"na", new BitmapImage(new Uri("../../Images/CardBackGreen.png", UriKind.Relative))},
            {new Card(Rank.None, Suit.None).ToString(), new BitmapImage(new Uri(@"../../Images/GreenBackground.png", UriKind.Relative))},
            {new Card(Rank.Ace, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/AceDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/TwoDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/ThreeDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/FourDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/FiveDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/SixDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/SevenDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/EightDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/NineDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/TenDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/JackDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/QueenDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Diamonds).ToString(), new BitmapImage(new Uri(@"../../Images/KingDiamonds.png", UriKind.Relative)) },
            {new Card(Rank.Ace, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/AceHearts.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/TwoHearts.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/ThreeHearts.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/FourHearts.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/FiveHearts.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/SixHearts.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/SevenHearts.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/EightHearts.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/NineHearts.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/TenHearts.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/JackHearts.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/QueenHearts.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Hearts).ToString(), new BitmapImage(new Uri(@"../../Images/KingHearts.png", UriKind.Relative)) },
            {new Card(Rank.Ace, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/AceClubs.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/TwoClubs.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/ThreeClubs.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/FourClubs.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/FiveClubs.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/SixClubs.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/SevenClubs.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/EightClubs.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/NineClubs.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/TenClubs.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/JackClubs.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/QueenClubs.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Clubs).ToString(), new BitmapImage(new Uri(@"../../Images/KingClubs.png", UriKind.Relative)) },
            {new Card(Rank.Ace, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/AceSpades.png", UriKind.Relative)) },
            {new Card(Rank.Two, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/TwoSpades.png", UriKind.Relative)) },
            {new Card(Rank.Three, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/ThreeSpades.png", UriKind.Relative)) },
            {new Card(Rank.Four, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/FourSpades.png", UriKind.Relative)) },
            {new Card(Rank.Five, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/FiveSpades.png", UriKind.Relative)) },
            {new Card(Rank.Six, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/SixSpades.png", UriKind.Relative)) },
            {new Card(Rank.Seven, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/SevenSpades.png", UriKind.Relative)) },
            {new Card(Rank.Eight, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/EightSpades.png", UriKind.Relative)) },
            {new Card(Rank.Nine, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/NineSpades.png", UriKind.Relative)) },
            {new Card(Rank.Ten, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/TenSpades.png", UriKind.Relative)) },
            {new Card(Rank.Jack, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/JackSpades.png", UriKind.Relative)) },
            {new Card(Rank.Queen, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/QueenSpades.png", UriKind.Relative)) },
            {new Card(Rank.King, Suit.Spades).ToString(), new BitmapImage(new Uri(@"../../Images/KingSpades.png", UriKind.Relative)) },
        };
    }
}
