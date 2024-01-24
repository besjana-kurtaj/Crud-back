﻿using Crud_Back.Data;
using Crud_Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CrudDbContext _context;

        public UserController(CrudDbContext crudDb)
        {
            _context = crudDb;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if(userObj == null)
                return BadRequest();
            var user=await _context.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password==userObj.Password);
            if (user == null)
                return NotFound(new { Message = "User not found" });
            return Ok(new {Message="Login Success"});
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            await _context.Users.AddAsync(userObj); 
            await _context.SaveChangesAsync();
            return Ok(new { Message = "User registered" });
        }
    }
}
