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
    public class AnonController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;

        public AnonController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //设置匿名
        [HttpPost]
        public ActionResult<Anon> SetAnon(Anon anon)
        {
            try
            {
                applicationDb.Anons.Add(anon);
                applicationDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return anon;
        }
    }
}