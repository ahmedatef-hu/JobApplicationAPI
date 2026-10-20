using Microsoft.EntityFrameworkCore;
using Trial_A.Data;
using Trial_A.Repos.Interfaces;

namespace Trial_A.Repos.Implementations
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext context;
        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
