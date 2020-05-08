using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Request
{
    public class CourseEnrollInsertRequest
	{
        public int StudentID { get; set; }
        public int CourseID { get; set; }
    }

	public class CourseEnrollInsertValidator : AbstractValidator<CourseEnrollInsertRequest>
	{
		private readonly IServiceProvider _serviceProvider;

		public CourseEnrollInsertValidator(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			RuleFor(x => x.StudentID).NotNull().NotEmpty().MustAsync(StudentExists).WithMessage("Student Not Exits");
			RuleFor(x => x.CourseID).NotNull().NotEmpty().MustAsync(CourseExists).WithMessage("Course Not Exists");
			
		}

		private async Task<Boolean> StudentExists(int studentId, CancellationToken arg2)
		{
			if (studentId == null)
			{
				return false;
			}
			var studentService = _serviceProvider.GetRequiredService<IStudentService>();

			return !await studentService.IsStudentExist(studentId);
		}
		private async Task<Boolean> CourseExists(int courseId, CancellationToken arg2)
		{
			if (courseId == null)
			{
				return false;
			}
			var courseService = _serviceProvider.GetRequiredService<ICourseService>();

			return !await courseService.IsCourseExist(courseId);
		}


	}
}
