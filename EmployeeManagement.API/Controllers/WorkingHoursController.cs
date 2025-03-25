using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;
using Clean.Core.Services;
using Clean.Data.Entities;
using Clean.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly IService<WorkingHours>_workingHoursSrvice;
        private readonly IMapper _mapper;
        public WorkingHoursController(IService<WorkingHours> workingHours, Mapper mapper)
        {
           _workingHoursSrvice = workingHours;
           _mapper = mapper;
        }
        // GET: api/<EntryAndExitController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult>Get()
        {
            var list =await _workingHoursSrvice.GetAllAsync();
            var listDTOs = _mapper.Map<IEnumerable<WorkingHoursDTO>>(list);
            return Ok(listDTOs);
        }
        // GET api/<EntryAndExitController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> Get(int id)
        {
            var workingHours =await _workingHoursSrvice.GetByIdAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }
            var workingHoursDTO = _mapper.Map<WorkingHoursDTO>(workingHours);
            return Ok(workingHoursDTO);
        }

        // POST api/<EntryAndExitController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Post([FromBody] WorkingHoursDTO workingHoursDTO)
        {
            var workingHours = _mapper.Map<WorkingHours>(workingHoursDTO);
           await _workingHoursSrvice.AddAsync(workingHours);
            return CreatedAtAction(nameof(Get), new { id = workingHours.Id }, workingHoursDTO);
        }

        // PUT api/<EntryAndExitController>/5
        [HttpPut]
        [Authorize]
        public async Task< ActionResult> Put(int id,[FromBody] WorkingHoursDTO workingHoursDTO)
        {
            var workingHours = _mapper.Map<WorkingHours>(workingHoursDTO);
            return await _workingHoursSrvice.UpdateAsync(id, workingHours) == null ?
              new NotFoundObjectResult("the working Hours not found") :
              Ok();
        }
        // DELETE api/<EntryAndExitController>/5
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var workingHours = await _workingHoursSrvice.GetByIdAsync(id);
            if (workingHours is null)
            {
                return new NotFoundObjectResult("the user not found");
            }
            await _workingHoursSrvice.DeleteAsync(workingHours);
            return Ok();
        }
    }
}
