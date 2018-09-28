using System;
using System.Collections.Generic;

namespace SPAWithBlazor.Shared.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string CityName { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
    }
}
