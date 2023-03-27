namespace TicTacToe.Application;

public class Game
{
    private Player _lastPlay;
    private IDictionary<Tile, Player> _tiles;

    public Game()
    {
        _lastPlay = Player.None;
        _tiles = new Dictionary<Tile, Player>();
    }

    public void Play(Player player, Tile tile)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }

        if (_tiles.ContainsKey(tile))
        {
            throw new InvalidOperationException("The tile is busy");
        }

        _lastPlay = player;
        _tiles.Add(tile, player);
    }
}