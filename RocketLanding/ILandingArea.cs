namespace RocketLandingEngine
{
    public interface ILandingArea
    {
        int Width { get; }
        int Height { get; }

        ILandingPlatform Platform { get;   }

        //Add Platform to the specific Landing Area
        void AddPlatform(ILandingPlatform platform);
    }
}