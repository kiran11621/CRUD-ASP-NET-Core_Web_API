﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApp.Models
{
    public class DAL
    {
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();

            SqlDataAdapter da = new SqlDataAdapter("Select * From tblCrudNetCore", connection);
            DataTable dt = new DataTable();
            List<Employee> lstEmployees = new List<Employee>();
            da.Fill(dt);

            if (dt.Rows.Count > 0 )
            {
                for (int i =0; i<dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);

                    lstEmployees.Add(employee);
                }
            }

            if (lstEmployees.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listEmployee = lstEmployees;
            } 
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listEmployee = null;
            }

            return response;
        }

        public Response GetAllEmployeesById(SqlConnection connection, int Id)
        {
            Response response = new Response();

            SqlDataAdapter da = new SqlDataAdapter("Select * From tblCrudNetCore Where ID = '"+Id+"' and IsActive = 1", connection);
            DataTable dt = new DataTable();
            Employee Employees= new Employee();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.Employee = employee;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.Employee = null;
            }

            return response;
        }

        public Response AddEmployees(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("insert into tblCrudNetCore (Name, Email, IsActive, CreatedOn) Values('"+employee.Name+"', '"+employee.Email+"', '"+employee.IsActive+"', GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Added Succesfully";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data inserted";
            }

            return response;
        }

        public Response UpdateEmployees(SqlConnection connection, Employee employee)
        {
            Response response = new Response();

            SqlCommand cmd = new SqlCommand("update tblCrudNetCore set Name='" + employee.Name + "', Email='" + employee.Email + "' where Id = '" + employee.Id + "' ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Updated Succesfully";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data updated";
            }

            return response;
        }

        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("Delete from tblCrudNetCore where Id = '" + id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee deleted ";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Employee not deleted ";
            }

            return response;
        }
    }
}
