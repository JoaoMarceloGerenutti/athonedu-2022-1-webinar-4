using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xispirito.DAL;
using Xispirito.Models;

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
            ViewerLecture viewerLecture = new ViewerLecture(viewerEmail, lectureId);
            viewerLectureDAL.RegisterUserToLecture(viewerLecture);
        }

        public bool VerifyUserAlreadyRegistered(string viewerEmail, int lectureId)
        {
            bool userAlreadyRegistered = false;

            ViewerLecture objViewerLecture = new ViewerLecture(viewerEmail, lectureId);
            userAlreadyRegistered = viewerLectureDAL.VerifyUserAlreadyRegistered(objViewerLecture);

            return userAlreadyRegistered;
        }

        public void DeleteUserSubscription(string viewerEmail, int lectureId)
        {
            ViewerLecture objViewerLecture = new ViewerLecture(viewerEmail, lectureId);
            viewerLectureDAL.DeleteUserSubscription(objViewerLecture);
        }
    }
}