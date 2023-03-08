using HotChocolate.Authorization;
using PortalService.Models;

namespace PortalService
{
    public class Query
    {
        [Authorize(Policy = "isSuperUser", Apply = ApplyPolicy.BeforeResolver)]
        public List<Person> GetPersons()
        {
           return new List<Person> {
                new Person { Id = 1, Name = "Rui" },
                new Person { Id = 2, Name = "Maia" }
           };
        }
    }
}