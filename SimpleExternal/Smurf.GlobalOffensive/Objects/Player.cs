﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smurf.GlobalOffensive.Objects
{
    class Player : BaseEntity
    {
        public Player(IntPtr baseAddress) : base(baseAddress)
        {
        }
    }
}