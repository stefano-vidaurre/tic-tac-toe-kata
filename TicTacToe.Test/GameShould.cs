using FluentAssertions;
using TicTacToe.Application;

namespace TicTacToe.Test;
public class GameShould
{
    // TODO: Implementar los tests para añadir ficha
    [Test]
    public void ReportAnErrorWhenStartingWithTheSecondPlayer()
    {
        Game game = new Game();
        Action action = () => game.Play("O");
        action.Should().Throw<InvalidOperationException>().WithMessage("Invalid starting game");
    }

    [Test]
    public void ReportAnErrorWhenAPlayerPlaysTwice()
    {
        Game game = new Game();
        game.Play("X");
        Action action = () => game.Play("X");
        action.Should().Throw<InvalidOperationException>().WithMessage("Invalid playing order");
    }
    
    // TODO: Implementar los tests para seleccionar posicion
    // TODO: Implementar los tests para comprobar si es juego terminado
    // TODO: Implementar los tests para pintar tablero
}