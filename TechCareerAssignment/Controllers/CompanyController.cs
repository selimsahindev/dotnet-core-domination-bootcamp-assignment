using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechCareerAssignment.Data;
using TechCareerAssignment.Models;

namespace TechCareerAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Company
        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompanies()
        {
            var companies = _dbContext.Companies;
            return Ok(companies);
        }

        // GET: api/Company/5
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Company> GetCompany(int id)
        {
            var company = _dbContext.Companies.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // POST: api/Company
        [HttpPost]
        public ActionResult<Company> CreateCompany([FromBody] Company newCompany)
        {
            if (newCompany == null)
            {
                return BadRequest("Company data is null.");
            }

            _dbContext.Companies.Add(newCompany);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetCompany", new { id = newCompany.Id }, newCompany);
        }

        // PUT: api/Company/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Company> UpdateCompany(int id, [FromBody] Company updatedCompany)
        {
            if (updatedCompany == null)
            {
                return BadRequest("Company data is null.");
            }

            var company = _dbContext.Companies.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            company.Name = updatedCompany.Name;
            company.Address = updatedCompany.Address;

            _dbContext.SaveChanges();

            return Ok(company);
        }

        // DELETE: api/Company/5
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Company> DeleteCompany(int id)
        {
            var company = _dbContext.Companies.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();

            return Ok(company);
        }
    }
}
