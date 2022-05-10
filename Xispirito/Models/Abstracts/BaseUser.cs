using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models
{
    public class BaseUser : BaseEntity
    {
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected string Email { get; set; }
        protected string Picture { get; set; }
        protected string EncryptedPassword { get; set; }

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

        public void SetEmail(string email)
        {
            Email = email;
        }

        public string GetPicture()
        {
            return Picture;
        }

        public string GetEncryptedPassword()
        {
            return EncryptedPassword;
        }

        public void SetEncryptedPassword(string encryptedPassword)
        {
            EncryptedPassword = encryptedPassword;
        }
    }
}