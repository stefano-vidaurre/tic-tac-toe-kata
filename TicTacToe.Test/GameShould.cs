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
    public void DeclarePlayerOneTheWinnerByFirstRow()
    {
        _game.Play(Player.X, Tile.Northwest);
        _game.Play(Player.O, Tile.Southwest);
        _game.Play(Player.X, Tile.North);
        _game.Play(Player.O, Tile.South);
        _game.Play(Player.X, Tile.Northeast);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.X);
    }
    
    [Test]
    public void DeclarePlayerOneTheWinnerBySecondRow()
    {
        _game.Play(Player.X, Tile.West);
        _game.Play(Player.O, Tile.Southwest);
        _game.Play(Player.X, Tile.Middle);
        _game.Play(Player.O, Tile.South);
        _game.Play(Player.X, Tile.East);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.X);
    }
    
    [Test]
    public void DeclarePlayerOneTheWinnerByThirdRow()
    {
        _game.Play(Player.X, Tile.Southwest);
        _game.Play(Player.O, Tile.West);
        _game.Play(Player.X, Tile.South);
        _game.Play(Player.O, Tile.Middle);
        _game.Play(Player.X, Tile.Southeast);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.X);
    }
    
    [Test]
    public void DeclarePlayerTwoTheWinnerByFirstRow()
    {
        _game.Play(Player.X, Tile.Southeast);
        _game.Play(Player.O, Tile.Northwest);
        _game.Play(Player.X, Tile.West);
        _game.Play(Player.O, Tile.North);
        _game.Play(Player.X, Tile.Middle);
        _game.Play(Player.O, Tile.Northeast);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.O);
    }
    
    [Test]
    public void DeclarePlayerOneTheWinnerByFirstColumn()
    {
        _game.Play(Player.X, Tile.Northwest);
        _game.Play(Player.O, Tile.Southeast);
        _game.Play(Player.X, Tile.West);
        _game.Play(Player.O, Tile.South);
        _game.Play(Player.X, Tile.Southwest);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.X);
    }
    
    [Test]
    public void DeclarePlayerOneTheWinnerBySecondColumn()
    {
        _game.Play(Player.X, Tile.North);
        _game.Play(Player.O, Tile.Southeast);
        _game.Play(Player.X, Tile.Middle);
        _game.Play(Player.O, Tile.Southwest);
        _game.Play(Player.X, Tile.South);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.X);
    }
    
    [Test]
    public void DeclarePlayerOneTheWinnerByThirdColumn()
    {
        _game.Play(Player.X, Tile.Northeast);
        _game.Play(Player.O, Tile.South);
        _game.Play(Player.X, Tile.East);
        _game.Play(Player.O, Tile.Southwest);
        _game.Play(Player.X, Tile.Southeast);
        
        Player result = _game.GetWinner();
        result.Should().Be(Player.X);
    }
    // TODO: Implementar los tests para pintar tablero
}