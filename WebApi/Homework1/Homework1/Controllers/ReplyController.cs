using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework1.models;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly ApplicationContext applicationDB;

        public ReplyController(ApplicationContext context)
        {
            applicationDB = context;
        }

        // GET: api/reply?topicId=
        [HttpGet]
        public ActionResult<List<Reply>> GetReply(long topicId)
        {

            var replies = applicationDB.Replies
                .Where(r => r.TopicId == topicId);
            if (replies == null)
                return NoContent();
            else
                return replies.ToList();

        }

        //api/reply
        //添加评论
        [HttpPost]
        public ActionResult<Reply> CreateReply(Reply reply)
        {
            try
            {
                applicationDB.Replies.Add(reply);
                applicationDB.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return reply;
        }

    }
}
