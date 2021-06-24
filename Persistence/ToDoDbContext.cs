using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Persistence
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> context) : base(context)
        {
        }

    }
}
