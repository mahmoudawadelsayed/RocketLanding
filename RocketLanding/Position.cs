using System;
using System.Collections.Generic;
using System.Text;

namespace RocketLandingEngine
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x , int y)
        {
            //position factors cannot be negtive
            if ((x < 0) || (y<0))
                throw new Exception(Constants.POSITION_LESS_ZERO);
            X = x;
            Y = y;
        }
    }
}
