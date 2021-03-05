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
    public class CompanyJobController : ControllerBase
    {
        private readonly CompanyJobLogic _logic;
        public CompanyJobController()
        {
            CompanyJobRepository repo = new CompanyJobRepository();
            _logic = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("job/{companyJobId}")]

        public ActionResult GetCompanyJob(Guid companyJobId)
        {
            CompanyJobPoco poco = _logic.Get(companyJobId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("job")]
        [ResponseType(typeof(CompanyJobPoco))]

        public ActionResult GetAllCompanyJob()
        {
            List<CompanyJobPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("job")]
        [ResponseType(typeof(CompanyJobPoco))]

        public ActionResult PostCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("job")]

        public ActionResult PutCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("job")]

        public ActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
