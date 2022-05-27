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

        private LectureBAL lectureBAL = new LectureBAL();
        private ViewerBAL viewerBAL = new ViewerBAL();
        private ViewerLectureBAL viewerLectureBAL = new ViewerLectureBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["event"] != null)
            {
                lecture.SetId(Convert.ToInt32(Request.QueryString["event"]));
                GetEventInformation(lecture.GetId());
            }

            if (true)
            {

            }
        }

        private void GetEventInformation(int eventId)
        {
            lecture = lectureBAL.GetLecture(eventId);

            SetEventInformation();
        }

        private void SetEventInformation()
        {
            BackgroundEventImage.ImageUrl = lecture.GetPicture();
            EventImage.ImageUrl = lecture.GetPicture();

            EventTitle.Text = lecture.GetName();

            EventType.Text = lecture.GetModality();
            EventType.BackColor = ModalityColor.GetModalityColor(lecture.GetModality());

            EventAddress.Text = lecture.GetAddress();

            EventTime.Text = lecture.GetDate().ToString("dd/MM/yyyy") + " - As " + lecture.GetDate().ToString("HH:mm") + " (GMT-3) - Duração de " + lecture.GetTime().ToString() + " Minutos";

            EventDescription.Text = lecture.GetDescription();
        }

        protected void Subscribe_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                RegisterUserToLecture();
            }
            else
            {
                Response.Redirect("~/View/Login/Login.aspx");
            }
        }

        private void RegisterUserToLecture()
        {
            Viewer objViewer = new Viewer();
            objViewer = GetUserAccount();

            if (objViewer != null)
            {
                if (VerifyUserAlreadyRegistered() == false)
                {
                    viewerLectureBAL.RegisterUserToLecture(objViewer.GetEmail(), lecture.GetId());
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Usuário Cadastrado com Sucesso!", "alert('Cadastro a Palestra foi efetuada com sucesso!');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Usuário Já Cadastrado!", "alert('Você já está Cadastrado a essa Palestra!');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Usuário Inválido!", "alert('Esse tipo de usuário é inválido para efetuar inscrição á palestra!');", true);
            }
        }

        private Viewer GetUserAccount()
        {
            Viewer objViewer = new Viewer();
            objViewer = viewerBAL.GetAccount(User.Identity.Name);

            return objViewer;
        }

        private bool VerifyUserAlreadyRegistered()
        {
            bool userAlreadyRegistered = false;
            userAlreadyRegistered = viewerLectureBAL.VerifyUserAlreadyRegistered(User.Identity.Name, lecture.GetId());
            return userAlreadyRegistered;
        }
    }
}