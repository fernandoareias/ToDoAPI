using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _commandInvalid = new CreateTodoCommand("", "", System.DateTime.Now);
        private readonly CreateTodoCommand _commandValid = new CreateTodoCommand("Jogar Bola", "Bobson", System.DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        public void DadoUmCommandInvalidoDeveInterromperAExecucao()
        {

            var result = (GenericCommandsResults)_handler.Handle(_commandInvalid);
            Assert.AreEqual(false, result.Success);
        }


        [TestMethod]
        public void DadoUmCommandValidoDeveExecutar()
        {

            var result = (GenericCommandsResults)_handler.Handle(_commandValid);
            Assert.AreEqual(true, result.Success);
        }
    }
}
