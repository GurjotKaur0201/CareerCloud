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
    public class ApplicantProfileController : ControllerBase
    {
        private readonly ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {
            ApplicantProfileRepository repo = new ApplicantProfileRepository();
            _logic = new ApplicantProfileLogic(repo);
        }

        [HttpGet]
        [Route("profile/{applicantProfileId}")]
        public ActionResult GetApplicantProfile(Guid applicantProfileId)
        {
            ApplicantProfilePoco poco = _logic.Get(applicantProfileId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("profile")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public ActionResult GetApplicantProfile()
        {
            List<ApplicantProfilePoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("profile")]
        [ResponseType(typeof(ApplicantProfilePoco))]
        public ActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("profile")]
        public ActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("profile")]
      
        public ActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
