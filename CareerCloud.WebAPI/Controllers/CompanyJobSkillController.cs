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
    public class CompanyJobSkillController : ControllerBase
    {
        private readonly CompanyJobSkillLogic _logic;
        public CompanyJobSkillController()
        {
            CompanyJobSkillRepository repo = new CompanyJobSkillRepository();
            _logic = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("jobskill/{companyJobSkillId}")]

        public ActionResult GetCompanyJobSkill(Guid companyJobSkillId)
        {
            CompanyJobSkillPoco poco = _logic.Get(companyJobSkillId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobskill")]
        [ResponseType(typeof(CompanyJobSkillPoco))]

        public ActionResult GetAllCompanyJobSkill()
        {
            List<CompanyJobSkillPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("jobskill")]
        [ResponseType(typeof(CompanyJobSkillPoco))]

        public ActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobskill")]

        public ActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobskill")]

        public ActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
