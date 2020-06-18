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
    public class ConcernController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public ConcernController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //添加点赞
        [HttpPost]
        public ActionResult<Concern> AddConcern(Concern concern)
        {
            try
            {
                applicationDb.Concerns.Add(concern);
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return concern;
        }

        [HttpGet]
        public ActionResult<List<Concern>> GetConcern(long userId1)
        {
            var result = applicationDb.Concerns.
                Where(r => r.UserId1 == userId1);
            if (result == null)
                return NoContent();
            else
                return result.ToList();
        }

        [HttpDelete]
        public ActionResult DeleteConcern(long userId1, long userId2)
        {
            try
            {
                var result = applicationDb.Concerns.FirstOrDefault(t => t.UserId1 == userId1&& t.UserId2 == userId2);
                if (result != null)
                {
                    applicationDb.Concerns.Remove(result);
                    applicationDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }
}