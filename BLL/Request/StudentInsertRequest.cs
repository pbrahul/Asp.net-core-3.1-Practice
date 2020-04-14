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
    public class StudentInsertRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string RollNo { get; set; }
        public int DeptId { get; set; }

    }

    public class StudentInsertValidator : AbstractValidator<StudentInsertRequest>
    {
        private readonly IServiceProvider _serviceProvider;

        public StudentInsertValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            RuleFor(x => x.RollNo).NotEmpty().NotNull().MustAsync(CodeExists).WithMessage("Roll Aleady exits.");
            RuleFor(x => x.Email).NotEmpty().NotNull().MustAsync(EmailExists).WithMessage("Name Aleady exits.");
            RuleFor(x => x.DeptId).NotNull().NotEmpty().MustAsync(DepartmentExists).WithMessage("Department ID Not exits");

        }
        private async Task<Boolean> EmailExists(string email, CancellationToken arg2)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return true;
            }
            var studentservice = _serviceProvider.GetRequiredService<IStudentService>();
            return !await studentservice.IsEmailExist(email);
        }

        private async Task<Boolean> CodeExists(string rollNo, CancellationToken arg2)
        {
            if (string.IsNullOrWhiteSpace(rollNo))
            {
                return true;
            }
            var studentService = _serviceProvider.GetRequiredService<IStudentService>();

            return !await studentService.IsRollNoExist(rollNo);
        }

        private async Task<Boolean> DepartmentExists(int deptId, CancellationToken arg2)
        {
            if (deptId == null)
            {
                return false;
            }
            var studentService = _serviceProvider.GetRequiredService<IStudentService>();

            return !await studentService.IsDepartmentExist(deptId);
        }

        public class StudentUpdateRequestValidator : AbstractValidator<StudentUpdateRequest>
        {
            private readonly IServiceProvider _serviceProvider;

            public StudentUpdateRequestValidator(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
                RuleFor(x => x.RollNo).NotEmpty().NotNull().MustAsync(RollNoExists).WithMessage("Roll Aleady exits.");
                RuleFor((x => x.Name)).NotNull().NotEmpty();
                RuleFor((x => x.Email)).NotNull().NotEmpty().EmailAddress();
                RuleFor(x => x.DeptId).NotNull().NotEmpty().MustAsync(DepartmentExists).WithMessage("Department ID Not exits");

                //.Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage(("Invalid Email"));
            }

            private async Task<bool> RollNoExists(string rollNo, CancellationToken cancellationToken)
            {
                if (string.IsNullOrWhiteSpace(rollNo))
                {
                    return true;
                }
                var studentService = _serviceProvider.GetRequiredService<IStudentService>();

                return await studentService.IsRollNoExist(rollNo);
            }
            private async Task<Boolean> DepartmentExists(int deptId, CancellationToken arg2)
            {
                if (deptId == null)
                {
                    return false;
                }
                var studentService = _serviceProvider.GetRequiredService<IStudentService>();

                return !await studentService.IsDepartmentExist(deptId);
            }
        }

    }
}
