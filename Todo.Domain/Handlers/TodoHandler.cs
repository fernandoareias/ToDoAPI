

using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{

    public class TodoHandler : Notifiable<Notification>, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid == false)
                return new GenericCommandsResults(false, "Ops, parece que sua tarefa está errada.", command.Notifications);


            // Gera o ToDo Item 
            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salvar no Banco
            _repository.Create(todo);


            // Retorna o resultado
            return new GenericCommandsResults(true, "Tarefa salva com sucesso.", todo);

        }
    }

}