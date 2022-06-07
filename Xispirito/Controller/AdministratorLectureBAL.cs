using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class AdministratorLectureBAL
    {
        private AdministratorLectureDAL administratorLectureDAL { get; set; }

        public AdministratorLectureBAL()
        {
            administratorLectureDAL = new AdministratorLectureDAL();
        }

        public void RegisterUserToLecture(AdministratorLecture objAdministratorLecture)
        {
            administratorLectureDAL.RegisterUserToLecture(objAdministratorLecture);
        }

        public bool VerifyUserAlreadyRegistered(AdministratorLecture objAdministratorLecture)
        {
            return administratorLectureDAL.VerifyUserAlreadyRegistered(objAdministratorLecture); ;
        }

        public void DeleteUserSubscription(AdministratorLecture objAdministratorLecture)
        {
            administratorLectureDAL.DeleteUserSubscription(objAdministratorLecture);
        }
    }
}