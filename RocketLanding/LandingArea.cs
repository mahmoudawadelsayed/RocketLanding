using System;

namespace RocketLandingEngine
{
    public class LandingArea : ILandingArea
    {
        public int Width { get; }
        public int Height { get; }

        public ILandingPlatform Platform { get; private set; }

        public LandingArea(int width, int height)
        {
            Width = width;
            Height = height;

        }

        public LandingArea(int width, int height, ILandingPlatform platform)
        {
            if( height <=0)
                throw new Exception(Constants.LENGTH_LESS_ZERO);

            if (width <= 0)
                throw new Exception(Constants.WIDTH_LESS_ZERO);

            Width = width;
            Height = height;
            AddPlatform(platform);
        }

        private bool IsPlatformInsideArea(ILandingPlatform platform)
        {
            if (
                (platform.StartPosition.X >= 0) && (platform.StartPosition.X + platform.SquareSize.Width < Width)
                &&
                (platform.StartPosition.Y >= 0) && (platform.StartPosition.Y + platform.SquareSize.Height < Height)
                )

                return true;

            else
                return false;
        }

        //Add Platform to the spcific Landing Area
        public void AddPlatform(ILandingPlatform platform)
        {
            //check if the platform inside the area
            if (IsPlatformInsideArea( platform))
            {
                Platform = platform;
            }
            else //otherwise raise exception
            {
                throw new Exception(Constants.PLATFORM_OUTSIDE_AREA);
            }
            
        }

    }
}