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
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext applicationDb;
        public UserController(ApplicationContext context)
        {
            this.applicationDb = context;
        }

        //用户注册
        //api/user/reg
        [HttpPost("reg")]
        public bool Register(User user)
        {
            /*
                foreach (User temp in applicationDb.Users)
                {
                    if (temp.LoginId == user.LoginId)
                        return false;
                }
                */
                applicationDb.Users.Add(user);
                applicationDb.SaveChanges();
                return true;
        }

        //用户登录
        //api/user/login
        [HttpPost("login")]
        public User Login(User user)
        {
            var u = applicationDb.Users.FirstOrDefault(u => u.LoginId == user.LoginId);
            if (u == null)
                return null;
            if (u.LoginPwd == user.LoginPwd)
                return u;
            else
                return null;
        }

        [HttpGet]
        public ActionResult<List<User>> GetIfo()
        {
            return applicationDb.Users.ToList();
        }

    }
}