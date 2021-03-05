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
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;
        public SecurityLoginsRoleController()
        {
            SecurityLoginsRoleRepository repo = new SecurityLoginsRoleRepository();
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("loginsrole/{securityLoginsRoleId}")]

        public ActionResult GetSecurityLoginsRole(Guid securityLoginsRoleId)
        {
            SecurityLoginsRolePoco poco = _logic.Get(securityLoginsRoleId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("loginsrole")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]

        public ActionResult GetAllSecurityLoginsRole()
        {
            List<SecurityLoginsRolePoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("loginsrole")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]

        public ActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("loginsrole")]

        public ActionResult PutSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("loginsrole")]

        public ActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
