using System;
using System.Collections.Generic;
using PokerStructures;

namespace UserStructures
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Username { get; set; }
        public SessionStatistics Statistics { get; set; }
        public DateTime Submitted { get; set; }

        public Session(){Statistics = new SessionStatistics();}
    }
}