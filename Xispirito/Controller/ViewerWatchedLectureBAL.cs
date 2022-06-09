using System.Collections.Generic;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class ViewerWatchedLectureBAL
    {
        private ViewerWatchedLectureDAL viewerWatchedLectureDAL { get; set; }

        public ViewerWatchedLectureBAL()
        {
            viewerWatchedLectureDAL = new ViewerWatchedLectureDAL();
        }

        public void RegisterUserToLecture(string userEmail, int idLecture)
        {
            ViewerBAL viewerBAL = new ViewerBAL();
            LectureBAL lectureBAL = new LectureBAL();

            ViewerWatchedLecture objViewerWatchedLecture = new ViewerWatchedLecture(viewerBAL.GetAccount(userEmail), lectureBAL.GetLecture(idLecture));
            viewerWatchedLectureDAL.RegisterUserAttendance(objViewerWatchedLecture);
        }

        public void DeleteUserAttendance(string userEmail)
        {
            viewerWatchedLectureDAL.DeleteUserAttendance(userEmail);
        }

        public List<ViewerWatchedLecture> GetUsersWhoAttended(int lectureId)
        {
            return viewerWatchedLectureDAL.GetUsersWhoAttended(lectureId);
        }
    }
}