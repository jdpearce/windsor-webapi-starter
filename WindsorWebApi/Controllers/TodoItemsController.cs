using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WindsorWebApi.Model;
using WindsorWebApi.Storage;

namespace WindsorWebApi.Controllers
{
    [AllowAnonymous]
    public class TodoItemsController : ApiController
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemsController(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("TodoItems")]
        public HttpResponseMessage CreateTodoItems(TodoItem[] items)
        {
            _repository.SaveTodoItems(items);
            var response = Request.CreateResponse(HttpStatusCode.Created, items);
            return response;
        }

        [HttpGet]
        [Route("TodoItems")]
        public IEnumerable<TodoItem> Get()
        {
            return _repository.GetTodoItems();
        }
    }
}