using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OvertimePolicies.Service.Models
{

    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public DateTime Date { get; set; }
        public decimal OverTime { get; set; }
        public decimal FinalSalery { get; set; }





    }
}
