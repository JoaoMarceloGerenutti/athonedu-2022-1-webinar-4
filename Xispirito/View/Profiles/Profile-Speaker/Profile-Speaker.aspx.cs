using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Xispirito.View.Profiles.Profile_Speaker
{
    public partial class Profile_Speaker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Speaker objSpeaker = new Speaker();
            objSpeaker = LoadSpeakerProfile();

            NameSpeaker.Text = objSpeaker.GetName();
            EmailSpeaker.Text = objSpeaker.GetEmail();
            ProfissionSpeaker.Text = objSpeaker.GetSpeakerProfession();
            ImageSpeaker.ImageUrl = objSpeaker.GetPicture();
        }

        private Speaker LoadSpeakerProfile()
        {
            Speaker objSpeaker = new Speaker();
            objSpeaker = speakerBAL.GetAccount(User.Identity.Name);

            return objSpeaker;
        }
    }
}