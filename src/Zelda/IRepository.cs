namespace Zelda {
    using System.Linq;

    /// <summary>
    /// Base interface for Add, Remove, Update and IQueryable support.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IQueryable<T> {
        /// <summary>
        /// Defines the "Add" operation to the underlying repository.
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Defines the "Remove" operation to the underlying repository.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Defines the "Update" operation to the underlying repository.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
