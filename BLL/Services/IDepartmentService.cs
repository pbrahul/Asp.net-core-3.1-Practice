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
    public interface IDepartmentService
    {
        Task<Department> AddDepartmentAsync(DepartmentInsertRequest request);
        Task<Department> FindADepartmentAsync(string code);
        Task<List<Department>> GetAllDepartmentAsync();

        Task<Department> DeleteADepartmentAsync(string code);
        Task<Department> UpdateDepartmentAsync(string code, DepartmentUpdateRequest aDepartment);

        Task<Boolean> IsNameExist(string name);
        Task<Boolean> IsCodeExist(string code);

    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Department> AddDepartmentAsync(DepartmentInsertRequest request)
        {
            Department department = new Department()
            {
                DeptName = request.Name,
                Code = request.Code
            };
            await _unitOfWork.departmentRepository.CreateAsync(department);

            if (await _unitOfWork.ApplicationSaveChangesAsync())
            {
                return department;
            }

            throw new MyAppException("Something Went Wrong");
        }

        public async Task<Department> FindADepartmentAsync(string code)
        {
            var department = await _unitOfWork.departmentRepository.GetAAsynce(x => x.Code == code);
            if (department == null)
            {
                throw new MyAppException("Department Not Found");
            }
            return department;
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            return await _unitOfWork.departmentRepository.GetListAsynce();
        }

        public async Task<Department> DeleteADepartmentAsync(string code)
        {
            var department = await _unitOfWork.departmentRepository.GetAAsynce(x => x.Code == code);
            if (department == null)
            {
                throw new MyAppException("Department Not Found");
            }
            _unitOfWork.departmentRepository.DeleteAsync(department);

            if (await _unitOfWork.ApplicationSaveChangesAsync())
            {
                return department;
            }

            throw new MyAppException("Something Went Wrong");

        }

        public async Task<bool> IsCodeExist(string code)
        {
            var department = await _unitOfWork.departmentRepository.GetAAsynce(x => x.Code == code);

            if (department != null)
            {
                return true;
            }
            return false;
            //return await _departmentRepository.IsCodeExist(code);

        }

        public async Task<bool> IsNameExist(string name)
        {
            var department = await _unitOfWork.departmentRepository.GetAAsynce(x => x.DeptName == name);

            if (department != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Department> UpdateDepartmentAsync(string code, DepartmentUpdateRequest aDepartment)
        {
            var department = await _unitOfWork.departmentRepository.GetAAsynce(x => x.Code == code);
            if (department == null)
            {
                throw new MyAppException("Department Not Found");
            }

            if (!string.IsNullOrWhiteSpace(aDepartment.Code))
            {
                var isCodeExistAnotherDepartment = await _unitOfWork.departmentRepository.GetAAsynce(x => x.Code == aDepartment.Code
                && x.DeptId != department.DeptId);
                if (isCodeExistAnotherDepartment == null)
                {
                    department.Code = aDepartment.Code;
                }
                else
                {
                    throw new MyAppException("Code Already Exists On different Department");
                }
            }
            if (!string.IsNullOrWhiteSpace(aDepartment.Name))
            {
                var isNameExistAnotherDepartment = await _unitOfWork.departmentRepository.GetAAsynce(x => x.DeptName == aDepartment.Name
                && x.DeptId != department.DeptId);
                if (isNameExistAnotherDepartment == null)
                {
                    department.DeptName = aDepartment.Name;
                }
                else
                {
                    throw new MyAppException("Name Already Exists On different Department");
                }
            }

            _unitOfWork.departmentRepository.UpdateAsyc(department);

            if (await _unitOfWork.ApplicationSaveChangesAsync())
            {
                return department;
            }

            throw new MyAppException("Something Went Wrong");
        }
    }
}
