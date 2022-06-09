using System.Collections.Generic;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class AdministratorWatchedLectureBAL
    {
        private AdministratorWatchedLectureDAL administratorWatchedLectureDAL { get; set; }

        public AdministratorWatchedLectureBAL()
        {
            administratorWatchedLectureDAL = new AdministratorWatchedLectureDAL();
        }

        public void RegisterUserToLecture(string userEmail, int idLecture)
        {
            AdministratorBAL administratorBAL = new AdministratorBAL();
            LectureBAL lectureBAL = new LectureBAL();

            AdministratorWatchedLecture objAdministratorWatchedLecture = new AdministratorWatchedLecture(administratorBAL.GetAccount(userEmail), lectureBAL.GetLecture(idLecture));
            administratorWatchedLectureDAL.RegisterUserAttendance(objAdministratorWatchedLecture);
        }

        public void DeleteUserAttendance(string userEmail)
        {
            administratorWatchedLectureDAL.DeleteUserAttendance(userEmail);
        }

        public List<AdministratorWatchedLecture> GetUsersWhoAttended(int lectureId)
        {
            return administratorWatchedLectureDAL.GetUsersWhoAttended(lectureId);
        }
    }
}