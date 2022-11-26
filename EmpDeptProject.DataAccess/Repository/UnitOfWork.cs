using EmpDeptProject.DataAccess.Data;
using EmpDeptProject.DataAccess.Repository.IRepository;
using EmpDeptProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDeptProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmpDeptDbContext _db;
        public UnitOfWork(EmpDeptDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
            Department = new DepartmentRepository(_db);
        }
        public IEmployeeRepository Employee { get; private set; }
        public IDepartmentRepository Department { get; private set; }

        // public ICategoryRepository CategoryRepository => throw new NotImplementedException();

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
