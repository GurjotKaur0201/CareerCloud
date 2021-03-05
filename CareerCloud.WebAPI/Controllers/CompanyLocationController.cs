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
    public class CompanyLocationController : ControllerBase
    {
        private readonly CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            CompanyLocationRepository repo = new CompanyLocationRepository();
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("location/{companyLocationId}")]

        public ActionResult GetCompanyLocation(Guid companyLocationId)
        {
            CompanyLocationPoco poco = _logic.Get(companyLocationId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("location")]
        [ResponseType(typeof(CompanyLocationPoco))]

        public ActionResult GetAllCompanyLocation()
        {
            List<CompanyLocationPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("location")]
        [ResponseType(typeof(CompanyLocationPoco))]

        public ActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("location")]

        public ActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("location")]

        public ActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
