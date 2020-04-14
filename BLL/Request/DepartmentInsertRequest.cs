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
    public class DepartmentInsertRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

	public class DepartmentInsertValidator : AbstractValidator<DepartmentInsertRequest>
	{
		private readonly IServiceProvider _serviceProvider;

		public DepartmentInsertValidator(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			RuleFor(x => x.Code).NotNull().NotEmpty().MinimumLength(3).MaximumLength(10).MustAsync(CodeExists).WithMessage("Name Already Exists");
			RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).MustAsync(NameExists).WithMessage("Name Already Exists");
			
		}

		private async Task<Boolean> NameExists(string name, CancellationToken arg2)
		{
			if (string.IsNullOrWhiteSpace (name))
			{
				return true;
			}
			var departmentservice =  _serviceProvider.GetRequiredService <IDepartmentService>() ;
			return !await departmentservice.IsNameExist(name);
		}

		private async Task<Boolean> CodeExists(string code, CancellationToken arg2)
		{
			if (string.IsNullOrWhiteSpace (code))
			{
				return true;
			}
			var departmentservice = _serviceProvider.GetRequiredService<IDepartmentService>();

			return !await departmentservice.IsCodeExist(code);
		}
	}
}
