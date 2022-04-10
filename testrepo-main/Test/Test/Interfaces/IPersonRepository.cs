using Test.Models;

namespace Test.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPersons();
        Task<Person> CreatePerson (Person person);

        Task<Person> GetPersonById(Guid id);

        Task<Person> UpdatePerson (Person person);

        Task<Person> DeletePerson (Guid id);
    }
}
