using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
                    ModalityLecture.DataSource = Enum.GetNames(typeof(Modality));
                    ModalityLecture.DataBind();

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

            ModalityLecture.SelectedValue = lecture.GetModality();
            ModalityLecture.BackColor = ModalityColor.GetModalityColor(ModalityLecture.SelectedValue);

            if (lecture.GetModality() != Convert.ToString((int)Modality.Online))
            {
                AddressLecture.Text = lecture.GetAddress();
            }

            LimitLecture.Text = lecture.GetLimit().ToString();
            ImageLecture.ImageUrl = lecture.GetPicture();
        }

        protected void ModalityLecture_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModalityLecture.BackColor = ModalityColor.GetModalityColor(ModalityLecture.SelectedValue);
        }

        protected void SubmitUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (LecturePhotoUpload.HasFile)
                {
                    try
                    {
                        if (LecturePhotoUpload.PostedFile.ContentType == "image/jpeg" || LecturePhotoUpload.PostedFile.ContentType == "image/png" || LecturePhotoUpload.PostedFile.ContentType == "image/gif" || LecturePhotoUpload.PostedFile.ContentType == "image/bmp")
                        {
                            try
                            {
                                HttpFileCollection hfc = Request.Files;
                                HttpPostedFile hpf = hfc[0];

                                if (hpf.ContentLength > 0)
                                {
                                    string clientFile = Path.GetFileName(hpf.FileName);
                                    string extension = Path.GetExtension(hpf.FileName);

                                    string lectureId = Cryptography.GetMD5Hash(lecture.GetId().ToString());
                                    string fileName = lectureId;

                                    string filePath = @"\View\Images\Lectures\" + lectureId;
                                    string folderPath = ConfigurationManager.AppSettings["XispiritoPath"] + filePath;
                                    if (!File.Exists(folderPath))
                                    {
                                        Directory.CreateDirectory(folderPath);
                                    }

                                    string mapPath = Server.MapPath(filePath) + fileName + extension;
                                    hpf.SaveAs(mapPath);

                                    // TODO: Put in the select image method.
                                    ImageLecture.ImageUrl = mapPath;
                                }
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error!", "alert('Um erro inesperado acorreu, tente novamente!');" + ex.Message, true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Archive Invalid!", "alert('Arquivo Inválido, É permitido carregar apenas arquivos em .JPEG .PNG .GIF .BMP');", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Error!", "alert('Um erro inesperado acorreu, tente novamente! ');" + ex.Message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error!", "alert('Um erro inesperado acorreu, tente novamente! ');" + ex.Message, true);
            }
        }
    }
}