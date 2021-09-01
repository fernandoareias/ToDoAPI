

using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{

    public class UpdateTodoCommand : Notifiable<Notification>, ICommands
    {
        public UpdateTodoCommand() { }
        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
           .Requires()
           .IsGreaterThan(Title, 3, "Title", "Title should have at least 3 chars")
           .IsGreaterThan(User, 3, "User", "User should have at least 3 chars")
      );
        }
    }
}