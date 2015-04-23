using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindsorWebApi.Model;

namespace WindsorWebApi.Storage
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private const string CacheKey = "TodoItemStore";

        public TodoItem[] GetTodoItems()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    ctx.Cache[CacheKey] = new[]
                    {
                        new TodoItem
                        {
                            Title = "Write Todo List",
                            Completed = false
                        }
                    };
                }
                return (TodoItem[])ctx.Cache[CacheKey];
            }

            return null;
        }

        public bool SaveTodoItems(IEnumerable<TodoItem> items)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    ctx.Cache[CacheKey] = items.ToArray();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}