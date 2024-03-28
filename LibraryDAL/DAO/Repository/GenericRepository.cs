using LibraryDAL.CostemException;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.Context;
using LibraryUtil.Models;
using MathNet.Numerics.Statistics.Mcmc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected LibraryDbContext dbContext;
        protected DbSet<T> dbSet;
        public GenericRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet= dbContext.Set<T>();
        }
        public virtual async Task<bool> Create(T entity)
        {
            var data = DataValidation(entity,"Enter the Valid user Information");
            await dbSet.AddAsync(data);
            return true;
        }

        public virtual async Task<bool> Delete(int entity)
        {
            if (entity < 0)
                throw new AppException("Enter the Valid ID");
            var data= await dbSet.FindAsync(entity);
            var dataexists = DataValidation(data,"Enter the Valid Book Id ");
            dbSet.Remove(dataexists);
            return true;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            if (id < 0)
                throw new AppException("Enter the Valid ID");
            var Detail = await dbSet.FindAsync(id);
            var data=DataValidation(Detail,"Detail is not Found ");
            return data;
        }

        public virtual async Task<bool> Update(T entity)
        {
            var data = DataValidation(entity,"The Data is not Updated");
             dbSet.Update(data);
            return true;
        }
        internal T DataValidation(T entity ,string message)
        {
            if (entity == null)
                throw new AppException(message);
            return entity;
        }
    }
}
