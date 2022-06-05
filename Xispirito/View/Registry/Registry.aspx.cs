using System;
using System.Web.UI;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Registry
{
    public partial class Registry : Page
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

                if (VerifyLectureStatus())
                {
                    if (!IsPostBack)
                    {
                        if (VerifyUserAlreadyRegistered())
                        {
                            EventSubscribe.Text = "Cancelar Inscrição";
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/View/Home/Home.aspx");
                }
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
                if (VerifyLectureStatus())
                {
                    RegisterUserToLecture();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Palestra Expirada!", "alert('Você não pode realizar Inscrição a Palestras Inativas ou em Andamento!');", true);
                }
            }
            else
            {
                Response.Redirect("~/View/Login/Login.aspx");
            }
        }

        private bool VerifyLectureStatus()
        {
            bool registrationOpen = true;
            if (lecture.IsActive == false || lecture.GetDate() < DateTime.Now)
            {
                registrationOpen = false;
            }
            return registrationOpen;
        }

        private void RegisterUserToLecture()
        {
            Viewer objViewer = new Viewer();
            objViewer = GetUserAccount();

            if (objViewer != null)
            {
                ViewerLecture objViewerLecture = new ViewerLecture(objViewer, lecture);
                if (VerifyUserAlreadyRegistered() == false)
                {
                    viewerLectureBAL.RegisterUserToLecture(objViewerLecture);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Usuário Cadastrado com Sucesso!", "alert('Cadastro a Palestra efetuado com sucesso!');", true);
                    EventSubscribe.Text = "Cancelar Inscrição";
                }
                else
                {
                    viewerLectureBAL.DeleteUserSubscription(objViewerLecture);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Inscrição Cancelada!", "alert('Sua Inscrição a Palestra foi Cancelada!');", true);
                    EventSubscribe.Text = "Inscrever-se";
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
            Viewer objViewer = new Viewer();
            objViewer = GetUserAccount();

            bool userAlreadyRegistered = false;

            if (objViewer != null)
            {
                ViewerLecture objViewerLecture = new ViewerLecture(objViewer, lecture);
                userAlreadyRegistered = viewerLectureBAL.VerifyUserAlreadyRegistered(objViewerLecture);
            }

            return userAlreadyRegistered;
        }
    }
}