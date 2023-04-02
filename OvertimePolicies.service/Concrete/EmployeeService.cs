using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OvertimePolicies.Service.Helper;
using OvertimePolicies.Service.Interfaces;
using OvertimePolicies.Service.Models;
using OvertimePolicies.Service.ServiceModels;

namespace OvertimePolicies.Service.Concrete
{
    public class EmployeeService : Service<Employee, EmployeeServiceModel>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public List<EmployeeServiceModel> GetRange(string dateFrom,string dateTo)
        {
          var list=  _employeeRepository.GetBy(p=>p.Date>= dateFrom. ConverToGregorianDate()&&p.Date<= dateTo.ConverToGregorianDate()).ToList();

            return list.Adapt<List<EmployeeServiceModel>>();
        }

        public override void Insert(EmployeeServiceModel serviceModel, int currentUserId)
        {

            var overTimeCalc = OverTimeCalc(serviceModel);
            var finalSalery = serviceModel.BasicSalary + serviceModel.Allowance + serviceModel.Transportation + overTimeCalc;
            serviceModel.FinalSalery = finalSalery;
            serviceModel.Date = serviceModel.DateStr.ConverToGregorianDate();
            base.Insert(serviceModel, currentUserId);
        }

        public override void Update(EmployeeServiceModel serviceModel, int currentUserId)
        {
            var overTimeCalc = OverTimeCalc(serviceModel);
            var finalSalery = serviceModel.BasicSalary + serviceModel.Allowance + serviceModel.Transportation + overTimeCalc;
            serviceModel.FinalSalery = finalSalery;
            serviceModel.Date = serviceModel.DateStr.ConverToGregorianDate();
            base.Update(serviceModel, currentUserId);
        }

        private decimal OverTimeCalc(EmployeeServiceModel serviceModel)
        {
            decimal overTimeCalc = 0;

            switch (serviceModel.OverTimeCalculator) { 
          
                case OverTimeCalculator.CalcurlatorA:
                    overTimeCalc = CalculatorA(serviceModel.BasicSalary, serviceModel.Allowance, serviceModel.OverTime);
                    break;
                case OverTimeCalculator.CalcurlatorB:
                    overTimeCalc = CalculatorB(serviceModel.BasicSalary, serviceModel.Allowance, serviceModel.OverTime);
                    break;
                case OverTimeCalculator.CalcurlatorC:
                    overTimeCalc = CalculatorC(serviceModel.BasicSalary, serviceModel.Allowance, serviceModel.OverTime);
                    break;
                default
                : return overTimeCalc;

            }
            return overTimeCalc;

        }

        private decimal CalculatorA(decimal basicSalary, decimal allowance, decimal overTime)
        {
            var hoursPay = (((basicSalary + allowance) / 31) / 8) * 1.4m;
            return hoursPay * overTime;
        }
        private decimal CalculatorB(decimal basicSalary, decimal allowance, decimal overTime)
        {
            var hoursPay = (((basicSalary + allowance) / 30) / 8) * 1.4m;
            return hoursPay * overTime;
        }
        private decimal CalculatorC(decimal basicSalary, decimal allowance, decimal overTime)
        {
            var hoursPay = (((basicSalary + allowance) / 29) / 8) * 1.4m;
            return hoursPay * overTime;
        }


    }
}