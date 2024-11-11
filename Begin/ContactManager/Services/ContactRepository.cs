
using ContactManager.Models;
namespace ContactManager.Services
{
    public class ContactRepository
    {
        public IEnumerable<Contact> GetAllContacts()
        {
            return new List<Contact>
            {
                new Contact { Id = 1, Name = "Glenn Block" },
                new Contact { Id = 2, Name = "Dan Roth" }
            };
        }
    }
}
