namespace UniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>Contains methods for working whit an Repository.</summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>Returns all items in the repository.</summary>
        /// <returns>all items <see cref="IEnumerable"/>.</returns>
        IEnumerable<T> GetAll();

        /// <summary>The get.</summary>
        /// <param name="id">The items id.</param>
        /// <returns>requested item <see cref="T"/>.</returns>
        T Get(int id);

        /// <summary>add items to repository.</summary>
        /// <param name="user">The item.</param>
        void Add(T user);
    }
}