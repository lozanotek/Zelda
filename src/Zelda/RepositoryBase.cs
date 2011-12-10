namespace Zelda {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Base implementation for IRepository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class RepositoryBase<T> : IRepository<T> {
        /// <summary>
        /// Gets the associated IEnumerator with the underlying IQueryable implementation.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator<T> GetEnumerator() {
            return Linq().AsEnumerable().GetEnumerator();
        }

        /// <summary>
        /// Wrapper for IEnumerator<typeparamref name="T"/>.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the expression from the underlying IQueryable implementation.
        /// </summary>
        public virtual Expression Expression {
            get { return Linq().Expression; }
        }

        /// <summary>
        /// Gets the Type from the underlying IQueryable implementation.
        /// </summary>
        public virtual Type ElementType {
            get { return Linq().ElementType; }
        }

        /// <summary>
        /// Gets the <see cref="IQueryProvider"/> from the underlying IQueryable implementation.
        /// </summary>
        public virtual IQueryProvider Provider {
            get { return Linq().Provider; }
        }

        /// <summary>
        /// Abstract implementation of "Add".
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Add(T entity);

        /// <summary>
        /// Abstract implementation of "Remove".
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Remove(T entity);

        /// <summary>
        /// Abstract implementation of "Update".
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Update(T entity);

        /// <summary>
        /// Abstract implementation of "Linq".
        /// </summary>
        /// <returns></returns>
        public abstract IQueryable<T> Linq();
    }
}
