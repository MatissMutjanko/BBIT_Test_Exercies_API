using BBIT_Test_Exercises_House.DbContext;
using System.Linq;

namespace BBIT_Test_Exercises_House.Storage
{
    public class EntityService<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;

        public EntityService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public virtual TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}