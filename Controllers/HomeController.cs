using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ticketingSystem_1.Controllers
{
    public class HomeController : ApiController
    {
        private ticketingEntities _entityContext = new ticketingEntities();


        public IHttpActionResult getTicketsByStatus(int status = 0)
        {
            var data =
            from t in _entityContext.tickets
            join p in _entityContext.projects on t.Project equals p.Id
            join pr in _entityContext.priorities on t.Priorty equals pr.Id
            join s in _entityContext.status on t.Status equals s.Id
            join a in _entityContext.assignees on t.Assignee equals a.Id
            where t.Status==status
            select new
            {
                Name = t.Name,
                Description = t.Description,
                DueDate = t.DueDate,
                Project = p.Name,
                Priorty = pr.Name,
                Status = s.Name,
                Assignee = a.Name,
                Id = t.Id,
            };

            return Ok(data);
        }


        //[Route("api/HomeController/updateTicketList")]
        //[HttpPost]
        //public IHttpActionResult updateTicketList(int[] idsList, int status)
        //{
        //    if (idsList != null)
        //    {
        //        var filteredTickets = _entityContext.tickets.Where(t => idsList.Contains(t.Id)).ToList();
        //        filteredTickets.ForEach(c => c.Status = status);
        //        return Ok("success");
        //    }
        //    else{
        //        return Ok("failure");
        //    }
        //}

        }
}

