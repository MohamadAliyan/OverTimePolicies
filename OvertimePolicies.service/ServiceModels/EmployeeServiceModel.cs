using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OvertimePolicies.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OvertimePolicies.Service.ServiceModels
{
    public class EmployeeServiceModel : BaseServiceModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public DateTime Date { get; set; }
        public string DateStr { get; set; }
        public decimal OverTime { get; set; }
        public decimal FinalSalery { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OverTimeCalculator OverTimeCalculator { get; set; }



    }


    public enum OverTimeCalculator
    {
        CalcurlatorA,
        CalcurlatorB,
        CalcurlatorC
    }
}
