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
    public partial class Lecture_CRUD : Page
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
                    ChangeModalityBackColor();
                    ChangeAddressVisibility();

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

            if (lecture.GetModality() != Enum.GetName(typeof(Modality), 0))
            {
                AddressLecture.Visible = true;
                AddressLecture.Text = lecture.GetAddress();
            }
            else
            {
                AddressLecture.Visible = false;
            }

            LimitLecture.Text = lecture.GetLimit().ToString();
            ImageLecture.ImageUrl = lecture.GetPicture();
        }

        private void ChangeModalityBackColor()
        {
            ModalityLecture.BackColor = ModalityColor.GetModalityColor(ModalityLecture.SelectedValue);
        }

        private void ChangeAddressVisibility()
        {
            if (ModalityLecture.SelectedValue != Enum.GetName(typeof(Modality), 0))
            {
                AddressLecture.Visible = true;
                AddressLecture.Text = lecture.GetAddress();
            }
            else
            {
                AddressLecture.Visible = false;
            }
        }

        protected void ModalityLecture_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeModalityBackColor();
            ChangeAddressVisibility();
        }

        protected void SubmitUpdate_Click(object sender, EventArgs e)
        {
            Lecture objLecture = new Lecture();

            LectureBAL lectureBAL = new LectureBAL();
            if (lecture.GetName() != null)
            {
                // UPDATE
                objLecture = GetUpdateInformation();
                lectureBAL.UpdateLecture(objLecture);
            }
            else
            {
                if (administrator != null)
                {
                    // INSERT
                    objLecture = GetInsertInformation();
                    lectureBAL.InsertLecture(objLecture);
                }
            }
            SaveUploadImage();
        }

        private Lecture GetUpdateInformation()
        {
            DateTime lectureStart = DateTime.Now;
            DateTime lectureEnd = DateTime.Now;
            lectureEnd.AddHours(1);

            string address = "";
            if (AddressLecture.Visible)
            {
                address = AddressLecture.Text;
            }

            int limit = Convert.ToInt32(LimitLecture.Text);
            bool isLimited = false;
            if (limit > 0)
            {
                isLimited = true;
            }

            Lecture objLecture = new Lecture(
                lecture.GetId(),
                NameLecture.Text,
                lecture.GetPicture(),
                CalculateLectureTime(lectureStart, lectureEnd),
                Convert.ToDateTime(DateLecture.Text),
                DescriptionLecture.Text,
                ModalityLecture.SelectedValue,
                address,
                isLimited,
                limit,
                true
            );

            return objLecture;
        }

        private Lecture GetInsertInformation()
        {
            // Adaptar para funcional depois.
            DateTime lectureStart = DateTime.Now;
            DateTime lectureEnd = DateTime.Now;
            lectureEnd.AddHours(1);

            string address = "";
            if (AddressLecture.Visible)
            {
                address = AddressLecture.Text;
            }

            int limit = Convert.ToInt32(LimitLecture.Text);
            bool isLimited = false;
            if (limit > 0)
            {
                isLimited = true;
            }

            DateTime dateTimeLecture = Convert.ToDateTime(DateLecture.Text);
            dateTimeLecture.AddHours(lectureStart.Hour);
            dateTimeLecture.AddMinutes(lectureStart.Minute);

            Lecture objLecture = new Lecture(
                lecture.GetId(),
                NameLecture.Text,
                lecture.GetPicture(),
                CalculateLectureTime(lectureStart, lectureEnd),
                dateTimeLecture,
                DescriptionLecture.Text,
                ModalityLecture.SelectedValue,
                address,
                isLimited,
                limit,
                true
            );

            return objLecture;
        }

        private int CalculateLectureTime(DateTime lectureStart, DateTime lectureEnd)
        {
            Random random = new Random();
            int lectureTimeInMinutes = random.Next(20, 180);
            return lectureTimeInMinutes;
        }

        private void SaveUploadImage()
        {
            if (LecturePhotoUpload.HasFile)
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
        }
    }
}