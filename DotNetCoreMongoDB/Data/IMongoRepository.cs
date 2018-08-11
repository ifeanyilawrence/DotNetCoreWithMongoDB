using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotNetCoreMongoDB.Classes;

namespace DotNetCoreMongoDB.Data
{
    public interface IMongoRepository<T> where T : MongoEntity
    {
        IMongoDbContext Context { get; }
        IMongoQueryable<T> Table { get; }
        int Count { get; }
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Insert(IEnumerable<T> entities);
        Task InsertAsync(IEnumerable<T> entities);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Update(IEnumerable<T> entities);
        Task UpdateAsync(IEnumerable<T> entities);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Delete(IEnumerable<T> entities);
        Task DeleteAsync(IEnumerable<T> entities);
        T Find(object Id);
        Task<T> FindAsync(object Id);
        T Find(Expression<Func<T, bool>> filter);
        Task<T> FindAsync(Expression<Func<T, bool>> filter);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);
    }
}
