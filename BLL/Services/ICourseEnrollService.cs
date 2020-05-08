using BLL.Request;
using DLL.Model;
using DLL.Repository;
using DLL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface ICourseEnrollService
    {
        Task<CourseStudent> AddCourseEnrollAsync(CourseEnrollInsertRequest request);
        Task<List<CourseEnrollmentReport>> GetAllStudentCourseEnrollReportAsync();

    }

    public class CourseEnrollService : ICourseEnrollService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseEnrollService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        public async Task<CourseStudent> AddCourseEnrollAsync(CourseEnrollInsertRequest request)
        {

            CourseStudent courseEnroll = new CourseStudent()
            {
                StudentId = request.StudentID,
                CourseId = request.CourseID
            };
            //var query = await _unitOfWork.courseEnrollRepository.QueryAll().Where(x=>x.StudentId == request.StudentID).Where(x => x.CourseId == request.CourseID).ToListAsync();
            //if (query != null)
            //{
            //    throw new MyAppException("Student Alreary Entrolled On This Course");
            //}

            await _unitOfWork.courseEnrollRepository.CreateAsync(courseEnroll);
            if (await _unitOfWork.ApplicationSaveChangesAsync())
            {
                return courseEnroll;

            }
            throw new MyAppException("Something Went Wrong");
            
        }

        public async Task<List<CourseEnrollmentReport>> GetAllStudentCourseEnrollReportAsync()
        {
             var allStudent = await _unitOfWork.courseEnrollRepository.QueryAll().Include(x => x.Student).Include(x => x.Course).ToListAsync();
           
            var result = new List<CourseEnrollmentReport>();

            
            foreach (var studentEnroll in allStudent)
            {
                
                result.Add(new CourseEnrollmentReport()
                {
                    StudentName = studentEnroll.Student.Name,
                    StudentRollNo = studentEnroll.Student.RollNo,
                    StudentEmail=studentEnroll.Student.Email,
                    CourseCode = studentEnroll.Course.Code,
                    CourseName = studentEnroll.Course.Name
                });
            }

            return result;
        }
 
    }
}
