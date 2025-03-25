using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;
using Clean.Core.Services;
using Clean.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        
        public async Task<ActionResult> Get()
        {
            var list = await _userService.GetAllAsync();
            var listDTOs = _mapper.Map<IEnumerable<UserDTO>>(list);
            return Ok(listDTOs);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Post([FromBody] UserPostDTO userPostDTO)
        {
            var user = _mapper.Map<User>(userPostDTO);
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, userPostDTO);
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id,[FromBody] UserDTO userDTO)
        {
           var user = _mapper.Map<User>(userDTO);
           return await _userService.UpdateAsync(id,user)==null? 
             new NotFoundObjectResult("the user not found"):
             Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null)
            {
                return new NotFoundObjectResult("the user not found");
            }
            await _userService.DeleteAsync(user);
            return Ok();
        }

    }
}
