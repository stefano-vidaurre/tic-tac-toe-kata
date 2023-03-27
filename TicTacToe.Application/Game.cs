namespace TicTacToe.Application;

public class Game
{
    private string _lastPlay;

    public Game()
    {
        _lastPlay = string.Empty;
    }

    public void Play(string player)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        if (string.IsNullOrEmpty(_lastPlay) && player != "X")
        {
            throw new InvalidOperationException("Invalid starting game");
        }

        _lastPlay = player;
    }
}