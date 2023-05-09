using AssignmentWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactApiController : ControllerBase
    {
        private readonly ContactContext _dbContext;
        public ContactApiController(ContactContext dbContaxt)
        {
            _dbContext = dbContaxt;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
        {
            return await _dbContext.contact.ToListAsync();
        }


        


        [HttpPut]
        public async Task<ActionResult<Contact>> putContact(int id, Contact contact)
        {
            _dbContext.Entry(contact).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        


        
    }
}
