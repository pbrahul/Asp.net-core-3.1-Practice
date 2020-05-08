using BLL.Request;
using DLL.Model;
using DLL.Repository;
using DLL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface ICourseService
    {
        Task<Course> AddCourseAsync(CourseInsertRequest request);
        Task<Course> FindACourseAsync(string code);
        Task<List<Course>> GetAllCourseAsync();

        Task<Course> DeleteACourseAsync(string code);
        Task<Course> UpdateCourseAsync(string code, CourseUpdateRequest aDepartment);

        Task<Boolean> IsNameExist(string name);
        Task<Boolean> IsCodeExist(string code);
        Task<Boolean> IsCourseExist(int courseId);

    }

    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Course> AddCourseAsync(CourseInsertRequest request)
        {
            Course course = new Course()
            {
                Name = request.Name,
                Code = request.Code
            };
            await _unitOfWork.courseRepository.CreateAsync(course);

            if (await _unitOfWork.ApplicationSaveChangesAsync())
            {
                return course;
            }

            throw new MyAppException("Something Went Wrong");
        }

        public async Task<Course> FindACourseAsync(string code)
        {
            var course = await _unitOfWork.courseRepository.GetAAsynce(x => x.Code == code);
            if (course == null)
            {
                throw new MyAppException("Course Not Found");
            }
            return course;
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            return await _unitOfWork.courseRepository.GetListAsynce();
        }

        public async Task<Course> DeleteACourseAsync(string code)
        {
            var course = await _unitOfWork.courseRepository.GetAAsynce(x => x.Code == code);
            if (course == null)
            {
                throw new MyAppException("Course Not Found");
            }
            _unitOfWork.courseRepository.DeleteAsync(course);

            if (await _unitOfWork.ApplicationSaveChangesAsync())
            {
                return course;
            }

            throw new MyAppException("Something Went Wrong");

        }

        public async Task<bool> IsCodeExist(string code)
        {
            var course = await _unitOfWork.courseRepository.GetAAsynce(x => x.Code == code);

            if (course != null)
            {
                return true;
            }
            return false;
            //return await _departmentRepository.IsCodeExist(code);

        }

        public async Task<bool> IsNameExist(string name)
        {
            var course = await _unitOfWork.courseRepository.GetAAsynce(x => x.Name == name);

            if (course != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IsCourseExist(int courseId)
        {
            var course = await _unitOfWork.courseRepository.GetAAsynce(x => x.CourseID == courseId);

            if (course != null)
            {
                return false;
            }
            return true;
        }

        public async Task<Course> UpdateCourseAsync(string code, CourseUpdateRequest aCourse)
        {
            var course = await _unitOfWork.courseRepository.GetAAsynce(x => x.Code == code);
            if (course == null)
            {
                throw new MyAppException("Course Not Found");
            }

            if (!string.IsNullOrWhiteSpace(aCourse.Code))
            {
                var isCodeExistAnotherCourse = await _unitOfWork.courseRepository.GetAAsynce(x => x.Code == aCourse.Code
                && x.CourseID != course.CourseID);
                if (isCodeExistAnotherCourse == null)
                {
                    course.Code = aCourse.Code;
                }
                else
                {
                    throw new MyAppException("Code Already Exists On different Course");
                }
            }
            if (!string.IsNullOrWhiteSpace(aCourse.Name))
            {
                var isNameExistAnotherCourse = await _unitOfWork.courseRepository.GetAAsynce(x => x.Name == aCourse.Name
                && x.CourseID != course.CourseID);
                if (isNameExistAnotherCourse == null)
                {
                    course.Name = aCourse.Name;
                }
                else
                {
                    throw new MyAppException("Name Already Exists On different Course");
                }
            }

            _unitOfWork.courseRepository.UpdateAsyc(course);

            if (await _unitOfWork.ApplicationSaveChangesAsync())
            {
                return course;
            }

            throw new MyAppException("Something Went Wrong");
        }

        
    }
}
