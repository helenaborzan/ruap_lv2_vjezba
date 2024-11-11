using ContactManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Glenn Block" },
                new Contact { Id = 2, Name = "Dan Roth" }
            };

            return Ok(contacts);
        }
    }
}
