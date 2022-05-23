using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Registry
{
    public partial class Registry : System.Web.UI.Page
    {
        private Lecture lecture = new Lecture();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["event"] != null)
            {
                lecture.SetId(Convert.ToInt32(Request.QueryString["event"]));
                GetEventInformation(lecture.GetId());
            }
        }

        private void GetEventInformation(int eventId)
        {
            LectureBAL lectureBAL = new LectureBAL();
            lecture = lectureBAL.GetLecture(eventId);

            SetEventInformation();
        }

        private void SetEventInformation()
        {
            BackgroundEventImage.ImageUrl = lecture.GetPicture();
            EventImage.ImageUrl = lecture.GetPicture();
            EventTitle.Text = lecture.GetName();
            EventTime.Text = lecture.GetDate().ToString("dd/MM/yyyy") + " - As " + lecture.GetDate().ToString("HH:mm") + " (GMT-3) - Duração de " + lecture.GetTime().ToString() + " Minutos";

            EventType.Text = lecture.GetModality();
            EventType.BackColor = ModalityColor.GetModalityColor(lecture.GetModality());

            EventDescription.Text = lecture.GetDescription();
        }
    }
}