using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class AdministratorBAL
    {
        private AdministratorDAL adminDAL { get; set; }

        public AdministratorBAL()
        {
            adminDAL = new AdministratorDAL();
        }

        public bool SignIn(string email, string encryptedPassword)
        {
            BaseUser baseUser = new BaseUser();
            baseUser.SetEmail(email);
            baseUser.SetEncryptedPassword(Cryptography.GetMD5Hash(encryptedPassword));

            bool emailFound = false;
            emailFound = adminDAL.SignIn(baseUser.GetEmail(), baseUser.GetEncryptedPassword());

            return emailFound;
        }
    }
}