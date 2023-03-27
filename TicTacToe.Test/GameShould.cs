using FluentAssertions;
using TicTacToe.Application;

namespace TicTacToe.Test;
public class GameShould
{
    // TODO: Implementar los tests para añadir ficha
    [Test]
    public void ReportAErrorWhenStartingWithTheSecondPlayer()
    {
        Game game = new Game();
        Action action = () => game.Play("O");
        action.Should().Throw<InvalidOperationException>("Incorrect order of play");
    }
    
    // TODO: Implementar los tests para seleccionar posicion
    // TODO: Implementar los tests para comprobar si es juego terminado
    // TODO: Implementar los tests para pintar tablero
}