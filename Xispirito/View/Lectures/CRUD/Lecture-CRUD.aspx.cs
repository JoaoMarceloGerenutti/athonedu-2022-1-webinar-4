using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Lectures.CRUD
{
    public partial class Lecture_CRUD : System.Web.UI.Page
    {
        private AdministratorBAL administratorBAL = new AdministratorBAL();

        private Administrator administrator = new Administrator();
        private Lecture lecture = new Lecture();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    administrator.SetEmail(User.Identity.Name);
                    administrator = administratorBAL.GetAccount(administrator.GetEmail());

                    if (administrator != null)
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["lectureId"]))
                        {
                            lecture.SetId(Convert.ToInt32(Request.QueryString["lectureId"]));
                            LoadLectureInfo(lecture.GetId());
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
        }

        private void LoadLectureInfo(int lectureId)
        {
            GetLectureInfo(lectureId);
            SetLectureInfo(lecture);
        }

        private void GetLectureInfo(int lectureId)
        {
            LectureBAL lectureBAL = new LectureBAL();

            Lecture objLecture = new Lecture();
            objLecture = lectureBAL.GetLecture(lectureId);

            lecture = objLecture;
        }

        private void SetLectureInfo(Lecture objLecture)
        {
            ActionLecture.Text = "Editar Palestra";
            NameLecture.Text = lecture.GetName();
            DescriptionLecture.Text = lecture.GetDescription();
            DateLecture.Text = lecture.GetDate().ToString("dd/MM/yyyy");

            if (lecture.GetModality() == Convert.ToString((int)Modality.Online))
            {
                AddressLecture.Text = lecture.GetAddress();
            }

            LimitLecture.Text = lecture.GetLimit().ToString();
            ImageLecture.ImageUrl = lecture.GetPicture();
            //ImageViewer.ImageUrl = objViewer.GetPicture();
        }
    }
}