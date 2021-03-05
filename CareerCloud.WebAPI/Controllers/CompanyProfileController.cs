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
    public class CompanyProfileController : ControllerBase
    {
        private readonly CompanyProfileLogic _logic;
        public CompanyProfileController()
        {
            CompanyProfileRepository repo = new CompanyProfileRepository();
            _logic = new CompanyProfileLogic(repo);
        }

        [HttpGet]
        [Route("profile/{companyProfileId}")]

        public ActionResult GetCompanyProfile(Guid companyProfileId)
        {
            CompanyProfilePoco poco = _logic.Get(companyProfileId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(CompanyProfilePoco))]

        public ActionResult GetAllCompanyProfile()
        {
            List<CompanyProfilePoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("profile")]
        [ResponseType(typeof(CompanyProfilePoco))]

        public ActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]

        public ActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("profile")]

        public ActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
