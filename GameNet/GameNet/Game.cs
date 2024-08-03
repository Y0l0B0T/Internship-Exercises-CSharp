namespace Games;

public abstract class Game
{
    protected abstract string Name { get; set; }

    public abstract void Start();
}