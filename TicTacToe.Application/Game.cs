namespace TicTacToe.Application;

public class Game
{
    private Player _lastPlay;

    public Game()
    {
        _lastPlay = Player.None;
    }

    public void Play(Player player, int row, int column)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }

        if (row == 1 && column == 1 && player == Player.O)
        {
            throw new InvalidOperationException("The tile is busy");
        }

        _lastPlay = player;
    }
}