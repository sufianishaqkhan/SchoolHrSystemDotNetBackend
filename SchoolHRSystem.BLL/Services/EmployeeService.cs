using SchoolHRSystem.BLL.Models;
using SchoolHRSystem.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SchoolHRSystem.BLL.Services
{
    public class EmployeeService
    {
        public EmployeeService()
        {

        }

        public BaseResponse GetAllEmployees()
        {
            BaseResponse response = new BaseResponse();
            List<EmployeeModel> employeeListDTO = new List<EmployeeModel>();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from e in _context.Employees
                                join s in _context.Schools on e.School_ID equals s.School_ID
                                select new EmployeeModel
                                {
                                    Employee_ID = e.Employee_ID,
                                    School_ID = e.School_ID,
                                    Employee_Code = e.Employee_Code,
                                    Employee_Name = e.Employee_Name,
                                    CNIC = e.CNIC,
                                    Email_Address = e.Email_Address,
                                    Mobile_No = e.Mobile_No,
                                    Address = e.Address,
                                    Gender = e.Gender,
                                    DateOfBirth = e.DateOfBirth,
                                    Is_Active = e.Is_Active,
                                    Created_By = e.Created_By,
                                    Created_Date = e.Created_Date,
                                    Modified_By = e.Modified_By,
                                    Modified_Date = e.Modified_Date,

                                    School_Name = s.School_Name,
                                };

                    employeeListDTO = query.ToList();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
                response.Data = employeeListDTO;
                response.Total = employeeListDTO.Count;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "GetAllEmployees>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse GetEmployee(int employeeId)
        {
            BaseResponse response = new BaseResponse();
            EmployeeModel employeeDTO = new EmployeeModel();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from e in _context.Employees
                                join s in _context.Schools on e.School_ID equals s.School_ID
                                where e.Employee_ID == employeeId
                                select new EmployeeModel
                                {
                                    Employee_ID = e.Employee_ID,
                                    School_ID = e.School_ID,
                                    Employee_Code = e.Employee_Code,
                                    Employee_Name = e.Employee_Name,
                                    CNIC = e.CNIC,
                                    Email_Address = e.Email_Address,
                                    Mobile_No = e.Mobile_No,
                                    Address = e.Address,
                                    Gender = e.Gender,
                                    DateOfBirth = e.DateOfBirth,
                                    Is_Active = e.Is_Active,
                                    Created_By = e.Created_By,
                                    Created_Date = e.Created_Date,
                                    Modified_By = e.Modified_By,
                                    Modified_Date = e.Modified_Date,

                                    School_Name = s.School_Name,
                                };

                    employeeDTO = query.FirstOrDefault();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
                response.Data = employeeDTO;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "GetEmployee>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse AddEmployee(EmployeeModel request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    Mapper.Initialize(c =>
                    {
                        c.CreateMap<EmployeeModel, Employee>();
                    });
                    Employee employee = Mapper.Map<EmployeeModel, Employee>(request);

                    employee.Created_By = 1;
                    employee.Created_Date = DateTime.Now;

                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "AddEmployee>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse UpdateEmployee(EmployeeModel request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from e in _context.Employees
                                where e.Employee_ID == request.Employee_ID
                                select e;

                    Employee employeeEntity = query.FirstOrDefault();

                    if (employeeEntity != null)
                    {
                        Mapper.Initialize(c =>
                        {
                            c.CreateMap<EmployeeModel, Employee>();
                        });
                        Mapper.Map(request, employeeEntity);

                        employeeEntity.Modified_By = 1;
                        employeeEntity.Modified_Date = DateTime.Now;

                        _context.SaveChanges();
                    }
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "UpdateEmployee>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse DeleteEmployee(int employeeId)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from e in _context.Employees
                                where e.Employee_ID == employeeId
                                select e;

                    _context.Employees.Remove(query.FirstOrDefault());
                    _context.SaveChanges();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "DeleteEmployee>> " + ex.Message;
            }

            return response;
        }
    }
}
