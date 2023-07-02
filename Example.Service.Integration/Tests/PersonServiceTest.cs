using Xunit;
using EF.Turbo.Service.Core.Interfaces;
using Example.Repo.Core;
using Example.Repo.Core.Entity;
using Example.Service.Core.DTOs;
using FluentAssertions;
using static Example.Service.Integration.Initialize;
using Example.Service.Integration.Helpers.Specs.Email;
using EF.Turbo.Repo.Core.Interfaces;

namespace Example.Service.Integration.Tests
{
    public class PersonServiceTest
    {
        internal readonly IBaseService<ExampleDbContext, PersonEntity, PersonDTO> personService;
        internal readonly IFireNdForget fireNdForgetFactory;
        static PersonServiceTest() => Initialize.InitializeIoc();
        public PersonServiceTest()
        {
            personService = IoC.GetService<IBaseService<ExampleDbContext, PersonEntity, PersonDTO>>();
            fireNdForgetFactory = IoC.GetService<IFireNdForget>();
        }

        [Fact]
        public async Task ShouldAddAsync()
        {
            PersonDTO person = await personService.AddAsync(new PersonDTO { Email = "test2@test.com", FirstName = "test2", LastName = "guy2" });
            person.Id.Should().NotBeNull();
            if(person.Id is int id)
            {
                (await personService.GetByIdAsync(id)).Should().NotBeNull();
            }
        }

        [Fact]
        public async Task ShouldUpdateAsync()
        {
            PersonDTO person = await personService.AddAsync(new PersonDTO { Email = "test@test.com", FirstName = "test", LastName = "guy" });
            person.Id.Should().NotBeNull();

            person.LastName = "LastnameTest";
            await personService.UpdateAsync(person);
            if (person.Id is int id)
            {
                PersonDTO? personsUpdated = await personService.GetByIdAsync(id);
                personsUpdated.Should().NotBeNull();
                personsUpdated?.LastName.Should().Be("LastnameTest");
            }
        }

        [Fact]
        public async Task ShouldListAsync()
        {
            PersonDTO person = await personService.AddAsync(new PersonDTO { Email = "test@test.com", FirstName = "test", LastName = "guy" });
            person.Should().NotBeNull();

            (await personService.ListAsync()).Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldCountAsync() 
        {
            PersonDTO person = await personService.AddAsync(new PersonDTO { Email = "test@test.com", FirstName = "test", LastName = "guy" });
            person.Should().NotBeNull();

            (await personService.CountAsync()).Should().BeGreaterThan(0);
            (await personService.CountAsync(new ByEmail("test@test.com"))).Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task ShouldAnyAsync()
        {
            PersonDTO person = await personService.AddAsync(new PersonDTO { Email = "test@test.com", FirstName = "test", LastName = "guy" });
            person.Should().NotBeNull();

            (await personService.AnyAsync(new ByEmail("test@test.com"))).Should().BeTrue();
        }

        [Fact]
        public async Task ShouldDeleteAsync()
        {
            PersonDTO person = await personService.AddAsync(new PersonDTO { Email = "test@deleted.com", FirstName = "test", LastName = "guy" });
            person.Should().NotBeNull();
            
            await personService.DeleteAsync(person);
            (await personService.AnyAsync(new ByEmail("test@deleted.com"))).Should().BeFalse();
        }

        [Fact]
        public async Task ShouldFireNdForget()
        {
            string email = "test@fireNdForget.com";

            fireNdForgetFactory.Execute<IBaseRepo<ExampleDbContext, PersonEntity>, ExampleDbContext, PersonEntity>(async repo =>
            {
                await repo.AddAsync(new PersonEntity { Email = email, FirstName = "test", LastName = "guy" });
            });

            await Task.Delay(1000);
            (await personService.AnyAsync(new ByEmail(email))).Should().BeTrue();

        }
    }
}
