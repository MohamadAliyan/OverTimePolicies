using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using OvertimePolicies.Service.Interfaces;
using OvertimePolicies.Service.Models;
using OvertimePolicies.Service.ServiceModels;

namespace OverTimePolicies.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController<TInput, TResult, TChild> : Controller
        where TInput : BaseEntity
        where TResult : BaseServiceModel
    {
        private readonly IService<TInput, TResult> _Service;
        


        public int CurrentUserId
        {
            get
            {

                return 1;
            }
        }




        public BaseApiController(IService<TInput, TResult> service)
        {
            _Service = service;
       

        }

        #region Crud...
        [HttpGet]
        [Route("GetAllList")]
        public virtual IActionResult GetAllList()
        {
            var list = _Service.GetAll();

            return Ok(list);
        }




        [HttpGet]
        [Route("Get")]

        public virtual IActionResult Get(long id)
        {
            var model = _Service.Get(id);
            return Ok(model);
        }

        [HttpPost]
        [Route("Create")]

        public virtual IActionResult Create([FromBody] TResult model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Service.Insert(model, CurrentUserId);
                    return Ok();
                }
                else
                {



                    return StatusCode(406, ModelState.Keys.ToString());//Not Acceptable
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("InsertAndGetId")]

        public virtual IActionResult InsertAndGetId([FromBody] TResult model)
        {
            var newId = _Service.InsertAndGetId(model, CurrentUserId);
            return Ok(newId);
        }

        [HttpPost]
        [Route("Edit")]

        public virtual IActionResult Edit([FromBody] TResult model)
        {
            try
            {
                _Service.Update(model, CurrentUserId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Delete")]
        public virtual IActionResult Delete(long id)
        {
            try
            {
                _Service.Delete(id, CurrentUserId);
                return Ok();
            }
            catch (Exception ex)
            {
                // _logger.LogError(LoggingEvents.DeleteItem, ex, null);
                return BadRequest();
            }
        }

        #endregion




    }
}