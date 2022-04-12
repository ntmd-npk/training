using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Context;
using Service.Service;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private IBaseService<Company> _companyService;
        public CompanyController(IBaseService<Company> companyService)
        {
            _companyService = companyService;
        }

        // GET: api/company
        [HttpGet]
        public ActionResult GetCompany()
        {
            try
            {
                var employees = _companyService.Get();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST
        [HttpPost]
        public ActionResult<int> PostCompany(Company employee)
        {
            try
            {
                var id = _companyService.Create(employee);
                return Ok(id);
            }
            catch
            {
                return NotFound();
            }
        }


        // DELETE
        [HttpDelete("{id}")]
        public ActionResult DeleteCompanye(int id)
        {
            try
            {
                _companyService.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }


        // PUT
        [HttpPut("{id}")]
        public ActionResult UpdateCompany(int id, Company employee)
        {
            try
            {
                _companyService.Update(id, employee);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
