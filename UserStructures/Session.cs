using System.Collections.Generic;
using PokerStructures;

namespace UserStructures
{
    public class Session
    {
        public int UserId { get; set; }

        public virtual User Owner { get; set; }

        public SessionStatistics Statistics { get; set; }
    }
}