

using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class GenericCommandsResults : ICommandResult
    {
        public GenericCommandsResults() { }
        public GenericCommandsResults(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}