using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Lectures.ViewLecture
{
    public partial class Lecture_View : Page
    {
        UserType userType;

        private ViewerBAL viewerBAL = new ViewerBAL();
        private ViewerLectureBAL viewerLectureBAL = new ViewerLectureBAL();
        private ViewerWatchedLectureBAL viewerWatchedLectureBAL = new ViewerWatchedLectureBAL();

        private SpeakerBAL speakerBAL = new SpeakerBAL();
        private SpeakerLectureBAL speakerLectureBAL = new SpeakerLectureBAL();
        private SpeakerWatchedLectureBAL speakerWatchedLectureBAL = new SpeakerWatchedLectureBAL();

        private AdministratorBAL administratorBAL = new AdministratorBAL();
        private AdministratorLectureBAL administratorLectureBAL = new AdministratorLectureBAL();
        private AdministratorWatchedLectureBAL administratorWatchedLectureBAL = new AdministratorWatchedLectureBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["lectureId"]))
                {
                    int lectureId = Convert.ToInt32(Request.QueryString["lectureId"]);

                    GetAccount(User.Identity.Name);

                    bool userFound = false;
                    if (userType == UserType.Administrator)
                    {
                        if (administratorLectureBAL.GetUserLectureRegistration(User.Identity.Name, lectureId) != null)
                        {
                            administratorWatchedLectureBAL.RegisterUserToLecture(User.Identity.Name, lectureId);
                            userFound = true;
                        }
                    }
                    else if (userType == UserType.Speaker)
                    {
                        if (speakerLectureBAL.GetUserLectureRegistration(User.Identity.Name, lectureId) != null)
                        {
                            speakerWatchedLectureBAL.RegisterUserToLecture(User.Identity.Name, lectureId);
                            userFound = true;
                        }
                    }
                    else
                    {
                        if (viewerLectureBAL.GetUserLectureRegistration(User.Identity.Name, lectureId) != null)
                        {
                            viewerWatchedLectureBAL.GetUserLectureRegistration(User.Identity.Name, lectureId);
                            userFound = true;
                        }
                    }

                    if (!userFound)
                    {
                        Response.Redirect("~/View/Home/Home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/View/Home/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/View/Login/Login.aspx");
            }
        }

        private BaseUser GetAccount(string email)
        {
            BaseUser baseUser = new BaseUser();
            if (!viewerBAL.VerifyAccount(email))
            {
                if (!speakerBAL.VerifyAccount(email))
                {
                    if (administratorBAL.VerifyAccount(email))
                    {
                        userType = UserType.Administrator;
                        baseUser = administratorBAL.GetAccount(email);
                    }
                }
                else
                {
                    userType = UserType.Speaker;
                    baseUser = speakerBAL.GetAccount(email);
                }
            }
            else
            {
                userType = UserType.Viewer;
                baseUser = viewerBAL.GetAccount(email);
            }
            return baseUser;
        }
    }
}