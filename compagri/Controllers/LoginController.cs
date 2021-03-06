﻿using CompAgri.Common;
using CompAgri.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompAgri.Controllers
{
    [Common.AuthorizeFilter]
    public class LoginController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        //public UserDto Post([FromBody] UserDto user)
        public UserDto Post(UserDto user)
        {
            User userFromDatabase;
            using (var db = new CompAgriConnection())
            {
                if (user.Email != null)
                {
                    userFromDatabase = db.User.FirstOrDefault(u => u.Email == user.Email);
                }
                else if (user.UserName != null)
                {
                    userFromDatabase = db.User.FirstOrDefault(u => u.UserName == user.UserName);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                if (userFromDatabase == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                var hashedPassword = PasswordUtils.HashPassword(user.Password, userFromDatabase.PasswordSalt);

                if (hashedPassword != userFromDatabase.Password)
                {
                    throw new HttpResponseException(HttpStatusCode.Forbidden);
                }
                else
                {
                    userFromDatabase.Token = TokenUtils.GenerateToken();
                    db.SaveChanges();

                    var userToSend = new UserDto(userFromDatabase, true);
                    return userToSend;
                }
            }
        }

        public UserDto Get()
        {
            string token = UserUtils.GetUserToken(Request);

            if (token == null)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            using (var db = new CompAgriConnection())
            {
                var user = db.User.FirstOrDefault(u => u.Token == token);
                if (user == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                return new UserDto(user, true);
            }
        }

        public void Delete()
        {
            string token = UserUtils.GetUserToken(Request);

            if (token == null)
            {
                return;
            }

            using (var db = new CompAgriConnection())
            {
                var user = db.User.FirstOrDefault(u => u.Token == token);
                if (user == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                user.Token = null;
                db.SaveChanges();
            }
        }
    }
}
