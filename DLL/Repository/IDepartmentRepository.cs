using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.DBContext;
using DLL.Model;
using DLL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public interface IDepartmentRepository :IRepositoryBase<Department>
    {
       
    }
    public class DepartmentRepository: RepositoryBase<Department>,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDBContext context) : base(context)
        {
            
        }
    }
}