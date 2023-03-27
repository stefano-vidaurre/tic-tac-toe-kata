namespace TicTacToe.Application;

public enum Player
{
    None = 0,
    X,
    O
}

public class Game
{
    private Player _lastPlay;

    public Game()
    {
        _lastPlay = Player.None;
    }

    public void Play(Player player)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }

        _lastPlay = player;
    }
}