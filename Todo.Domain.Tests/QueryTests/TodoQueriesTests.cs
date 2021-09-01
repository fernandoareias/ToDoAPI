using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        
        [TestMethod]
        public void DadoUmNovoTodoOMesmoNaoPodeSerConcluido()
        {
            Assert.AreEqual(false, _todo.Done);
        }
    }
}
