
using ContactManager.Models;
namespace ContactManager.Services
{
    public class ContactRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CacheKey = "ContactStore";
        public ContactRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            var ctx = _httpContextAccessor.HttpContext;

            if (ctx != null)
            {
               
                if (ctx.Items[CacheKey] == null)
                {
                    var contacts = new List<Contact>
                {
                    new Contact { Id = 1, Name = "Glenn Block" },
                    new Contact { Id = 2, Name = "Dan Roth" }
                };

                    ctx.Items[CacheKey] = contacts; 
                }
            }
        }
        public IEnumerable<Contact> GetAllContacts()
        {
            var ctx = _httpContextAccessor.HttpContext;

            if (ctx != null && ctx.Items.ContainsKey(CacheKey))
            {
                return (IEnumerable<Contact>)ctx.Items[CacheKey];
            }

            return new List<Contact>
            {
                new Contact { Id = 0, Name = "Placeholder" }
            };
        }
        public bool SaveContact(Contact contact)
        {
            var ctx = _httpContextAccessor.HttpContext;

            if (ctx != null)
            {
                try
                {
                    
                    if (ctx.Items.ContainsKey(CacheKey))
                    {
                        
                        var currentData = (List<Contact>)ctx.Items[CacheKey];

                       
                        currentData.Add(contact);

                       
                        ctx.Items[CacheKey] = currentData;

                        return true;
                    }
                    else
                    {
                    
                        var newData = new List<Contact> { contact };
                        ctx.Items[CacheKey] = newData;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}
