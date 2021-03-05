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
    public class ApplicantResumeController : ControllerBase
    {
        private readonly ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {
            ApplicantResumeRepository repo = new ApplicantResumeRepository();
            _logic = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("resume/{applicantResumeId}")]
        public ActionResult GetApplicantResume(Guid applicantResumeId)
        {
            ApplicantResumePoco poco = _logic.Get(applicantResumeId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("resume")]
        [ResponseType(typeof(ApplicantResumePoco))]

        public ActionResult GetAllApplicantResume()
        {
            List<ApplicantResumePoco> pocos = _logic.GetAll();
            if(pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("resume")]
        [ResponseType(typeof(ApplicantResumePoco))]

        public ActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("resume")]

        public ActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("resume")]

        public ActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

    }
}
