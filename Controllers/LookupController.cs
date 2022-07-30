using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ticketingSystem_1.Controllers
{
    public class LookupController : ApiController
    {
        private ticketingEntities _entityContext = new ticketingEntities();

        [Route("api/LookupController/getProjects")]
        [HttpGet]
        public IHttpActionResult getProjects()
        {
            var data = _entityContext.projects.ToList();
            return Ok(data);
        }

        [Route("api/LookupController/getPriorities")]
        [HttpGet]
        public IHttpActionResult getPriorities()
        {
            var data = _entityContext.priorities.ToList();
            return Ok(data);
        }

        [Route("api/LookupController/getStatuses")]
        [HttpGet]
        public IHttpActionResult getStatuses()
        {
            var data = _entityContext.status.ToList();
            return Ok(data);
        }

        [Route("api/LookupController/getAssignees")]
        [HttpGet]
        public IHttpActionResult getAssignees()
        {
            var data = _entityContext.assignees.ToList();
            return Ok(data);
        }
    }
}
