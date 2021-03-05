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
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        private readonly SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {
            SecurityLoginsLogRepository repo = new SecurityLoginsLogRepository();
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginslog/{securityLoginsLogId}")] 

        public ActionResult GetSecurityLoginLog(Guid securityLoginsLogId)
        {
            SecurityLoginsLogPoco poco = _logic.Get(securityLoginsLogId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("loginslog")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]

        public ActionResult GetAllSecurityLoginsLog()
        {
            List<SecurityLoginsLogPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("loginslog")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]

        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginslog")]

        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginslog")]

        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
