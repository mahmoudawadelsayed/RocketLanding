using System.Drawing;

namespace RocketLandingEngine
{
    public interface ILandingPlatform
    {

        Position StartPosition { get; }
        Size SquareSize { get;  }

        //check if position releated to the platform
        bool IsPlatformHasPosition(Position positon);

        //for changing the platform size
        public void ChangeSize(Size squareSize);



    }
}