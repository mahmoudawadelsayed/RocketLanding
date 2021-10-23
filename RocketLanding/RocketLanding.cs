using System;
using System.Collections.Generic;
using System.Linq;

namespace RocketLandingEngine
{
    public class RocketLanding : IRocketLanding
    {
        public ILandingArea Area { get; }

        //previous landing positions list
        public IList<Position> PreviousLandingPositions { get; private set; }

        public RocketLanding(ILandingArea landingArea)
        {
            Area = landingArea;
            PreviousLandingPositions = new List<Position>();
        }

        //Landing Positions Separation
        public int LandingPositionsSeparation { get; set; } = 1;

        //check if position out of platform
        private Boolean IsOutOfPlatform(Position position)
        {
            return !Area.Platform.IsPlatformHasPosition(position);

        }

        //request landing permision
        public string Permission(Position position)
        {
            string strResult = Query(position);
            if (strResult == Constants.OK_FOR_LANDING)
            {
                //save requested location
                SavePosition(position);
            }
            return strResult;
        }

        //save position in Previous Landing Positions List
        private void SavePosition(Position position)
        {
            PreviousLandingPositions.Add(position);
        }

        //asks for a position that has previously been checked by another rocket
        private bool IsPositionExist(Position position)
        {
            return PreviousLandingPositions.Contains(position);
        }

        //asks for a position that has previously been checked by another rocket or asks for a position that is located next to a position that has previouslybeen checked by another rocket
        private bool IsPositionExistWithLandingPositionsSeparation(Position position)
        {
            return PreviousLandingPositions.Any(prev => position.X >= prev.X - LandingPositionsSeparation && position.X <= prev.X + LandingPositionsSeparation &&
                                          position.Y >= prev.Y - LandingPositionsSeparation && position.Y <= prev.Y + LandingPositionsSeparation);
        }

        //query it to see if it's on a good trajectory to land at any moment
        public string Query(Position position)
        {
            //out of platform
            if (IsOutOfPlatform(position))
                return Constants.OUT_OF_PLATFORM;

            //if the rocket asks for a position that has previously been checked by another rocket => clash or
            //if the rocket asks for a position that is located next to a position that has previously been checked by another rocket => clash
            if (IsPositionExistWithLandingPositionsSeparation(position))
                return Constants.CLASH;


            //ok for landing
            return Constants.OK_FOR_LANDING;
        }

    }
}
