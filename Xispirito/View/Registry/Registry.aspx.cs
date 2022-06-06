using System;
using System.Drawing;
using System.Web.UI;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Registry
{
    public partial class Registry : Page
    {
        private Lecture lecture = new Lecture();
        private Administrator administrator = new Administrator();

        private LectureBAL lectureBAL = new LectureBAL();
        private AdministratorBAL administratorBAL = new AdministratorBAL();
        private ViewerBAL viewerBAL = new ViewerBAL();
        private ViewerLectureBAL viewerLectureBAL = new ViewerLectureBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["event"] != null)
            {
                administrator = administratorBAL.GetAccount(User.Identity.Name);

                lecture.SetId(Convert.ToInt32(Request.QueryString["event"]));
                GetEventInformation(lecture.GetId());

                if (VerifyLectureStatus())
                {
                    if (!IsPostBack)
                    {
                        Viewer objViewer = new Viewer();
                        objViewer = GetUserAccount();

                        if (VerifyUserAlreadyRegistered(objViewer))
                        {
                            EventSubscribe.Text = "Cancelar Inscrição";
                        }
                        else
                        {
                            if (VerifyLectureHasVacancy() == false && administrator == null)
                            {
                                EventSubscribe.Text = "Vagas Esgotadas";
                                EventSubscribe.BackColor = Color.FromArgb(22, 25, 23);
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/View/Home/Home.aspx");
                }
            }
        }

        private bool VerifyLectureHasLimit()
        {
            bool isLectureLimited = false;
            if (lecture.GetLimit() != 0)
            {
                isLectureLimited = true;
            }
            return isLectureLimited;
        }

        private bool VerifyLectureHasVacancy()
        {
            bool hasVacancy = true;
            if (VerifyLectureHasLimit())
            {
                if (viewerLectureBAL.GetLectureRegistrationsNumber(lecture.GetId()) >= lecture.GetLimit())
                {
                    hasVacancy = false;
                }
            }
            return hasVacancy;
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
                    Viewer objViewer = new Viewer();
                    objViewer = GetUserAccount();

                    if (VerifyUserAlreadyRegistered(objViewer))
                    {
                        CancelRegisteToLecture(objViewer);
                    }
                    else
                    {
                        if (VerifyLectureHasVacancy() && administrator == null)
                        {
                            RegisterUserToLecture(objViewer);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Palestra Expirada!", "alert('Você não pode realizar/cancelar Inscrição a Palestras Inativas ou em Andamento!');", true);
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

        private void RegisterUserToLecture(Viewer objViewer)
        {
            if (objViewer != null)
            {
                ViewerLecture objViewerLecture = new ViewerLecture(objViewer, lecture);
                viewerLectureBAL.RegisterUserToLecture(objViewerLecture);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Usuário Cadastrado com Sucesso!", "alert('Cadastro a Palestra efetuado com sucesso!');", true);
                EventSubscribe.Text = "Cancelar Inscrição";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Usuário Inválido!", "alert('Esse tipo de usuário é inválido para efetuar inscrição á palestra!');", true);
            }
        }

        private void CancelRegisteToLecture(Viewer objViewer)
        {
            if (objViewer != null)
            {
                ViewerLecture objViewerLecture = new ViewerLecture(objViewer, lecture);
                viewerLectureBAL.DeleteUserSubscription(objViewerLecture);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Inscrição Cancelada!", "alert('Sua Inscrição a Palestra foi Cancelada!');", true);
                EventSubscribe.Text = "Inscrever-se";
            }   
        }

        private Viewer GetUserAccount()
        {
            Viewer objViewer = new Viewer();
            objViewer = viewerBAL.GetAccount(User.Identity.Name);
            return objViewer;
        }

        private bool VerifyUserAlreadyRegistered(Viewer objViewer)
        {
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