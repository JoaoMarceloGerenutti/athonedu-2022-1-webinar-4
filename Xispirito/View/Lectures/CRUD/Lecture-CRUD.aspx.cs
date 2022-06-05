using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Lectures.CRUD
{
    public partial class Lecture_CRUD : Page
    {
        private AdministratorBAL administratorBAL = new AdministratorBAL();

        private Administrator administrator = new Administrator();

        private bool insertMode;

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
                            insertMode = false;
                            Lecture lecture = new Lecture();
                            lecture.SetId(Convert.ToInt32(Request.QueryString["lectureId"]));
                            LoadLectureInfo(lecture.GetId());
                        }
                        else
                        {
                            insertMode = true;
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
            SetLectureInfo(GetLectureInfo(lectureId));
        }

        private Lecture GetLectureInfo(int lectureId)
        {
            LectureBAL lectureBAL = new LectureBAL();

            Lecture objLecture = new Lecture();
            objLecture = lectureBAL.GetLecture(lectureId);

            return objLecture;
        }

        private void SetLectureInfo(Lecture objLecture)
        {
            ActionLecture.Text = "Editar Palestra";
            NameLecture.Text = objLecture.GetName();
            DescriptionLecture.Text = objLecture.GetDescription();
            DateLecture.Text = objLecture.GetDate().ToString("dd/MM/yyyy");

            StartTime.Value = objLecture.GetDate().ToString("HH:mm");

            DateTime dateTime = objLecture.GetDate();
            dateTime = dateTime.AddMinutes(objLecture.GetTime());

            EndTime.Value = dateTime.ToString("HH:mm");

            ModalityLecture.SelectedValue = objLecture.GetModality();
            ModalityLecture.BackColor = ModalityColor.GetModalityColor(ModalityLecture.SelectedValue);

            if (objLecture.GetModality() != Enum.GetName(typeof(Modality), 0))
            {
                AddressLecture.Visible = true;
                AddressLecture.Text = objLecture.GetAddress();
            }
            else
            {
                AddressLecture.Visible = false;
            }

            LimitLecture.Text = objLecture.GetLimit().ToString();
            ImageLecture.ImageUrl = objLecture.GetPicture();

            ChangeModalityBackColor();
            ChangeAddressVisibility(objLecture);
        }

        private void ChangeModalityBackColor()
        {
            ModalityLecture.BackColor = ModalityColor.GetModalityColor(ModalityLecture.SelectedValue);
        }

        private void ChangeAddressVisibility(Lecture objLecture)
        {
            if (ModalityLecture.SelectedValue != Enum.GetName(typeof(Modality), 0))
            {
                AddressLecture.Visible = true;
                AddressLecture.Text = objLecture.GetAddress();
            }
            else
            {
                AddressLecture.Visible = false;
            }
        }

        protected void ModalityLecture_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeModalityBackColor();
            ChangeAddressVisibility(GetLectureInfo(Convert.ToInt32(Request.QueryString["lectureId"])));
        }

        protected void SubmitUpdate_Click(object sender, EventArgs e)
        {
            Lecture objLecture = new Lecture();

            LectureBAL lectureBAL = new LectureBAL();
            if (insertMode == false)
            {
                // UPDATE
                objLecture = GetLectureInfo(Convert.ToInt32(Request.QueryString["lectureId"]));
                objLecture = GetInformation(objLecture.GetId());

                lectureBAL.UpdateLecture(objLecture);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Palestra Editada!", "alert('Palestra Editada com Sucesso!');", true);
            }
            else
            {
                if (administrator != null)
                {
                    // INSERT
                    objLecture.SetId(lectureBAL.GetNextId());
                    objLecture = GetInformation(objLecture.GetId());

                    lectureBAL.InsertLecture(objLecture);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Palestra Cadastrada!", "alert('Palestra Cadastrada com Sucesso!');", true);
                }
            }
        }

        private Lecture GetInformation(int lectureId)
        {
            string address = "";
            if (AddressLecture.Visible)
            {
                address = AddressLecture.Text;
            }

            int limit = Convert.ToInt32(LimitLecture.Text);

            Lecture objLecture = new Lecture(
                lectureId,
                NameLecture.Text,
                SaveUploadImage(lectureId),
                CalculateLectureTime(),
                Convert.ToDateTime(DateLecture.Text + " " + StartTime.Value),
                DescriptionLecture.Text,
                ModalityLecture.SelectedValue,
                address,
                limit,
                true
            );
            return objLecture;
        }

        private int CalculateLectureTime()
        {
            int minutes;

            string date = DateLecture.Text;
            DateTime startDateTime = Convert.ToDateTime(date + " " + StartTime.Value);
            DateTime endDateTime = Convert.ToDateTime(date + " " + EndTime.Value);

            TimeSpan timeSpan;
            if (startDateTime.Hour < endDateTime.Hour)
            {
                timeSpan = startDateTime - endDateTime;
                minutes = Convert.ToInt32((timeSpan.TotalHours / 60) + timeSpan.TotalMinutes);
            }
            else
            {
                double dayHours;
                dayHours = ((startDateTime.Hour - endDateTime.Hour) - 24) * -1;

                double dayMinutes;
                if (startDateTime.Minute > endDateTime.Minute)
                {
                    dayMinutes = (startDateTime.Minute - endDateTime.Minute);
                }
                else
                {
                    dayMinutes = (endDateTime.Minute - startDateTime.Minute);
                }
                minutes = Convert.ToInt32((dayHours * 60) + dayMinutes);
            }

            if (minutes < 0)
            {
                minutes = minutes * -1;
            }

            return minutes;
        }

        private string SaveUploadImage(int lectureId)
        {
            string cryptographLectureId = Cryptography.GetMD5Hash(lectureId.ToString());
            string fileName = cryptographLectureId;

            string filePath = @"\View\Images\Lectures\" + cryptographLectureId;

            HttpFileCollection hfc = null;
            HttpPostedFile hpf = null;

            string clientFile = "";
            string extension = "";
            if (LecturePhotoUpload.HasFile)
            {
                if (LecturePhotoUpload.PostedFile.ContentType == "image/jpeg" || LecturePhotoUpload.PostedFile.ContentType == "image/png" || LecturePhotoUpload.PostedFile.ContentType == "image/gif" || LecturePhotoUpload.PostedFile.ContentType == "image/bmp")
                {
                    try
                    {
                        hfc = Request.Files;
                        hpf = hfc[0];

                        if (hpf.ContentLength > 0)
                        {
                            clientFile = Path.GetFileName(hpf.FileName);
                            extension = Path.GetExtension(hpf.FileName);

                            string folderPath = ConfigurationManager.AppSettings["XispiritoPath"] + filePath;
                            if (!File.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            string mapPath = Server.MapPath(filePath) + @"\" + fileName + extension;
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
            return filePath + @"\" + cryptographLectureId + extension;
        }
    }
}