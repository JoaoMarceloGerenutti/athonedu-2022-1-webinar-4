using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class SpeakerBAL
    {
        private SpeakerDAL speakerDAL { get; set; }

        public SpeakerBAL()
        {
            speakerDAL = new SpeakerDAL();
        }

        public bool VerifyAccount(string email)
        {
            Speaker objSpeaker = new Speaker();
            objSpeaker = speakerDAL.SearchEmail(email);

            bool accountFound = false;
            if (objSpeaker != null)
            {
                accountFound = true;
            }

            return accountFound;
        }

        public bool VerifyAccount(string email, string password)
        {
            Speaker objSpeaker = new Speaker();
            objSpeaker = speakerDAL.SearchEmail(email, Cryptography.GetMD5Hash(password));

            bool accountFound = false;
            if (objSpeaker != null)
            {
                accountFound = true;
            }

            return accountFound;
        }

        public Speaker GetAccount(string email)
        {
            Speaker objSpeaker = new Speaker();
            objSpeaker = speakerDAL.SearchEmail(email);

            return objSpeaker;
        }

        public Speaker GetAccount(string email, string password)
        {
            Speaker objSpeaker = new Speaker();
            objSpeaker = speakerDAL.SearchEmail(email, Cryptography.GetMD5Hash(password));

            return objSpeaker;
        }

        public bool VerifyAccountStatus(Speaker objSpeaker)
        {
            bool accountActive = false;
            if (objSpeaker.GetIsActive() == true)
            {
                accountActive = true;
            }
            return accountActive;
        }
    }
}