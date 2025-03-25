using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;
using Clean.Core.Services;
using Clean.Data.Entities;
using Clean.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly IService<Vacations> _vacationService;
        private readonly IMapper _mapper;

        public VacationsController(IService<Vacations> VacationsService, IMapper mapper)
        {
            _vacationService = VacationsService;
            _mapper = mapper;
        }
        // GET: api/<VacationAndIllnessController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get()
        {
            var list = await _vacationService.GetAllAsync();
            var listDTOs = _mapper.Map<IEnumerable<VacationDTO>>(list);
            return Ok(listDTOs);
        }

        // GET api/<VacationAndIllnessController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> Get(int id)
        {
            var vacations = await _vacationService.GetByIdAsync(id);
            if (vacations == null)
            {
                return NotFound();
            }
            var vacationsDTO = _mapper.Map<VacationDTO>(vacations);
            return Ok(vacationsDTO);
        }
        // POST api/<VacationAndIllnessController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Post([FromBody] VacationDTO vacationDTO)
        {
            var vacations = _mapper.Map<Vacations>(vacationDTO);
            await _vacationService.AddAsync(vacations);
            return CreatedAtAction(nameof(Get), new { id = vacations.Id }, vacationDTO);
        }

        // PUT api/<VacationAndIllnessController>/5
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put(int id,[FromBody] VacationDTO vacationTDO)
        {
            var vacations = _mapper.Map<Vacations>(vacationTDO);
            return await _vacationService.UpdateAsync(id, vacations) == null ?
               new NotFoundObjectResult("the vacation not found") :
               Ok();
        }

        // DELETE api/<VacationAndIllnessController>/5
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var vacation = await _vacationService.GetByIdAsync(id);
            if (vacation is null)
            {
                return new NotFoundObjectResult("the vacation not found");
            }
            await _vacationService.DeleteAsync(vacation);
            return Ok();
        }
    }
}
