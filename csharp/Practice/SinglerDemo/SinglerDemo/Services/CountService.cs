﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinglerDemo.Services
{
    public class CountService
    {
        private int _count;

        public int GetLatestCount()
        {
            return _count++;
        }
    }
}
