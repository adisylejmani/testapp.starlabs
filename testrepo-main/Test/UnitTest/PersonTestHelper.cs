using Bogus;
using System;

using Test.DTOS;
using Test.Models;

namespace UnitTest
{
    public static class PersonTestHelper
    {
        public static Test.Models.Person PersonData(CreatePersonRequest personRequest)
        {
            return new Faker<Test.Models.Person>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.PersonalNumber, personRequest.PersonalNumber)
                .RuleFor(x => x.FirstName, personRequest.FirstName)
                .RuleFor(x => x.LastName, personRequest.LastName)
                .RuleFor(x => x.PhoneNumber, personRequest.PhoneNumber)
                .Generate();
        }

        public static CreatePersonResponse PersonCreateResponse(Test.Models.Person person)
        {
            return new CreatePersonResponse()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,

            };
        }
        public static CreatePersonRequest CreatePersonRequest()
        {
            return new Faker<CreatePersonRequest>()
                .RuleFor(x => x.LastName, "adi")
                .RuleFor(x => x.PersonalNumber, "adi")
                .RuleFor(x => x.FirstName, "adi")
                .RuleFor(x => x.PhoneNumber, "adi")
                .Generate();
        }


        //public static BetReadResponse BetReadResponseData(Bet bet)
        //{
        //    return new BetReadResponse()
        //    {
        //        Id = bet.Id,
        //        Amount = bet.Amount,
        //        LastUpdated = bet.LastUpdated
        //    };
        //}
    }
}
