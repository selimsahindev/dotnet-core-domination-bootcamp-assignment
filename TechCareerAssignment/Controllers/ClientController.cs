using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechCareerAssignment.Data;
using TechCareerAssignment.Models;

namespace TechCareerAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Client
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            var clients = _dbContext.Clients;
            return Ok(clients);
        }

        // GET: api/Client/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Client> GetClient(int id)
        {
            var client = _dbContext.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST: api/Client
        [HttpPost]
        public ActionResult<Client> CreateClient([FromBody] Client newClient)
        {
            if (newClient == null)
            {
                return BadRequest("Client data is null.");
            }

            _dbContext.Clients.Add(newClient);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetClient", new { id = newClient.Id }, newClient);
        }

        // PUT: api/Client/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Client> UpdateClient(int id, [FromBody] Client updatedClient)
        {
            if (updatedClient == null)
            {
                return BadRequest("Client data is null.");
            }

            var client = _dbContext.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            client.Name = updatedClient.Name;
            client.Surname = updatedClient.Surname;
            client.BirthDate = updatedClient.BirthDate;
            client.Address = updatedClient.Address;
            client.EMail = updatedClient.EMail;
            client.CompanyId = updatedClient.CompanyId;

            _dbContext.SaveChanges();

            return Ok(client);
        }

        // DELETE: api/Client/5
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Client> DeleteClient(int id)
        {
            var client = _dbContext.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            _dbContext.Clients.Remove(client);
            _dbContext.SaveChanges();

            return Ok(client);
        }
    }
}
