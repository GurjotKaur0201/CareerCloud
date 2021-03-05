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
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly ApplicantSkillLogic _logic;
        public ApplicantSkillController()
        {
            ApplicantSkillRepository repo = new ApplicantSkillRepository();
            _logic = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("skill/{applicantSkillId}")]

        public ActionResult GetApplicantSkill(Guid applicantSkillId)
        {
            ApplicantSkillPoco poco = _logic.Get(applicantSkillId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("skill")]
        [ResponseType(typeof(ApplicantSkillPoco))]

        public ActionResult GetAllApplicantSkill()
        {
            List<ApplicantSkillPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("skill")]
        [ResponseType(typeof(ApplicantSkillPoco))]

        public ActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("skill")]

        public ActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("skill")]

        public ActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
