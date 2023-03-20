using community_institute_API.Data;
using Microsoft.EntityFrameworkCore;

namespace community_institute_API.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ComContext _dbContext;
        public Repository(ComContext context)
        {
            _dbContext = context;
        }
        
        

        public Task AddAsync(TEntity entity)
        {
            //add async to _dbContext and save changes async to _dbContext 
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChangesAsync();






        }

        public Task DeleteAsync(TEntity id)
        {
            _dbContext.Set<TEntity>().Remove(id);
            return _dbContext.SaveChangesAsync();
            
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            //return all async to _dbContext
            return _dbContext.Set<TEntity>().ToListAsync();
            
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"Entity with id {id} not found");
            }
            return entity;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChangesAsync();
            
        }
    }

}
