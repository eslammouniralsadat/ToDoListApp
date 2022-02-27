using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Infrastructure
{
    public class ToDoListContext:DbContext
    {
        public ToDoListContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
