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
    public class ApplicantEducationController : ControllerBase
    {
        private readonly ApplicantEducationLogic _logic;
        public ApplicantEducationController()
        {
            //EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            ApplicantEducationRepository repo = new ApplicantEducationRepository();
            _logic = new ApplicantEducationLogic(repo);
        }

        [HttpGet]
        [Route("education/{applicantEducationId}")]

        public ActionResult GetApplicantEducation(Guid applicantEducationId)
        {
            ApplicantEducationPoco poco = _logic.Get(applicantEducationId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(ApplicantEducationPoco))]

        public ActionResult GetAllApplicantEducation()
        {
            List<ApplicantEducationPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("education")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))]
        public ActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("education")]

        public ActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]

        public ActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }


    }
}
