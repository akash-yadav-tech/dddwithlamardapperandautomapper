using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Infrastructure.Repository.Dapper.Models
{
    class Employee
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public int Age { get; set; }
    }
}
