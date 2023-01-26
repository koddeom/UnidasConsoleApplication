using Console_TesteUnidas.Business.StringShuffle;
using Console_TesteUnidas.Business.StringShuffle.Interface;
using NSubstitute;

namespace Solution_TestUnidasTest.Tests
{
    [TestClass]
    public class ShuffleString_NSubtitleTest
    {
        private IShuffleString _shuffleString;
        private IReverseString _reverseString;

        [TestInitialize]
        public void TestInitialize()
        {
            //--------------------------------------------------------------------------------------
            // Este exemplo usa a Lib NSubtitle para carregar as classes com inje��o de dependencia
            // E simular classes injetadas na rotina principal
            //--------------------------------------------------------------------------------------
            //Conceito:
            //  O teste unit�rio deve ter uma unica preocupa��o:
            //  O funcionamento do c�digo  isolado. No caso ShuffleString injeta uma outra
            //  classe iReverseString, que n�o � o objeto de teste em quest�o, por isso ela
            //  n�o � chamada diretamente e apenas a sua sa�da esperada � que � simulada.
            //
            //  Isso garante que a l�gica do c�digo � testada independente de outros
            //  componentes  do sistema, que por sua vez devem ter seus pr�prios testes unitarios.
            //--------------------------------------------------------------------------------------

            //Uma simula��o de iReverseString Injetada � criada
            _reverseString = Substitute.For<IReverseString>();
            _shuffleString = new ShuffleString(_reverseString);
        }

        [TestMethod]
        public void Shuffle_WhenCalled_ReturnsExpectedString()
        {
            // Arrange
            var originalText = "HELLOWORLD";
            var chunkSize = 3;

            //O retorno esperado da Inje��o original de iReverseString � simulado aqui.
            _reverseString.Reverse(Arg.Any<string>())
                                      .Returns(x => new string(x.Arg<string>()
                                                                .Reverse()
                                                                .ToArray()));
            // Act

            //A Rotina que ser� efetivamente testada � chamada aqui e utilizar� a vers�o simulada
            // de IReserveString de forma transparente
            var result = _shuffleString.Shuffle(originalText, chunkSize);

            // Assert
            Assert.AreEqual("D HEL WOL ORL", result);
        }
    }
}