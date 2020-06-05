using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework1.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubreplyController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public SubreplyController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //按回复的内容查询该回复下的sub
        //var path = '/api/subreply' + "?replyId=" + ;
        [HttpGet]
        public ActionResult<List<Subreply>> GetSubReply(long replyId)
        {
            var subreplies = applicationDb.Subreplies
                .Where(s => s.ReplyId == replyId);
            if (subreplies == null)
                return NoContent();
            else
                return subreplies.ToList();
        }

        //对一个话题下的回复作出回复
        [HttpPost]
        public ActionResult<Subreply> CreateSubReply(Subreply subreply)
        {
            try
            {
                applicationDb.Subreplies.Add(subreply);
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return subreply;
        }
    }
}