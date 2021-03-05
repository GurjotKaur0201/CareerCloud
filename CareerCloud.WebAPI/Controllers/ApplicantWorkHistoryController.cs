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
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;
        public ApplicantWorkHistoryController()
        {
            ApplicantWorkHistoryRepository repo = new ApplicantWorkHistoryRepository();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("workhistory/{applicantWorkHistoryId}")]

        public ActionResult GetApplicantWorkHistory(Guid applicantWorkHistoryId)
        {
            ApplicantWorkHistoryPoco poco = _logic.Get(applicantWorkHistoryId);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("workhistory")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]

        public ActionResult GatAllApplicantWorkHistory()
        {
            List<ApplicantWorkHistoryPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("workhistory")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]

        public ActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("workhistory")]

        public ActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("workhistory")]

        public ActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
