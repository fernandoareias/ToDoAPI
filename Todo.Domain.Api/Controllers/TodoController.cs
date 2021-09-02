
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            return repository.GetAll("bobson");
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone("bobson");
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("bobson", System.DateTime.Now.Date.AddDays(1), true);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("bobson", System.DateTime.Now.Date.AddDays(1), true);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("bobson", System.DateTime.Now.Date.AddDays(1), false);
        }


        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllUndone("bobson");
        }


        [Route("")]
        [HttpPost]
        public GenericCommandsResults Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "bobson";
            return (GenericCommandsResults)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandsResults Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "bobson2";
            return (GenericCommandsResults)handler.Handle(command);
        }


        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandsResults MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "bobson2";
            return (GenericCommandsResults)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandsResults MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "bobson2";
            return (GenericCommandsResults)handler.Handle(command);
        }
    }
}