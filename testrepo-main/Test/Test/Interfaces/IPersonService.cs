using Test.DTOS;
using Test.Models;

namespace Test.Interfaces
{
    public interface IPersonService
    {
        Task<CreatePersonResponse> CreatePerson(CreatePersonRequest person);

        Task<GetPersonByIdResponse> GetPersonById(Guid id);

        Task<Person> UpdatePerson(Person person);

        Task<Person> DeletePerson(Guid id);

        Task<List<Person>> GetAllPersons();
    }
}
