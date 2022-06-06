using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Certificates.Viewers
{
    public partial class ViewerCertificates : Page
    {
        private ViewerCertificateBAL viewerCertificateBAL = new ViewerCertificateBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && User.Identity.IsAuthenticated)
            {
                LoadCertificatesDataBound(viewerCertificateBAL.GetUserCertificates(User.Identity.Name));
            }
        }

        private void LoadCertificatesDataBound(List<ViewerCertificate> viewerCertificates)
        {
            string title = "Meus Certificados ";
            if (viewerCertificates != null)
            {
                MyCertificates.Text = title + "(" + viewerCertificates.Count + ")";
                ListViewCertificates.Items.Clear();
                ListViewCertificates.DataSource = viewerCertificates;
                ListViewCertificates.DataBind();
            }
            else
            {
                MyCertificates.Text = title + "(0)";
            }
        }

        protected void SearchCertificate_Click(object sender, EventArgs e)
        {
            string search = FilterCertificate.Text;

            if (search != null)
            {
                LoadCertificatesDataBound(viewerCertificateBAL.GetUserCertificates(User.Identity.Name, search));
            }

            if (search.ToLower() == "gerar")
            {
                FilterCertificate.Text = "";

                Viewer viewer = new Viewer();
                ViewerBAL viewerBAL = new ViewerBAL();
                viewer = viewerBAL.GetAccount(User.Identity.Name);

                LectureBAL lectureBAL = new LectureBAL();
                CertificateBAL certificateBAL = new CertificateBAL();

                for (int i = 1; i <= 6; i++)
                {
                    Lecture lecture = new Lecture();
                    lecture = lectureBAL.GetLecture(i);

                    Certificate certificate = new Certificate();
                    certificate = certificateBAL.GetCertificateById(i);

                    CertificateGenerator.GenerateViewerCertificatePDF(viewer, lecture, certificate);
                }
            }
        }

        protected void ListViewCertificates_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ViewerCertificate viewerCertificate = (ViewerCertificate)e.Item.DataItem;

                string certificateKey = Cryptography.GetMD5Hash(viewerCertificate.GetViewer().GetEmail() + viewerCertificate.GetCertificate().GetId().ToString());
                string path = @"\UsersData\Viewers\" + Cryptography.GetMD5Hash(User.Identity.Name) + @"\Certificates\" + certificateKey;

                Image certificateImage = (Image)e.Item.FindControl("CertificateImage");
                certificateImage.ImageUrl = path + ".png";

                Label titleLabel = (Label)e.Item.FindControl("CertificateTitle");
                titleLabel.Text = viewerCertificate.GetLecture().GetName();

                Label dateLabel = (Label)e.Item.FindControl("CertificateDate");
                dateLabel.Text = viewerCertificate.GetLecture().GetDate().ToString("dd/MM/yyyy HH:mm");

                Button downloadButton = (Button)e.Item.FindControl("DownloadCertificate");
                downloadButton.CommandArgument = certificateKey;
            }
        }

        protected void DownloadCertificate_Click(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string certificateKey = clickedButton.CommandArgument;
            string userPath = ConfigurationManager.AppSettings["XispiritoPath"] + @"\UsersData\Viewers\" + Cryptography.GetMD5Hash(User.Identity.Name) + @"\Certificates\" + certificateKey + ".pdf";

            DownloadCertificate(userPath, certificateKey);
        }

        public void DownloadCertificate(string path, string certificateKey)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=" + certificateKey + ".pdf");
            Response.TransmitFile(path);
            Response.End();
        }
    }
}