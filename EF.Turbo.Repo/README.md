<h1>
<img src="https://im.ages.io/c3YfIintl2" width="50px">
EF Turpo Repo
</h1>

[![GitHub](https://img.shields.io/github/license/wilsonsergio2500/efTurbo?style=flat-square)](https://github.com/wilsonsergio2500/efTurbo/blob/master/LICENSE)
![Nuget](https://img.shields.io/nuget/v/EF.Turbo.Repo?style=flat-square)
[![Build](https://github.com/wilsonsergio2500/efTurbo/actions/workflows/build.yml/badge.svg)](https://github.com/wilsonsergio2500/efTurbo/actions/workflows/build.yml)

Simple and speedy but opinionated Repository pattern with query specification.

## The idea
I envision creating a pattern that while not befitting for every use case, could aid in introducing an elegant abstraction while boilerplating at lighting speed.

The note worthy word here is “abstraction.” Emphasizing that this not a principle or library that would likely be brought into every project. However, if utilizing Entity Framework as a ORM you may find this approach useful, and subscribe to this implementation for the sake of simplicity while adhering to its ingredients.



## Installation
```bash
dotnet add package EF.Turbo.Repo
```

## Usage
For a given Context
```c#
public class CustomerContext: DbContext
{
    readonly string SCHEMA = "Customer";
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
    {
    }
    public virtual DbSet<Entities.Contact> Contacts { get; set; } = null!;
  ....
}
```

We could bring about a repository declaration like such:
```c#
using Customer.Repo.Core.Entities;
using EF.Turbo.Repo.Core.Interfaces;
using EF.Turbo.Repo.Core.Repo;

namespace Customer.Repo.Core.Repos
{
    public class ContactRepo : BaseRepo<CustomerContext, Contact>, IBaseRepo<CustomerContext, Contact>
    {
        public ContactRepo(CustomerContext dbContext) : base(dbContext)
        {
        }
    }
}
```
and This is all would ever be needed :-) (If not extending the base repo, when seeking your own implementation) Subsequently, the repo could be inject as such
```c#
public static IServiceCollection AddCustomerRepository(this IServiceCollection services)
{
    services.AddScoped<IBaseRepo<CustomerContext, Contact>, ContactRepo>();
    ...
}
```
Any service could then consume the repository as such
```c#
public class ContactService : IContactService
{
	private readonly IBaseRepo<CustomerContext, Contact> _contactRepo;
	public ContactService(IBaseRepo<CustomerContext, Contact> contactRepo)
	{
		_contactRepo = contactRepo;
	}
	public async Task<Contact> GetContactByIdAsync(int id)
	{
		return await _contactRepo.GetByIdAsync(id);
	}
	...
}

```

## Query Specification
As stated the library exposes a Query Specification pattern created by [@ardalis](https://github.com/ardalis/Specification).
There are plenty of examples that could be found. However, In summary the specification allows for a query against the underlining Entity brought about by the generic type implementation.
```c#
using Ardalis.Specification;
using Customer.Repo.Core.Entities;

namespace Customer.Service.Core.Specs.Contacts
{
    public class ByEmail: Specification<Contact>
    {
        public ByEmail(string email)
        {
            Query.Where(contact => contact.EmailAddress == email);
        }
    }
    public class HasPhone: Specification<Contact>
    {
        public HasPhone()
        {
            Query.Where(contact => !string.IsNullOrEmpty(contact.PhoneNumber));
        }
    }
}
...
```
Hence as an example we could have the following:
```c#
public async Task<bool> HasAnyContactWithEmail(string Email)
{
    return await contactRepo.AnyAsync(new ByEmail(Email));
}

public async Task<int> NumberOfContactsWithPhoneNumbers()
{
    return await contactRepo.CountAsync(new HasPhone());
}
```