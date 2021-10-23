using NUnit.Framework;
using RocketLandingEngine;

namespace RocketLandingTest
{
    public class RocketLandingTests
    {

        private  IRocketLanding rocketLanding { get; set; }

        [SetUp]
        public void Setup()
        {
            //Create Landing Area
            var landingArea = new LandingArea(100, 100);

            //Create Landing Platform
            landingArea.AddPlatform(new LandingPlatform(new Position(5, 5), new System.Drawing.Size(10, 10)));

            //Create Rocket Landing Engine
            rocketLanding = new RocketLanding(landingArea);
        }

        [Test, Order(1)]
        public void OutOfPlatform()
        {
            //Query for Position(16, 15)
            var strResult = rocketLanding.Query(new Position(16, 15));
            Assert.AreEqual(Constants.OUT_OF_PLATFORM, strResult);

            //request landing permission for Position(16, 15)
            strResult = rocketLanding.Permission(new Position(16, 15));
            Assert.AreEqual(Constants.OUT_OF_PLATFORM, strResult);
        }

        [Test, Order(2)]
        public void OkForLanding()
        {
            //Query for Position(5, 5)
            var strResult = rocketLanding.Query(new Position(5, 5));
            Assert.AreEqual(Constants.OK_FOR_LANDING, strResult);

            //request landing permission for Position(5, 5)
            strResult = rocketLanding.Permission(new Position(5, 5));
            Assert.AreEqual(Constants.OK_FOR_LANDING, strResult);

            //request landing permission for Position(7, 7)
            strResult = rocketLanding.Permission(new Position(7, 7));
            Assert.AreEqual(Constants.OK_FOR_LANDING, strResult);
        }

        [Test, Order(3)]
        public void PreviouslyCheckedByAnotherRocket()
        {
            //request landing permission for Position(5, 5)
            var strResult = rocketLanding.Permission(new Position(5, 5));
            //request landing permission for Position(5, 5) again
            strResult = rocketLanding.Permission(new Position(5, 5));
            Assert.AreEqual(Constants.CLASH, strResult);

            //request landing permission for Position(7, 7)
            strResult = rocketLanding.Permission(new Position(7, 7));
            //request landing permission for Position(7, 7) again
            strResult = rocketLanding.Permission(new Position(7, 7));
            Assert.AreEqual(Constants.CLASH, strResult);
        }

        [Test, Order(4)]
        public void LocatedNextToPositionThatHasPreviouslyCheckedByAnotherRocket()
        {
            //request landing permission for Position(7, 7)
            var strResult = rocketLanding.Permission(new Position(7, 7));

            //request landing permission for Position(7, 8)
            strResult = rocketLanding.Permission(new Position(7, 8));
            Assert.AreEqual(Constants.CLASH, strResult);

            //request landing permission for Position(6, 7)
            strResult = rocketLanding.Permission(new Position(6, 7));
            Assert.AreEqual(Constants.CLASH, strResult);

            //request landing permission for Position(6, 6)
            strResult = rocketLanding.Permission(new Position(6, 6));
            Assert.AreEqual(Constants.CLASH, strResult);
        }

    }
}