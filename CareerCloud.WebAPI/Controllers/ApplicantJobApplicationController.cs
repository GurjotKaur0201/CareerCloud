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
    public class ApplicantJobApplicationController : ControllerBase
    {
        private readonly ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationController()
        {
            ApplicantJobApplicationRepository repo = new ApplicantJobApplicationRepository();
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("jobapplication/{applicantJobApplicationId}")]
        public ActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(applicantJobApplicationId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("jobapplication")]
        [ResponseType(typeof(ApplicantEducationPoco))]

        public ActionResult GetAllApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("jobapplication")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
        public ActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobapplication")]

        public ActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobapplication")]

        public ActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
