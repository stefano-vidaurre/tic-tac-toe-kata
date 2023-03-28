namespace TicTacToe.Application;

public class Tiles
{
    private readonly IDictionary<Tile, Player> _dictionary;
    
    public Tiles()
    {
        _dictionary = new Dictionary<Tile, Player>();
    }
    
    public void AddPlay(Player player, Tile tile)
    {
        if (_dictionary.ContainsKey(tile))
        {
            throw new InvalidOperationException("The tile is busy");
        }

        _dictionary.Add(tile, player);
    }

    public Player GetTileValue(Tile tile)
    {
        if (_dictionary.ContainsKey(tile))
        {
            return _dictionary[tile];
        }

        return Player.None;
    }
}