

using System;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public TodoItem(string title, string user, DateTime date)
        {
            Title = title;
            Done = false;
            Date = date;
            User = user;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }

        // Para autenticação no google
        public string User { get; private set; }

        // Marca a tarefa como feita
        public void MarkAsDone() => Done = true;

        // Marca a tarefa como inconcluida
        public void MarkAsUndone() => Done = false;

        // Atualiza o Titulo da tarefa.
        public void UpdateTitle(string title) => Title = title;
    }
}