using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {

        private readonly CreateTodoCommand _commandInvalid = new CreateTodoCommand("", "", System.DateTime.Now);
        private readonly CreateTodoCommand _commandValid = new CreateTodoCommand("Jogar Bola", "Bobson", System.DateTime.Now);

        public CreateTodoCommandTests()
        {
            _commandInvalid.Validate();
            _commandValid.Validate();
        }
        [TestMethod]
        public void DadoUmComandoInvalido()
        {
            Assert.AreEqual(false, _commandInvalid.IsValid);
        }

        [TestMethod]
        public void DadoUmComandoValido()
        {
            Assert.AreEqual(true, _commandValid.IsValid);
        }


    }
}
