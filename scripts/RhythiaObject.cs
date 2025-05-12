using Rhythia;

public abstract class RhythiaObject
{
    internal readonly RhythiaGame Game;

    public RhythiaObject(RhythiaGame game)
    {
        this.Game = game;
    }
}