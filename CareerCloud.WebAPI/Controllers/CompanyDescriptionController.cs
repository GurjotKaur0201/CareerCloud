using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.ADODataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;
        public CompanyDescriptionController()
        {
            CompanyDescriptionRepository repo = new CompanyDescriptionRepository();
            _logic = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("description/{companyDescriptionId}")]

        public ActionResult GetCompanyDescription(Guid companyDescriptionId)
        {
            CompanyDescriptionPoco poco = _logic.Get(companyDescriptionId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("description")]
        [ResponseType(typeof(CompanyDescriptionPoco))]

        public ActionResult GetAllCompanyDescription()
        {
            List<CompanyDescriptionPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("description")]
        [ResponseType(typeof(CompanyDescriptionPoco))]

        public ActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("description")]

        public ActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("description")]

        public ActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
