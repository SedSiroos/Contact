using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Mapping;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("contact")]
    [ApiController]
    public class ContactController : Controller
    {
        private ContactContext _data;
        private readonly IMapper _mapper;
        public ContactController(ContactContext data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ContactDto> GetContact(long id, CancellationToken cancellationToken)
        {
            var result = await _data.Contacts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return _mapper.Map<ContactDto>(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewContact(CreateContactDto input, CancellationToken cancellationToken)
        {
            if (_data.Contacts.Any(x => x.Name == input.Name))
                return BadRequest("تکراری است");

            var contact = _mapper.Map<Contact>(input);
            _data.Add(contact);
            await _data.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<List<ContactDto>> ListContact(CancellationToken cancellationToken)
        {
            var list = await _data.Contacts.ToListAsync(cancellationToken);
            return _mapper.Map<List<ContactDto>>(list);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _data.Contacts.SingleOrDefaultAsync(x => x.Id == id);
            _data.Remove(contact);
            await _data.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditContact(EditContactDto command, CancellationToken cancellationToken)
        {
            var contact = await _data.Contacts.SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
            _mapper.Map<Contact>(contact);
            await _data.SaveChangesAsync(cancellationToken);
            return Ok(contact);

        }

        [HttpPost("Additional")]
        public async Task<IActionResult> PostAddional(CreateAdditional input,CancellationToken cancellationToken)
        {
            var result = _mapper.Map<ContactAdditionalData>(input);
            _data.Add(result);
            await _data.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
