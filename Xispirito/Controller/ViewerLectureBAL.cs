using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xispirito.DAL;

namespace Xispirito.Controller
{
    public class ViewerLectureBAL
    {
        private ViewerLectureDAL viewerLectureDAL { get; set; }

        public ViewerLectureBAL()
        {
            viewerLectureDAL = new ViewerLectureDAL();
        }

        public void RegisterUserToLecture(string viewerEmail, int lectureId)
        {
            viewerLectureDAL.RegisterUserToLecture(viewerEmail, lectureId);
        }

        public bool VerifyUserAlreadyRegistered(string viewerEmail, int lectureId)
        {
            bool userAlreadyRegistered = false;
            userAlreadyRegistered = viewerLectureDAL.VerifyUserAlreadyRegistered(viewerEmail, lectureId);
            return userAlreadyRegistered;
        }
    }
}