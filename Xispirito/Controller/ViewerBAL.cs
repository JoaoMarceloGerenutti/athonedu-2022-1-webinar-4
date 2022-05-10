using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class ViewerBAL
    {
        private ViewerDAL viewerDAL { get; set; }

        public ViewerBAL()
        {
            viewerDAL = new ViewerDAL();
        }

        public bool SignIn(string email, string password)
        {
            BaseUser baseUser = new BaseUser();
            baseUser.SetEmail(email);
            baseUser.SetEncryptedPassword(Cryptography.GetMD5Hash(password));

            bool emailFound = false;
            emailFound = viewerDAL.SignIn(baseUser.GetEmail(), baseUser.GetEncryptedPassword());

            return emailFound;
        }

        public void SignUp(string nome, string email, string password)
        {
            password = Cryptography.GetMD5Hash(password);
            Viewer viewer = new Viewer(nome, email, "", password, true);

            viewerDAL.Insert(viewer);
        }

        public bool VerifyAccount(string email)
        {
            email = email.ToLower();
            Viewer viewer = new Viewer();
            viewer = viewerDAL.SearchEmail(email);

            bool accountFound = false;
            if (viewer != null)
            {
                accountFound = true;
            }

            return accountFound;
        }
    }
}