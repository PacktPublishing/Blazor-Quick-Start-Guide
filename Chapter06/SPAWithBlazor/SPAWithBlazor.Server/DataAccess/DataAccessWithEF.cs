using Microsoft.EntityFrameworkCore;
using SPAWithBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPAWithBlazor.Server.DataAccess
{
    public class DataAccessWithEF
    {
        private EmployeeDBContext _employeeContext = new EmployeeDBContext();

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _employeeContext.Employee.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _employeeContext.Employee.Add(employee);
                _employeeContext.SaveChanges();
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
                _employeeContext.Entry(employee).State = EntityState.Modified;
                _employeeContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = _employeeContext.Employee.Find(id);
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
                Employee emp = _employeeContext.Employee.Find(id);
                _employeeContext.Employee.Remove(emp);
                _employeeContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Cities> GetCityData()
        {
            try
            {
                return _employeeContext.Cities.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
