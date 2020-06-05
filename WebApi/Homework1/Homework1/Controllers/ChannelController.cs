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
    public class ChannelController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;
        public ChannelController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //添加Channel
        //api/channel
        [HttpPost]
        public bool AddChannel(Channel channel)
        {
            applicationDb.Channels.Add(channel);
            applicationDb.SaveChanges();
            return true;
        }
        //获取所有channel
        //api/channel
        [HttpGet]
        public ActionResult<List<Channel>> GetChannels()
        {
            return applicationDb.Channels.ToList();
        }
    }
}