﻿namespace TicTacToe.Application;

public class Game
{
    private Player _lastPlay;
    private readonly Board _board;

    public Game()
    {
        _lastPlay = Player.None;
        _board = new Board();
    }

    public void Play(Player player, Tile tile)
    {
        if (_lastPlay == Player.None && player != Player.X)
        {
            throw new InvalidOperationException("Invalid starting game");
        }
        
        UpdateLastPlay(player);
        _board.AddPlay(player, tile);
    }

    private void UpdateLastPlay(Player player)
    {
        if (_lastPlay == player)
        {
            throw new InvalidOperationException("Invalid playing order");
        }

        _lastPlay = player;
    }

    public Player GetWinner()
    {
        if (IsDraw())
        {
            return Player.Draw;
        }
        
        if (HasWon(Player.X))
        {
            return Player.X;
        }

        if (HasWon(Player.O))
        {
            return Player.O;
        }
        
        return Player.None;
    }

    private bool IsDraw()
    {
        return _board.Count() == 9;
    }

    private bool HasWon(Player player)
    {
        return HasWonByRow(player) 
               || HasWonByColumn(player)
               || HasWonByDiagonal(player) 
               || HasWonByInvertedDiagonal(player);
    }

    private bool HasWonByInvertedDiagonal(Player player)
    {
        return _board.GetTileValue(Tile.Northeast) == player
               && _board.GetTileValue(Tile.Middle) == player
               && _board.GetTileValue(Tile.Southwest) == player;
    }

    private bool HasWonByDiagonal(Player player)
    {
        return _board.GetTileValue(Tile.Northwest) == player
               && _board.GetTileValue(Tile.Middle) == player
               && _board.GetTileValue(Tile.Southeast) == player;
    }

    private bool HasWonByColumn(Player player)
    {
        return HasWonByFirstColumn(player) || HasWonBySecondColumn(player) || HasWonByThirdColumn(player);
    }

    private bool HasWonByThirdColumn(Player player)
    {
        return _board.GetTileValue(Tile.Northeast) == player
               && _board.GetTileValue(Tile.East) == player
               && _board.GetTileValue(Tile.Southeast) == player;
    }

    private bool HasWonBySecondColumn(Player player)
    {
        return _board.GetTileValue(Tile.North) == player
               && _board.GetTileValue(Tile.Middle) == player
               && _board.GetTileValue(Tile.South) == player;
    }

    private bool HasWonByFirstColumn(Player player)
    {
        return _board.GetTileValue(Tile.Northwest) == player
               && _board.GetTileValue(Tile.West) == player
               && _board.GetTileValue(Tile.Southwest) == player;
    }

    private bool HasWonByRow(Player player)
    {
        return HasWonByFirstRow(player) || HasWonBySecondRow(player) || HasWonByThirdRow(player);
    }

    private bool HasWonByThirdRow(Player player)
    {
        return _board.GetTileValue(Tile.Southwest) == player
               && _board.GetTileValue(Tile.South) == player
               && _board.GetTileValue(Tile.Southeast) == player;
    }

    private bool HasWonBySecondRow(Player player)
    {
        return _board.GetTileValue(Tile.West) == player
               && _board.GetTileValue(Tile.Middle) == player
               && _board.GetTileValue(Tile.East) == player;
    }

    private bool HasWonByFirstRow(Player player)
    {
        return _board.GetTileValue(Tile.Northwest) == player
               && _board.GetTileValue(Tile.North) == player
               && _board.GetTileValue(Tile.Northeast) == player;
    }
}