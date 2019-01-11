﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterServer.Entities
{
    public class Player
    {
        public virtual int id { get; set; }
        public virtual string username { get; set; }
        public virtual string password { get; set; }
        public virtual int winCount { get; set; }
        public virtual Game game { get; set; }
    }
}
