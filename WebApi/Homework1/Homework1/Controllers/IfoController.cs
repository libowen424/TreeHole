using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework1.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IfoController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public IfoController(ApplicationContext context)
        {
            this.applicationDb = context;
            
        }
        
        //添加一个信息
        [HttpPost]
        public ActionResult<Ifo> AddIfo(Ifo ifo)
        {
            try
            {
                applicationDb.Ifos.Add(ifo);
                applicationDb.SaveChanges();
            }
            catch (Exception e)

            {
                return BadRequest(e.InnerException.Message);
            }
            return ifo;
        }

        [HttpGet]
        public ActionResult<List<Ifo>> GetIfo(long userId)
        {
            if (userId != 0)
            {
                var ifo = applicationDb.Ifos
                    .Where(r => r.UserId == userId);
                if (ifo == null)
                    return NoContent();
                else
                    return ifo.ToList();
            }
            else
            {
                return applicationDb.Ifos.ToList();
            }

        }

        // PUT: api/ifo/{userId}
        [HttpPut("{userId}")]
        public ActionResult<Ifo> PutIfo(long userId, Ifo ifo)
        {
            if (userId != ifo.UserId)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                applicationDb.Entry(ifo).State = EntityState.Modified;
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }


    }
}