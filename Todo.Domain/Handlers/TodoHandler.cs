

using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{

    public class TodoHandler :
    Notifiable<Notification>, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
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

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid == false)
                return new GenericCommandsResults(false, "Ops, parece que sua tarefa está errada.", command.Notifications);


            // Recupe um ToDo do banco (reidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Altera o titulo
            todo.UpdateTitle(command.Title);

            // Salva no Banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandsResults(true, "Tarefa salva com sucesso.", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid == false)
                return new GenericCommandsResults(false, "Ops, parece que sua tarefa está errada.", command.Notifications);


            // Recupe um ToDo do banco (reidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Altera a tarefa para não feito
            todo.MarkAsUndone();

            // Salva no Banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandsResults(true, "Tarefa salva com sucesso.", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.IsValid == false)
                return new GenericCommandsResults(false, "Ops, parece que sua tarefa está errada.", command.Notifications);


            // Recupe um ToDo do banco (reidratação)
            var todo = _repository.GetById(command.Id, command.User);

            // Altera a tarefa para Feito
            todo.MarkAsDone();

            // Salva no Banco
            _repository.Update(todo);

            // Retorna o resultado
            return new GenericCommandsResults(true, "Tarefa salva com sucesso.", todo);
        }
    }

}