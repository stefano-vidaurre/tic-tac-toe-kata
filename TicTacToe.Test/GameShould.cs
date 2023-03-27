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
        Action action = () => _game.Play(Player.O, new Position(0, 0));
        action.Should().Throw<InvalidOperationException>().WithMessage("Invalid starting game");
    }

    [Test]
    public void ReportAnErrorWhenAPlayerPlaysTwice()
    {
        _game.Play(Player.X, new Position(0, 0));
        Action action = () => _game.Play(Player.X, new Position(1, 1));
        action.Should().Throw<InvalidOperationException>().WithMessage("Invalid playing order");
    }
    
    // TODO: Implementar los tests para seleccionar posicion
    [Test]
    public void ReportAnErrorWhenAPlayerPlaysInABusyTile()
    {
        _game.Play(Player.X, new Position(1, 1));
        Action action = () => _game.Play(Player.O, new Position(1, 1));
        action.Should().Throw<InvalidOperationException>().WithMessage("The tile is busy");
    }
    
    [Test]
    public void ReportAnErrorWhenAPlayerPlaysInOtherBusyTile()
    {
        _game.Play(Player.X, new Position(2, 2));
        Action action = () => _game.Play(Player.O, new Position(2, 2));
        action.Should().Throw<InvalidOperationException>().WithMessage("The tile is busy");
    }
    
    [Test]
    public void ReportAnErrorWhenAPlayerPlaysInOtherMoreBusyTile()
    {
        _game.Play(Player.X, new Position(0, 0));
        Action action = () => _game.Play(Player.O, new Position(0, 0));
        action.Should().Throw<InvalidOperationException>().WithMessage("The tile is busy");
    }
    
    // TODO: Implementar los tests para comprobar si es juego terminado
    // TODO: Implementar los tests para pintar tablero
}