﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class Administrator : BaseUser
    {
        public Administrator(int administratorId, string administratorName, string administratorEmail, string administratorPicture, string administratorPassword)
        {
            UserId = administratorId;
            UserName = administratorName;
            UserEmail = administratorEmail;
            UserPicture = administratorPicture;
            UserPassword = administratorPassword;
        }
    }
}