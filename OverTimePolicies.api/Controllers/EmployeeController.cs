using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OvertimePolicies.Service.Interfaces;
using OvertimePolicies.Service.Models;
using OvertimePolicies.Service.ServiceModels;

namespace OverTimePolicies.api.Controllers
{
   
    public class EmployeeController : BaseApiController<Employee, EmployeeServiceModel, EmployeeController>
    {
        private readonly IEmployeeService _Service;
        public EmployeeController(IEmployeeService service,  ILogger<EmployeeController> logger = null) : base(service, logger)
        {
            _Service = service;
        }

        [HttpGet]
        [Route("GetRange")]
        public virtual IActionResult GetRange(string dateFrom,string dateTo)
        {
            var list = _Service.GetRange(dateFrom,dateTo);

            return Ok(list);
        }

    }




}