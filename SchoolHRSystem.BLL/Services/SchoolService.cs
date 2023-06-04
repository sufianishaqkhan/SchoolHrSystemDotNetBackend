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
    public class SchoolService
    {
        public SchoolService()
        {

        }

        public BaseResponse GetAllSchools()
        {
            BaseResponse response = new BaseResponse();
            List<SchoolModel> schoolListDTO = new List<SchoolModel>();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from s in _context.Schools
                                join e in _context.Employees on s.School_ID equals e.School_ID into school_employees
                                select new SchoolModel
                                {
                                    School_ID = s.School_ID,
                                    School_Name = s.School_Name,
                                    School_SEMIS_Code = s.School_SEMIS_Code,
                                    School_Level = s.School_Level,
                                    School_Gender = s.School_Gender,
                                    District = s.District,
                                    Longitude = s.Longitude,
                                    Latitude = s.Latitude,
                                    Is_Active = s.Is_Active,
                                    Created_By = s.Created_By,
                                    Created_Date = s.Created_Date,
                                    Modified_By = s.Modified_By,
                                    Modified_Date = s.Modified_Date,

                                    Employees_Count = school_employees.Count()
                                };

                    schoolListDTO = query.ToList();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
                response.Data = schoolListDTO;
                response.Total = schoolListDTO.Count;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "GetAllSchools>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse GetSchool(int schoolId)
        {
            BaseResponse response = new BaseResponse();
            SchoolModel schoolDTO = new SchoolModel();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from s in _context.Schools
                                join e in _context.Employees on s.School_ID equals e.School_ID into school_employees
                                where s.School_ID == schoolId
                                select new SchoolModel
                                {
                                    School_ID = s.School_ID,
                                    School_Name = s.School_Name,
                                    School_SEMIS_Code = s.School_SEMIS_Code,
                                    School_Level = s.School_Level,
                                    School_Gender = s.School_Gender,
                                    District = s.District,
                                    Longitude = s.Longitude,
                                    Latitude = s.Latitude,
                                    Is_Active = s.Is_Active,
                                    Created_By = s.Created_By,
                                    Created_Date = s.Created_Date,
                                    Modified_By = s.Modified_By,
                                    Modified_Date = s.Modified_Date,

                                    Employees_Count = school_employees.Count()
                                };

                    schoolDTO = query.FirstOrDefault();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
                response.Data = schoolDTO;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "GetSchool>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse AddSchool(SchoolModel request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    Mapper.Initialize(c =>
                    {
                        c.CreateMap<SchoolModel, School>();
                    });
                    School school = Mapper.Map<SchoolModel, School>(request);

                    school.Created_By = 1;
                    school.Created_Date = DateTime.Now;

                    _context.Schools.Add(school);
                    _context.SaveChanges();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "AddSchool>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse UpdateSchool(SchoolModel request)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from s in _context.Schools
                                where s.School_ID == request.School_ID
                                select s;

                    School schoolEntity = query.FirstOrDefault();

                    if (schoolEntity != null)
                    {
                        Mapper.Initialize(c =>
                        {
                            c.CreateMap<SchoolModel, School>();
                        });
                        Mapper.Map(request, schoolEntity);

                        schoolEntity.Modified_By = 1;
                        schoolEntity.Modified_Date = DateTime.Now;

                        _context.SaveChanges();
                    }
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "UpdateSchool>> " + ex.Message;
            }

            return response;
        }

        public BaseResponse DeleteSchool(int schoolId)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                using (var _context = new SchoolHRDbEntities())
                {
                    var query = from s in _context.Schools
                                where s.School_ID == schoolId
                                select s;

                    _context.Schools.Remove(query.FirstOrDefault());
                    _context.SaveChanges();
                }

                response.Status = true;
                response.Message = "Request executed successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "DeleteSchool>> " + ex.Message;
            }

            return response;
        }
    }
}
