using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("contact")]
    [ApiController]
    public class ContactController : Controller
    {
        private ContactContext _data;

        public ContactController(ContactContext data)
        {
            _data = data;
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(long id)
        {
            var result = _data.Contacts.FirstOrDefault(x => x.Id == id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateNewContact(CreateContactDto input)
        {
            if (_data.Contacts.Any(x => x.Name == input.Name))
                return BadRequest("تکراری است");

            var contact = new Contact(input.Name, input.Phone);
            _data.Add(contact);
            _data.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult ListContact()
        {
            var list = _data.Contacts.ToList();
            return Ok(list);
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _data.Contacts.SingleOrDefault(x => x.Id == id);
            _data.Remove(contact);
            _data.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditContact(EditContactDto command)
        {
            var contact = _data.Contacts.SingleOrDefault(x => x.Id == command.Id);


            if (contact is not null)
            {
                contact.Name = command.Name;
                contact.Phone = command.Name;
                contact.Id = command.Id;
            }

            _data.SaveChanges();
            return Ok(contact);

        }
    }
}
