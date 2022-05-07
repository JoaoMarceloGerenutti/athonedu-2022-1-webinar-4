using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class BaseUser : BaseEntity
    {
        protected int UserId { get; set; }
        protected string UserName { get; set; }
        protected string UserEmail { get; set; }
        protected string UserPicture { get; set; }
        protected string UserPassword { private get; set; }

        protected int GetUserId()
        {
            return UserId;
        }

        protected string GetUserName()
        {
            return UserName;
        }

        protected string GetUserEmail()
        {
            return UserEmail;
        }

        protected string GetUserPicture()
        {
            return UserPicture;
        }
    }
}