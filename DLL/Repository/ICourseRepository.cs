using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.DBContext;
using DLL.Model;
using DLL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
       
    }
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDBContext context) : base(context)
        {
            
        }
    }
}