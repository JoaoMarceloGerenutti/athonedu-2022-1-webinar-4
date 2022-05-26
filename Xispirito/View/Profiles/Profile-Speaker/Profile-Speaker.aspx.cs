using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Profile_Speaker
{
    public partial class Profile_Speaker : System.Web.UI.Page
    {
        private SpeakerBAL speakerBAL = new SpeakerBAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Speaker LoadSpeakerProfile()
        {
            Speaker objSpeaker = new Speaker();

            return objSpeaker;
        }
    }
}