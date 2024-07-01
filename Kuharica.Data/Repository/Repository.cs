using Microsoft.EntityFrameworkCore;

namespace kuharica.Data.Repository
{
	public class Repository<T> : IRepository<T>
		where T : class
	{
		protected readonly KuharicaContext _context;

		public Repository(KuharicaContext context)
		{
			_context = context;
		}

        /// <summary>
        /// Create
        /// </summary>
        public void Add(T entity)
		{
			_context.Add(entity);
		}

		/// <summary>
		/// Read
		/// </summary>
		public IQueryable<T> GetAll()
		{
			return _context.Set<T>().AsNoTracking();
		}

		/// <summary>
		/// Update
		/// </summary>
		public void Update(T entity)
		{
			_context.Update(entity);
		}

		/// <summary>
		/// Delete
		/// </summary>
		public void Delete(T entity)
		{
			_context.Remove(entity);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
