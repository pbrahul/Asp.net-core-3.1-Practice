using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using FluentValidation;
using BLL.Request;
using BLL.Services;

namespace BLL
{
    public class BLLDependency
    {
        public static void AllDependency(IServiceCollection services)
        {
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IValidator<DepartmentInsertRequest>, DepartmentInsertValidator>();
            services.AddTransient<IValidator<StudentInsertRequest>, StudentInsertValidator>();

        }
    }
}
