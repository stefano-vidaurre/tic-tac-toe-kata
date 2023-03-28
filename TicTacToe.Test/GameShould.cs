using FluentAssertions;
using TicTacToe.Application;

namespace TicTacToe.Test;
public class GameShould
{
    private Game _game;

    [SetUp]
    public void SetUp()
    {
        _game = new Game();
    }
    
    [Test]
    public void ReportAnErrorWhenStartingWithTheSecondPlayer()
    {
        Action action = () => _game.Play(Player.O, Tile.Middle);
        action.Should().Throw<InvalidOperationException>().WithMessage("Invalid starting game");
    }

    [Test]
    public void ReportAnErrorWhenAPlayerPlaysTwice()
    {
        _game.Play(Player.X, Tile.South);
        Action action = () => _game.Play(Player.X, Tile.Middle);
        action.Should().Throw<InvalidOperationException>().WithMessage("Invalid playing order");
    }
    
    [Test]
    public void ReportAnErrorWhenAPlayerPlaysInABusyTile()
    {
        _game.Play(Player.X, Tile.Middle);
        Action action = () => _game.Play(Player.O, Tile.Middle);
        action.Should().Throw<InvalidOperationException>().WithMessage("The tile is busy");
    }
    
    [Test]
    public void ReportAnErrorWhenAPlayerPlaysInOtherBusyTile()
    {
        _game.Play(Player.X, Tile.Southeast);
        Action action = () => _game.Play(Player.O, Tile.Southeast);
        action.Should().Throw<InvalidOperationException>().WithMessage("The tile is busy");
    }
    
    [Test]
    public void ReportAnErrorWhenAPlayerPlaysInOtherMoreBusyTile()
    {
        _game.Play(Player.X, Tile.Northwest);
        Action action = () => _game.Play(Player.O, Tile.Northwest);
        action.Should().Throw<InvalidOperationException>().WithMessage("The tile is busy");
    }
    
    // TODO: Implementar los tests para comprobar si es juego terminado
    
    [Test]
    public void DeclareNoWinnerWhenTheGameIsNotFinished()
    {
        Player result = _game.GetWinner();
        result.Should().Be(Player.None);
    }

    [Test]
    public void DeclarePlayerOneWinnerByFirstRow()
    {
        _game.Play(Player.X, Tile.Northwest);
        _game.Play(Player.O, Tile.Southwest);
        _game.Play(Player.X, Tile.North);
        _game.Play(Player.O, Tile.South);
        _game.Play(Player.X, Tile.Northeast);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.X);
    }
    // TODO: Implementar los tests para pintar tablero
}