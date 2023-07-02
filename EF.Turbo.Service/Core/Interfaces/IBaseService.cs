using Ardalis.Specification;
using EF.Turbo.Repo.Core.Entity;
using EF.Turbo.Service.Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EF.Turbo.Service.Core.Interfaces
{
    /// <summary></summary>
    /// <typeparam name="TDbContext">The Entity Framework DbContext</typeparam>
    /// <typeparam name="TEntity">The Entity Type</typeparam>
    /// <typeparam name="TDTO">The Dto that is connected to the Entity via autoMapper</typeparam>
    public interface IBaseService<TDbContext, TEntity, TDTO> where TDbContext: DbContext where TEntity : BaseEntity where TDTO: BaseDTO
    {
        /// <summary>
        /// Add the Element of <typeparamref name="TDTO"/>
        /// </summary>
        /// <param name="item">The Dto to add</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>The added entity</returns>
        Task<TDTO> AddAsync(TDTO item, CancellationToken cancellationToken = default);
        /// <summary>
        /// Add Elements of <typeparamref name="TDTO"/>
        /// </summary>
        /// <param name="items">The Dtos to add</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>The added entity</returns>
        Task<IEnumerable<TDTO>> AddRangeAsync(IEnumerable<TDTO> items, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update and Element of <typeparamref name="TDTO"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>The added entity</returns>
        Task<TDTO?> UpdateAsync(TDTO item, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update Elements of <typeparamref name="TDTO"/>
        /// </summary>
        /// <param name="items"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>The added entity</returns>
        Task UpdateRangeAsync(IEnumerable<TDTO> items, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete an Element of <typeparamref name="TDTO"/>
        /// </summary>
        /// <param name="item">The Item to Delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        Task DeleteAsync(TDTO item, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete an Element of <typeparamref name="TDTO"/> by Id
        /// </summary>
        /// <param name="id">The Id of the item to delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete Elements of <typeparamref name="TDTO"/>
        /// </summary>
        /// <param name="items">The items to delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        Task DeleteRangeAsync(IEnumerable<TDTO> items, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get itesm of type <typeparamref name="TDTO"/> by Id
        /// </summary>
        /// <param name="id">The Id of item</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        Task<TDTO?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns the first element of a sequence of <typeparamref name="TDTO"/> that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// </returns>
        Task<TDTO?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns the first element of a sequence of <typeparamref name="TDTO"/> that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="TResult" />, or <see langword="null"/>.
        /// </returns>
        Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns the only element of a sequence of <typeparamref name="TDTO"/> that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// </returns>
        Task<TDTO?> SingleOrDefaultAsync(ISingleResultSpecification<TEntity> specification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns the only element of a sequence of <typeparamref name="TDTO"/> that satisfies a specified condition or a default value if no such element is found.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <typeparamref name="TResult" />, or <see langword="null"/>.
        /// </returns>
        Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Finds all entities of <typeparamref name="TDTO" /> from the database.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{TDTO}" /> that contains elements from the input sequence.
        /// </returns>
        Task<List<TDTO>> ListAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Finds all entities of <typeparamref name="TDTO" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{TDTO}" /> that contains elements from the input sequence.
        /// </returns>
        Task<List<TDTO>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Finds all entities of <typeparamref name="T" />, that matches the encapsulated query logic of the
        /// <paramref name="specification"/>, from the database.
        /// <para>
        /// Projects each entity into a new form, being <typeparamref name="TResult" />.
        /// </para>
        /// </summary>
        /// <typeparam name="TResult">The type of the value returned by the projection.</typeparam>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="List{TResult}" /> that contains elements from the input sequence.
        Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns a number that represents how many entities satisfy the encapsulated query logic
        /// of the <paramref name="specification"/>.
        /// </summary>
        /// <param name="specification">The encapsulated query logic.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the
        /// number of elements in the input sequence.
        /// </returns>
        Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns the total number of records.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the
        /// number of elements in the input sequence.
        /// </returns>
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Returns a boolean whether any entity exists or not.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains true if the 
        /// source sequence contains any elements; otherwise, false.
        /// </returns>
        Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);


    }
}
