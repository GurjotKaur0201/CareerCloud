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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemLanguageCodeController : ControllerBase
    {
        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            SystemLanguageCodeRepository repo = new SystemLanguageCodeRepository();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("languagecode/{systemLanguageCodeLanguageId}")]

        public ActionResult GetSystemLanguageCode(String systemLanguageCodeLanguageId)
        {
            SystemLanguageCodePoco poco = _logic.Get(systemLanguageCodeLanguageId);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("languagecode")]
        [ResponseType(typeof(SystemLanguageCodePoco))]

        public ActionResult GetAllSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("languagecode")]
        [ResponseType(typeof(SystemLanguageCodePoco))]

        public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("languagecode")]

        public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("languagecode")]

        public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
