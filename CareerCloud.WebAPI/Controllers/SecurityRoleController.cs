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
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;
        public SecurityRoleController()
        {
            SecurityRoleRepository repo = new SecurityRoleRepository();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("role/{securityRoleId}")]

        public ActionResult GetSecurityRole(Guid securityRoleId)
        {
            SecurityRolePoco poco = _logic.Get(securityRoleId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("role")]
        [ResponseType(typeof(SecurityRolePoco))]

        public ActionResult GetAllSecurityRole()
        {
            List<SecurityRolePoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }


        [HttpPost]
        [Route("role")]
        [ResponseType(typeof(SecurityRolePoco))]

        public ActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("role")]

        public ActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("role")]

        public ActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
