using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Persistence;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext _dbContext;
        public ToDoController(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return Ok(_dbContext.ToDoItems);
        }

        [HttpPost("createItem")]
        public IActionResult AddToDoItem([FromBody] ToDoItem toDoItem)
        {
            toDoItem.DateCreated = DateTime.UtcNow;
            _dbContext.Add(toDoItem);
            _dbContext.SaveChanges();
            return Ok(toDoItem);
        }
        [HttpDelete("deleteItem/{id}")]
        public IActionResult DeleteToDoItem(long id)
        {
            var itemtoDelete = _dbContext.ToDoItems.Where(item => item.Id == id).First();
            _dbContext.Remove(itemtoDelete);
            _dbContext.SaveChanges();
            return Ok(itemtoDelete);
        }
    }
}
