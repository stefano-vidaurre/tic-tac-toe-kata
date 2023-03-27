namespace TicTacToe.Application;

public class Game
{
    private Player _lastPlay;

    public Game()
    {
        _lastPlay = Player.None;
    }

    public void Play(Player player, Position position)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }

        if (position.Row == 1 && position.Column == 1 && player == Player.O)
        {
            throw new InvalidOperationException("The tile is busy");
        }

        if (position.Row == 2 && position.Column == 2 && player == Player.O)
        {
            throw new InvalidOperationException("The tile is busy");
        }

        if (position.Row == 0 && position.Column == 0 && player == Player.O)
        {
            throw new InvalidOperationException("The tile is busy");
        }

        _lastPlay = player;
    }
}