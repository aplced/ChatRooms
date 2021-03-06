﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomsDataTypes
{
    public class Message : BaseEntity
    {
        public String Text
        {
            get;
            set;
        }

        public User User
        {
            get;
            set;
        }

        public Room Room
        {
            get;
            set;
        }
    }
}
