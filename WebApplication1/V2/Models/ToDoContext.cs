using Microsoft.EntityFrameworkCore;

namespace WebApplication1.V2.Models
{
    public class TodoContext : DbContext
    {
        /// <summary>
        /// The TodoContext
        /// </summary>
        /// <param name="options"></param>
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the nam eof the TodoItems
        /// </summary>
        /// <value>DatabaseSet of TodoItems</value>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}