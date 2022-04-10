using AutoMapper;
using Test.DTOS;
using Test.Interfaces;
using Test.Models;

namespace Test.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreatePersonResponse> CreatePerson(CreatePersonRequest request)
        {
            if(request == null)
            {
                return null;
            }
            var person = _mapper.Map<Person>(request);

            var personCreated = await _repository.CreatePerson(person);

            return _mapper.Map<CreatePersonResponse>(personCreated);
        }

        public async Task<Person> DeletePerson(Guid id)
        {
            return await _repository.DeletePerson(id);

        }

        public async Task<List<Person>> GetAllPersons()
        {
            var personList = await _repository.GetAllPersons();
            return personList;
        }

        public async Task<GetPersonByIdResponse> GetPersonById(Guid id)
        {
            var person = await _repository.GetPersonById(id);
            return _mapper.Map<GetPersonByIdResponse>(person);
        }

        public async Task<Person> UpdatePerson(Person person)
        {
           return await _repository.UpdatePerson(person);
           
        }

    }
}
