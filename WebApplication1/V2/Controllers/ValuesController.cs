using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.V2.Controllers
{
    /// <summary>
    /// Basic Values Controller v2.0/v3.0
    /// </summary>
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id">id to return</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value">value to post</param>
        /// <returns></returns>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id">id to overwrite</param>
        /// <param name="value">value to overwrite</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string[]), 204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return NoContent();
        }

        /// <summary>
        ///  DELETE api/values/5
        /// </summary>
        /// <param name="id">id to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            return Accepted();
        }
    }
}
