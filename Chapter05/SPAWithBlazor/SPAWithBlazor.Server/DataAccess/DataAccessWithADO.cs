using SPAWithBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SPAWithBlazor.Server.DataAccess
{
    public class DataAccessWithADO
    {
        private string _connectionString = "Data Source=IN01N01079\\SQLEXPRESS;Initial Catalog=EmployeeDB;Persist Security Info=True;Integrated Security = true";

        public List<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();

            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("spGetEmployeeList", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                sda.Fill(dataset);
                connection.Close();

                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    Employee employee = new Employee();

                    employee.EmployeeId = Convert.ToInt32(dr["EmployeeID"]);
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.CityName = dr["CityName"].ToString();
                    employee.Designation = dr["Designation"].ToString();
                    employee.Gender = dr["Gender"].ToString();

                    lstemployee.Add(employee);
                }
            }
            catch
            {
                throw;
            }
            return lstemployee;
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("@CityName", employee.CityName);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("@CityName", employee.CityName);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployeeData(int id)
        {
            Employee employee = new Employee();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "SELECT * FROM Employee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.EmployeeName = rdr["EmployeeName"].ToString();
                        employee.CityName = rdr["CityName"].ToString();
                        employee.Designation = rdr["Designation"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                    }
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Cities> GetCityData()
        {
            List<Cities> lstCities = new List<Cities>();

            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("spGetCityList", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                sda.Fill(dataset);
                connection.Close();

                foreach (DataRow dr in dataset.Tables[0].Rows)
                {
                    Cities city = new Cities();

                    city.CityId = Convert.ToInt32(dr["CityId"]);
                    city.CityName = dr["CityName"].ToString();

                    lstCities.Add(city);
                }
                return lstCities;
            }
            catch
            {
                throw;
            }
        }
    }
}
