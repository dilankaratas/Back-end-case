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
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DirectoryContext _directoryContext;

        public ContactController(DirectoryContext directoryContext)
        {
            _directoryContext = directoryContext;
        }

        [HttpGet("{id}")]
        public Array Get(int id)
        {
            object[] arr = new object[2];
            var user = _directoryContext.Users.FirstOrDefault(p => p.UUID == id);
            var userContact = _directoryContext.UsersContacts.Where(p => p.UUID == user.UUID).ToArray();
            Contact[] contacts = new Contact[userContact.Count()];
            int count = 0;
            foreach (var contact in userContact)
            {
                contacts[count] = _directoryContext.Contacts.FirstOrDefault(p => p.Id == contact.ContactID);
                count++;
            }
            arr[0] = user;
            arr[1] = contacts;
            return arr;

        }

        [HttpPost("{id}")]
        public ActionResult Post(int id, ContactCreateDto contactDto)
        {
            var contact = new Contact { PhoneNumber = contactDto.PhoneNumber, Email = contactDto.Email, Lat = contactDto.Lat, Long = contactDto.Long };
            _directoryContext.Contacts.Add(contact);
            _directoryContext.SaveChanges();
            var userContact = new UserContact { UUID = id, ContactID = contact.Id };
            _directoryContext.UsersContacts.Add(userContact);
            _directoryContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var contact = _directoryContext.Contacts.FirstOrDefault(p => p.Id == id);
            if (contact is null) return NotFound();

            _directoryContext.Remove(contact);
            _directoryContext.SaveChanges();

            var userContacts = _directoryContext.UsersContacts.Where(p => p.ContactID == id).ToList();
            _directoryContext.Remove(userContacts);
            _directoryContext.SaveChanges();
            return NoContent();
        }
    }
}
