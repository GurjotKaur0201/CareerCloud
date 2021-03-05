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
    public class SystemCountryCodeController : ControllerBase
    {
        private readonly SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            SystemCountryCodeRepository repo = new SystemCountryCodeRepository();
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("countrycode/{systemCountryCodeCode}")]

        public ActionResult GetSystemCountryCode(String systemCountryCodeCode)
        {
            SystemCountryCodePoco poco = _logic.Get(systemCountryCodeCode);
            if (poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("countrycode")]
        [ResponseType(typeof(SystemCountryCodePoco))]

        public ActionResult GetAllSystemCountryCode()
        {
            List<SystemCountryCodePoco> pocos = _logic.GetAll();
            if (pocos == null)
            {
                return NotFound();
            }
            return Ok(pocos);
        }

        [HttpPost]
        [Route("countrycode")]
        [ResponseType(typeof(SystemCountryCodePoco))]

        public ActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("countrycode")]

        public ActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("countrycode")]

        public ActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
