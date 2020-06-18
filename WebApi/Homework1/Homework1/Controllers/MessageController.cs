using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework1.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public MessageController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        [HttpPost]
        public ActionResult<Message> AddMessage(Message message)
        {
            try
            {
                applicationDb.Messages.Add(message);
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return message;
        }

        [HttpGet]
        public ActionResult<List<Message>> GetMessage(long userId1,long userId2)
        {
            var result = applicationDb.Messages.
                Where(r =>((r.UserId1 == userId1&&r.UserId2 == userId2 )||( r.UserId1 == userId2&& r.UserId2==userId1)));
            if (result == null)
                return NoContent();
            else
                return result.ToList();
        }


    }
}