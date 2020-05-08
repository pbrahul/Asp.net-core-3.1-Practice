using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.DBContext;
using DLL.Model;
using DLL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public interface ICourseEnrollRepository : IRepositoryBase<CourseStudent>
    {
       
    }
    public class CourseEnrollRepository : RepositoryBase<CourseStudent>, ICourseEnrollRepository
    {
        public CourseEnrollRepository(ApplicationDBContext context) : base(context)
        {
            
        }
    }
}