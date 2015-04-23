using System.Collections.Generic;
using WindsorWebApi.Model;

namespace WindsorWebApi.Storage
{
    public interface ITodoItemRepository
    {
        TodoItem[] GetTodoItems();
        bool SaveTodoItems(IEnumerable<TodoItem> items);
    }
}