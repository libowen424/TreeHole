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
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public TopicController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //api/topic?channelId=   ?nickName=
        //根据channelId查询话题
        [HttpGet]
        public ActionResult<List<Topic>> GetTopics(long channelId, string nickName)
        {
            if (nickName != null)
            {
                var topics = applicationDb.Topics.Where(t => t.Publisher == nickName);
                if (topics == null)
                    return NoContent();
                else
                    return topics.ToList();
            }
         
            else if (channelId != 0)
            {
                var topics = applicationDb.Topics.Where(t => t.ChannelId == channelId);
                if (topics == null)
                    return NoContent();
                else
                    return topics.ToList();
            }
            else
            {
                return NoContent();
            }
            
        }

        //api/topic
        //创建话题
        [HttpPost]
        public ActionResult<Topic> CreateTopic(Topic topic)
        {
            try
            {
                topic.Date = DateTime.Now;
                applicationDb.Topics.Add(topic);
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return topic;
        }

    }
}