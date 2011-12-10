namespace Zelda {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Simple wrapper for an IList to an IRepository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ListRepository<T> : RepositoryBase<T> {
        protected IList<T> InternalList { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListRepository() : this(new List<T>()) {
        }

        /// <summary>
        /// Constructor with specified value.
        /// </summary>
        /// <param name="sourceList">Seed value for the repository.  If null, <see cref="ArgumentNullException"/> exception is throw.</param>
        public ListRepository(IList<T> sourceList) {
            if (sourceList == null) {
                throw new ArgumentNullException("sourceList");
            }

            InternalList = sourceList;
        }

        /// <summary>
        /// Adds <param name="entity"></param> to the underlying IList.
        /// </summary>
        /// <param name="entity"></param>
        public override void Add(T entity) {
            InternalList.Add(entity);
        }

        /// <summary>
        /// Removes <param name="entity"></param> to the underlying IList.
        /// </summary>
        /// <param name="entity"></param>
        public override void Remove(T entity) {
            InternalList.Remove(entity);
        }

        /// <summary>
        /// Updates <param name="entity"></param> to the underlying IList if found.
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(T entity) {
            int index = 0;

            for (int i = 0; i < InternalList.Count; i++) {
                var temp = InternalList[i];

                var defaultVal = default(T);
                if (defaultVal.Equals(temp)) continue;
                if (!temp.Equals(entity)) continue;
                
                index = i;
                break;
            }

            InternalList[index] = entity;
        }

        /// <summary>
        /// Wrapper for the IQueryable provider.
        /// </summary>
        /// <returns></returns>
        public override IQueryable<T> Linq() {
            return InternalList == null ? null : InternalList.AsQueryable();
        }
    }
}
