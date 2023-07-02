using Xunit;
using EF.Turbo.Repo.Core.Interfaces;
using Example.Repo.Core;
using Example.Repo.Core.Entity;
using Example.Repo.Integration.Helpers.Specs.Person;
using FluentAssertions;
using static Example.Repo.Integration.Initialize;

namespace Example.Repo.Integration.Tests
{
    public class PersonRepoTest
    {
        internal readonly IBaseRepo<ExampleDbContext, PersonEntity> repo;
        static PersonRepoTest() => Initialize.InitializeIoc();
        public PersonRepoTest()
        {
            repo = IoC.GetService<IBaseRepo<ExampleDbContext, PersonEntity>>();
        }

        [Fact]
        public async Task ShouldAddAsync()
        {
            PersonEntity person = await repo.AddAsync(new PersonEntity { Email = "test@test.com", FirstName = "test", LastName = "guy" });
            (await repo.GetByIdAsync(person.Id)).Should().NotBeNull();
        }
        [Fact]
        public async Task ShouldUpdateAsync() 
        {
            PersonEntity person = await repo.AddAsync(new PersonEntity { Email = "test@test.com", FirstName = "test", LastName = "guy" });
            (await repo.GetByIdAsync(person.Id)).Should().NotBeNull();

            person.LastName = "LastnameTest";
            await repo.UpdateAsync(person);
        }

        [Fact]
        public async Task ShouldListAsync()
        {
            PersonEntity person = await repo.AddAsync(new PersonEntity { Email = "test2@test.com", FirstName = "test2", LastName = "guy2" });
            person.Should().NotBeNull();

            (await repo.ListAsync()).Should().NotBeEmpty();

            (await repo.ListAsync(new ById(person.Id))).Should().NotBeEmpty();
        }

        [Fact]
        public async Task ShouldAnyAsync()
        {
            PersonEntity person = await repo.AddAsync(new PersonEntity { Email = "test3@test.com", FirstName = "test3", LastName = "guy3" });
            person.Should().NotBeNull();

            (await repo.AnyAsync()).Should().BeTrue();
            (await repo.AnyAsync(new ByEmail("test3@test.com"))).Should().BeTrue();
        }

        [Fact]
        public async Task ShouldCountAsync()
        {
            PersonEntity person = await repo.AddAsync(new PersonEntity { Email = "test4@test.com", FirstName = "test4", LastName = "guy4" });
            person.Should().NotBeNull();

            (await repo.CountAsync()).Should().BeGreaterThan(0);
            (await repo.CountAsync(new ByEmail("test4@test.com"))).Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task ShouldDeleteAsync()
        {
            PersonEntity person = await repo.AddAsync(new PersonEntity { Email = "delete@test.com", FirstName = "test", LastName = "guy" });
            person.Should().NotBeNull();

            await repo.DeleteAsync(person);
            (await repo.AnyAsync(new ByEmail("delete@test.com"))).Should().BeFalse();
        }


        
    }
}
