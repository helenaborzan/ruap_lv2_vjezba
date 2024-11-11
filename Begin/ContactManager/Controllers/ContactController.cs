using ContactManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Services;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            var httpContextAccessor = new HttpContextAccessor();
            this.contactRepository = new ContactRepository(httpContextAccessor);  
        }

        [HttpGet]
        public IEnumerable<Contact> GetAllContacts()
        {
            return this.contactRepository.GetAllContacts();
        }
    }
}
