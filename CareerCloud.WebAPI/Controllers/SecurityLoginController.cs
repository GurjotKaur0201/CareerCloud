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
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;
        public SecurityLoginController()
        {
            SecurityLoginRepository repo = new SecurityLoginRepository();
            _logic=new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/{securityLoginId}")]

        public ActionResult GetSecurityLogin(Guid securityLoginId)
        {
            SecurityLoginPoco poco = _logic.Get(securityLoginId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("login")]
        [ResponseType(typeof(SecurityLoginPoco))]

        public ActionResult GetAllSecurityLogin()
        {
            List<SecurityLoginPoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(SecurityLoginPoco))]

        public ActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("login")]

        public ActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]

        public ActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
