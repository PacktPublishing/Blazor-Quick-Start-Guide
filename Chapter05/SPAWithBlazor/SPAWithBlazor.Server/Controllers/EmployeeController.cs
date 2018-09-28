using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SPAWithBlazor.Server.DataAccess;
using SPAWithBlazor.Shared.Models;

namespace SPAWithBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        // DataAccessWithEF objemployee = new DataAccessWithEF();

        DataAccessWithADO objemployee = new DataAccessWithADO();

        [HttpGet]
        public List<Employee> Get()
        {
            return objemployee.GetAllEmployees();
        }
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            objemployee.AddEmployee(employee);
        }
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return objemployee.GetEmployeeData(id);
        }
        [HttpPut]
        public void Put([FromBody]Employee employee)
        {
            objemployee.UpdateEmployee(employee);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            objemployee.DeleteEmployee(id);
        }
        [HttpGet("GetCities")]
        public List<Cities> GetCities()
        {
            return objemployee.GetCityData();
        }
    }
}
