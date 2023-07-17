using CRUDApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetAllEmployees()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();

            DAL dal = new DAL();
            response = dal.GetAllEmployees(connection);

            return response;
        }


        [HttpGet]
        [Route("GetAllEmployeesById/{id}")]
        public Response GetAllEmployeesById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();

            DAL dal = new DAL();
            response = dal.GetAllEmployeesById(connection, id);

            return response;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee (Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddEmployees(connection, employee);

            return response;
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateEmployees(connection, employee);

            return response;
        }

        [HttpDelete] 
        [Route("DeleteEmployee/{id}")]

        public Response DeleteEmployee(int id)
        {

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteEmployee(connection, id);

            return response;
        }
    }
}
