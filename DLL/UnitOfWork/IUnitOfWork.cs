using DLL.DBContext;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.UnitOfWork
{
   public interface IUnitOfWork
    {
        //All Repository Added Here

        IDepartmentRepository departmentRepository { get; }
        IStudentRepository studentRepository { get; }

        //All repository Ended here

        Task<bool> ApplicationSaveChangesAsync();
        void Dispose();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
            public readonly ApplicationDBContext _context;

            private bool disposed = false;

            private IDepartmentRepository _departmentRepository;

            private IStudentRepository _studentRepository;

            public UnitOfWork(ApplicationDBContext context)
            {
                _context = context;
            }

            public IDepartmentRepository departmentRepository =>
            _departmentRepository ??= new DepartmentRepository(_context);

            public IStudentRepository studentRepository =>
           _studentRepository ??= new StudentRepository(_context);

        public async Task<bool> ApplicationSaveChangesAsync()
            {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed )
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
