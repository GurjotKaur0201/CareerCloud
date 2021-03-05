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

    public class CompanyJobEducationController : ControllerBase
    {
        private readonly CompanyJobEducationLogic _logic;
        public CompanyJobEducationController()
        {
            CompanyJobEducationRepository repo = new CompanyJobEducationRepository();
            _logic = new CompanyJobEducationLogic(repo);
        }

        [HttpGet]
        [Route("jobeducation/{companyJobEducationId}")]

        public ActionResult GetCompanyJobEducation(Guid companyJobEducationId)
        {
            CompanyJobEducationPoco poco = _logic.Get(companyJobEducationId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobeducation")]
        [ResponseType(typeof(CompanyJobEducationPoco))]

        public ActionResult GetAllCompanyJobEducation()
        {
            List<CompanyJobEducationPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("jobeducation")]
        [ResponseType(typeof(CompanyJobEducationPoco))]

        public ActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobeducation")]

        public ActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobeducation")]

        public ActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
