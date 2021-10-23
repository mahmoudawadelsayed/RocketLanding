namespace RocketLandingEngine
{
    public interface IRocketLanding
    {
        //request landing permision
        string Permission(Position position);

        ////query it to see if it's on a good trajectory to land at any moment
        string Query(Position position);

    }
}