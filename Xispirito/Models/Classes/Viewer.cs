using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models
{
    public class Viewer : BaseUser 
    {
        public Viewer(int viewerId, string viewerName, string viewerEmail, string viewerPicture, string viewerPassword, bool isActive)
        {
            Id = viewerId;
            Name = viewerName;
            Email = viewerEmail;
            Picture = viewerPicture;
            Password = viewerPassword;
            IsActive = isActive;
        }
    }
}