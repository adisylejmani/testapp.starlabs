using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Interfaces;
using Test.Models;

namespace Test.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Person> CreatePerson(Person person)
        {
           await _db.AddAsync(person);
           await _db.SaveChangesAsync();
           return person;
        }

        public async Task<Person> DeletePerson(Guid id)
        {
           var person = await GetPersonById(id);
           _db.Persons.Remove(person);
            return person;
           await _db.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllPersons()
        {
            var allPersons = await _db.Persons.ToListAsync();
            return allPersons;
        }

        public async Task<Person> GetPersonById(Guid id)
        {
           var person = await _db.Persons.FindAsync(id);
           if (person != null)
                return person;
            return null;
        }

        public async  Task<Person> UpdatePerson(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            _db.Update(person);
            await _db.SaveChangesAsync();
            return person;
        }
    }
}
