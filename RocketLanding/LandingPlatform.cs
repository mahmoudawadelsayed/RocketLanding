using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RocketLandingEngine
{
    public class LandingPlatform : ILandingPlatform
    {
        public Position StartPosition { get;}
        public Size SquareSize { get; private set; }

        public LandingPlatform(Position startPosition , Size squareSize)
        {
            //height should greater than zero
            if (squareSize.Height <= 0)
                throw new Exception(Constants.LENGTH_LESS_ZERO);

            //width should greate than zero
            if (squareSize.Width <= 0)
                throw new Exception(Constants.WIDTH_LESS_ZERO);

            StartPosition = startPosition;
            SquareSize = squareSize;
        }
        
        //check if position releated to the platform
        public bool IsPlatformHasPosition(Position positon)
        {
            if (
                (positon.X >= StartPosition.X) && (positon.X < StartPosition.X + SquareSize.Width)
                &&
                (positon.Y >= StartPosition.Y) && (positon.Y < StartPosition.Y + SquareSize.Height)
                )

                return true;

            else
                return false;

        }

        //for changing the platform size
        public void ChangeSize(Size squareSize)
        {
            SquareSize = squareSize;
        }
    }
}
