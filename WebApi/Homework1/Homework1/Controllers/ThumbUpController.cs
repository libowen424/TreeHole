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
    public class ThumbUpController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public ThumbUpController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //添加点赞
        [HttpPost]
        public ActionResult<ThumbUp> AddThumbUp(ThumbUp thumbup)
        {
            try
            {
                applicationDb.ThumbUps.Add(thumbup);
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return thumbup;
        }
        //获取点赞
        //api/thumbup?userId=
        [HttpGet]
        public ActionResult<List<ThumbUp>> GetThumbUp(long userId)
        {
            var result = applicationDb.ThumbUps.
                Where(r => r.UserId == userId);
            if (result == null)
                return NoContent();
            else
                return result.ToList();
        }

        //删除点赞信息
        //api/thumbup?id=
        [HttpDelete]
        public ActionResult DeleteTodoItem(long id)
        {
            try
            {
                var result = applicationDb.ThumbUps.FirstOrDefault(t => t.Id == id);
                if (result != null)
                {
                    applicationDb.ThumbUps.Remove(result);
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