using AutoMapper;
using Moq;
using Test.DTOS;
using Test.Interfaces;
using Test.Models;
using Test.Services;
using Xunit;

namespace UnitTest
{
    public class PersonServiceUnitTest
    {
        private readonly Mock<IPersonRepository> _repostiorymock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly PersonService _sut;
        private static readonly CreatePersonRequest personCreateRequest = PersonTestHelper.CreatePersonRequest();
        private static readonly Person person = PersonTestHelper.PersonData(personCreateRequest);
        private static readonly CreatePersonResponse createPersonResponse = PersonTestHelper.PersonCreateResponse(person);

        public PersonServiceUnitTest()
        {
            _sut = new PersonService(_repostiorymock.Object, _mapperMock.Object);
        }

        [Fact]
        public void CreatePerson_ValidData_ReturnsPerson()
        {
            //Arrange
            _mapperMock.Setup(x => x.Map<Person>(It.IsAny<CreatePersonRequest>())).Returns(person);
            _repostiorymock.Setup(x => x.CreatePerson(It.IsAny<Person>())).ReturnsAsync(person);
            _mapperMock.Setup(x => x.Map<CreatePersonResponse>(It.IsAny<Person>())).Returns(createPersonResponse);

            //Act
            var response = _sut.CreatePerson(personCreateRequest);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(response.Result.FirstName, personCreateRequest.FirstName);
        }

        [Fact]
        public void CreatePerson_InValidData_ReturnsNull()
        {
            //Arrange
            _mapperMock.Setup(x => x.Map<Person>(It.IsAny<CreatePersonRequest>())).Returns(person);
            _repostiorymock.Setup(x => x.CreatePerson(It.IsAny<Person>())).ReturnsAsync(person);
            _mapperMock.Setup(x => x.Map<CreatePersonResponse>(It.IsAny<Person>())).Returns(createPersonResponse);

            //Act
            var response = _sut.CreatePerson((CreatePersonRequest)null);

            //Assert
            Assert.Null(response.Result);
        }
    }
}