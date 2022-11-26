using EmpDeptProject.DataAccess.Data;
using EmpDeptProject.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace EmpDeptProject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmpDeptDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(EmpDeptDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }



        public void Add(T entity)
        {
            _db.Add(entity);
            //throw new NotImplementedException();
            
        }



        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;



            return query.ToList();
            //throw new NotImplementedException();
        }



        //public T GetFirstOrDefault()
        //{
        //    throw new NotImplementedException();
        //}



        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
            //throw new NotImplementedException();
        }

        public T GetFirstOrDefault<T>(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            //throw new NotImplementedException();
        }



        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            //throw new NotImplementedException();
        }



        //public void RemoveRange(IEnumerable<T> entity)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
