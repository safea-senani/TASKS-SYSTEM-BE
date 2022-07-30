using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ticketingSystem_1.Controllers
{
    public class TicketController : ApiController
    {
        private ticketingEntities _entityContext = new ticketingEntities();

        [Route("api/TicketController/createTicket")]
        [HttpPost]
        public IHttpActionResult createTicket(Ticket ticketRecord)
        {
            var result = false;
            if (ticketRecord != null)
            {

            // Create a new ticket object.
            ticket record = new ticket();
            record.Name = ticketRecord.Name;
            record.Description = ticketRecord.Description;
            record.DueDate = ticketRecord.DueDate;
            record.Project = ticketRecord.Project;
            record.Assignee = ticketRecord.Assignee;
            record.Status = ticketRecord.Status;
            record.Priorty = ticketRecord.Priorty;
            
            // Add the new record to the record collection.
            _entityContext.tickets.Add(record);
            }
            try
            {
                // Submit the change to the database.
                _entityContext.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Ok(result);
        }


        [Route("api/TicketController/updateTicket")]
        [HttpPost]
        public IHttpActionResult updateTicket(Ticket ticketRecord)
        {
            var result = false;
            if (ticketRecord != null)
            {
                ticket record = (from t in _entityContext.tickets
                                 where t.Id == ticketRecord.Id
                                 select t).SingleOrDefault();
                record.Name = ticketRecord.Name;
                record.Description = ticketRecord.Description;
                record.DueDate = ticketRecord.DueDate;
                record.Project = ticketRecord.Project;
                record.Assignee = ticketRecord.Assignee;
                record.Status = ticketRecord.Status;
                record.Priorty = ticketRecord.Priorty;
            }
            try
            {
                // Submit the change to the database.
                _entityContext.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
            return Ok(result);
        }

        [Route("api/TicketController/getTicketById")]
        [HttpGet]
        public IHttpActionResult getTicketById(int ticketId=0)
        {
            ticket record = _entityContext.tickets.Where(t => t.Id == ticketId).FirstOrDefault();
            return Ok(record);
        }




    }
}
