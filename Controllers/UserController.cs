using BackEndCase.Models;
using BackEndCase.Models.Dto;
using BackEndCase.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndCase.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DirectoryContext _directoryContext;
        
        public UserController(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _directoryContext.Users.ToArray();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _directoryContext.Users.FirstOrDefault(p => p.UUID == id);
            //if (user is null) return NotFound();

            return user;
        }

        [HttpPost]
        public ActionResult Post(UserCreateDto userDto)
        {
            var user = new User { Name = userDto.Name, Surname = userDto.Surname, Company = userDto.Company };
            _directoryContext.Users.Add(user);
            _directoryContext.SaveChanges();
            return CreatedAtAction("Get", new { id = user.UUID }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, UserUpdateDto userUpdateDto)
        {
            var user = _directoryContext.Users.FirstOrDefault(p => p.UUID == id);
            if (user is null)
            {
                user = new User { Name = userUpdateDto.Name, Surname = userUpdateDto.Surname, Company = userUpdateDto.Company };
                _directoryContext.Users.Add(user);
                _directoryContext.SaveChanges();
                return CreatedAtRoute("Get", new { id = id }, user);
            }
            user.Name = userUpdateDto.Name;
            user.Surname = userUpdateDto.Surname;
            user.Company = userUpdateDto.Company;
            _directoryContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var users = _directoryContext.Users.FirstOrDefault(p => p.UUID == id);
            if (users is null) return NotFound();

            _directoryContext.Remove(users);
            _directoryContext.SaveChanges();
            return NoContent();
        }


    }
}
