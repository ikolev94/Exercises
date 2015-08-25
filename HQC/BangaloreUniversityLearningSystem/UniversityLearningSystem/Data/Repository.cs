namespace UniversityLearningSystem.Data
{
    using System;
    using System.Collections.Generic;

    using UniversityLearningSystem.Interfaces;

    /// <summary>The repository.</summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T>
    {
        /// <summary>The items.</summary>
        private readonly List<T> items;

        /// <summary>Initializes a new instance of the <see cref="Repository{T}"/> class.</summary>
        public Repository()
        {
            this.items = new List<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.items;
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                item = default(T);
            }

            return item;
        }

        public virtual void Add(T user)
        {
            this.items.Add(user);
        }
    }
}