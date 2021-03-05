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
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private readonly CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            CompanyJobDescriptionRepository repo = new CompanyJobDescriptionRepository();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobdescription/{companyJobDescriptionId}")]

        public ActionResult GetCompanyJobsDescription(Guid companyJobDescriptionId)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(companyJobDescriptionId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobdescription")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]

        public ActionResult GetAllCompanyJobsDescription()
        {
            List<CompanyJobDescriptionPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("jobdescription")]
        [ResponseType(typeof(CompanyJobPoco))]

        public ActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobdescription")]

        public ActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobdescription")]

        public ActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
