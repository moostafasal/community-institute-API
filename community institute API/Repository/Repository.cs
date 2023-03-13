//using community_institute_API.Data;
//using Microsoft.EntityFrameworkCore;

//namespace community_institute_API.Repository
//{
//    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//    {
//        private readonly ComContext _dbContext;

//        public Repository(ComContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<TEntity> GetByIdAsync(int id)
//        {
//            return await _dbContext.FindAsync(id);
//        }

//        public async Task<List<TEntity>> GetAllAsync()
//        {
//            return await _dbSet.ToListAsync();
//        }

//        public async Task AddAsync(TEntity entity)
//        {
//            await _dbSet.AddAsync(entity);
//        }

//        public void Update(TEntity entity)
//        {
//            _dbSet.Update(entity);
//        }

//        public void Delete(TEntity entity)
//        {
//            _dbSet.Remove(entity);
//        }

//        Task<IEnumerable<TEntity>> IRepository<TEntity>.GetAllAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdateAsync(TEntity entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteAsync(int id)
//        {
//            throw new NotImplementedException();
//        }
//    }

//}
