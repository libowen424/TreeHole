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
    public class CollectionController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public CollectionController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //添加收藏
        [HttpPost]
        public ActionResult<Collection> AddCollection(Collection collection)
        {
            try
            {
                applicationDb.Collections.Add(collection);
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return collection;
        }

        //获取收藏
        //api/collection?userId=
        [HttpGet]
        public ActionResult<List<Collection>> GetCollection(long userId)
        {
            var result = applicationDb.Collections.
                Where(r => r.UserId == userId);
            if (result == null)
                return NoContent();
            else
                return result.ToList();
        }

        //删除收藏信息
        //api/collection?id=
        [HttpDelete]
        public ActionResult DeleteCollection(long id)
        {
            try
            {
                var result = applicationDb.Collections.FirstOrDefault(t => t.Id == id);
                if (result != null)
                {
                    applicationDb.Collections.Remove(result);
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