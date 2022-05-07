using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class Viewer : BaseUser 
    {
        public Viewer(int viewerId, string viewerName, string viewerEmail, string viewerPicture, string viewerPassword)
        {
            UserId = viewerId;
            UserName = viewerName;
            UserEmail = viewerEmail;
            UserPicture = viewerPicture;
            UserPassword = viewerPassword;
        }
    }
}