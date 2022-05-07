using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class BaseUser : BaseEntity
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected string Email { get; set; }
        protected string Picture { get; set; }
        protected string Password { private get; set; }

        public int GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetPicture()
        {
            return Picture;
        }

        public string GetEncryptedPassword()
        {
            return Password;
        }
    }
}