using Microsoft.AspNetCore.Mvc;
using Test.DTOS;
using Test.Interfaces;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service; 
        }

        [HttpPost("/create")]
        public async Task<CreatePersonResponse> CreatePersonResponseAsync(CreatePersonRequest request)
        {
            var person = await _service.CreatePerson(request);
            return person;
        }

        [HttpGet]
        public async Task<List<Person>> GetPersonsAsync()
        {
            var person = await _service.GetAllPersons();
            return person;
        }

        [HttpPost("/{id}")]
        public async Task<Person> DeletePerson(Guid id)
        {
            var deletedPerson = await _service.DeletePerson(id);
            return deletedPerson;
        }
        
        [HttpGet("/getAll")]
        public async Task<List<Person>> Get()
        {
            return await _service.GetAllPersons();
        }

    }
}
