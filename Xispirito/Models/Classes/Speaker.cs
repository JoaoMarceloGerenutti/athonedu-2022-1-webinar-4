using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class Speaker : BaseUser
    {
        private string SpeakerProfession { get; set; }

        public Speaker(int speakerId, string speakerName, string speakerEmail, string speakerPicture, string speakerProfession, string speakerPassword)
        {
            UserId = speakerId;
            UserName = speakerName;
            UserEmail = speakerEmail;
            UserPicture = speakerPicture;
            SpeakerProfession = speakerProfession;
            UserPassword = speakerPassword;
        }

        public string GetSpeakerProfession()
        {
            return SpeakerProfession;
        }
    }
}