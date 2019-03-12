using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.V2.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        /// <value>The order's unique identifier.</value>
        public long Id { get; set; }


        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        /// <value>The name of the task.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the completion status.
        /// </summary>
        /// <value>The completion status of the task.</value>
        public bool IsComplete { get; set; }
    }
}
