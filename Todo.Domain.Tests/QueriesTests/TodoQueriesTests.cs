using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _itens;
        public TodoQueriesTests()
        {
            Itens = new List<TodoItem>();
            Itens.Add(new TodoItem("Tarefa 1", "Bobson", System.DateTime.Now));
            Itens.Add(new TodoItem("Tarefa 2", "Bobson", System.DateTime.Now));

            Itens.Add(new TodoItem("Tarefa 4", "Gnarson", System.DateTime.Now));
            Itens.Add(new TodoItem("Tarefa 3", "Gnarson", System.DateTime.Now));
            Itens.Add(new TodoItem("Tarefa 5", "Gnarson", System.DateTime.Now));
        }

        public List<TodoItem> Itens { get => _itens; set => _itens = value; }

        [TestMethod]
        public void DadaAConsultaDeveRetornaTarefasApenasDoUsuarioBobson()
        {
            var result = Itens.AsQueryable().Where(TodoQueries.GetAll("Bobson"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
