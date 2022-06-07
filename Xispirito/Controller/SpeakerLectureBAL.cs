using System.Collections.Generic;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class SpeakerLectureBAL
    {
        private SpeakerLectureDAL speakerLectureDAL { get; set; }

        public SpeakerLectureBAL()
        {
            speakerLectureDAL = new SpeakerLectureDAL();
        }

        public void RegisterUserToLecture(SpeakerLecture objSpeakerLecture)
        {
            speakerLectureDAL.RegisterUserToLecture(objSpeakerLecture);
        }

        public bool VerifyUserAlreadyRegistered(SpeakerLecture objSpeakerLecture)
        {
            return speakerLectureDAL.VerifyUserAlreadyRegistered(objSpeakerLecture); ;
        }

        public void DeleteUserSubscription(SpeakerLecture objSpeakerLecture)
        {
            speakerLectureDAL.DeleteUserSubscription(objSpeakerLecture);
        }

        public int GetLectureRegistrationsNumber(int idLecture)
        {
            return speakerLectureDAL.GetLectureRegistrations(idLecture);
        }
    }
}