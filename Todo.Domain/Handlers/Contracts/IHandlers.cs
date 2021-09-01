
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;

namespace Todo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommands
    {
        ICommandResult Handle(T command);
    }
}