using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Certificates.Viewers
{
    public partial class ViewerCertificates : System.Web.UI.Page
    {
        private ViewerCertificateBAL viewerCertificateBAL = new ViewerCertificateBAL();

        private List<ViewerCertificate> viewerCertificates = new List<ViewerCertificate>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && User.Identity.IsAuthenticated)
            {
                if (Request.QueryString["user"] != null && User.Identity.Name == Request.QueryString["user"])
                {
                    viewerCertificates = new List<ViewerCertificate>();
                    viewerCertificates = viewerCertificateBAL.GetUserCertificates(User.Identity.Name);

                    if (viewerCertificates != null)
                    {
                        MyCertificates.Text += "(" + viewerCertificates.Count + ")";
                    }
                    else
                    {
                        MyCertificates.Text += "(0)";
                    }

                    ListViewCertificates.DataSource = viewerCertificates;
                    ListViewCertificates.DataBind();
                }
                else
                {
                    Response.Redirect("~/View/Home/Home.aspx");
                }
            }
        }

        protected void ListViewCertificates_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ViewerCertificate viewerCertificate = (ViewerCertificate)e.Item.DataItem;

                string path = @"\View\Images\Certificates\Viewers\" + viewerCertificate.GetViewer().GetEmail() + @"\" + Cryptography.GetMD5Hash(viewerCertificate.GetCertificate().GetId().ToString());

                Image certificateImage = (Image)e.Item.FindControl("CertificateImage");
                certificateImage.ImageUrl = path + ".png";

                Label titleLabel = (Label)e.Item.FindControl("CertificateTitle");
                titleLabel.Text = viewerCertificate.GetLecture().GetName();

                Label dateLabel = (Label)e.Item.FindControl("CertificateDate");
                dateLabel.Text = viewerCertificate.GetLecture().GetDate().ToString("dd/MM/yyyy HH:mm");

                string certificateKey = viewerCertificate.GetCertificate().GetId().ToString();
                Button downloadButton = (Button)e.Item.FindControl("DownloadCertificate");
                downloadButton.CommandArgument = Cryptography.GetMD5Hash(certificateKey);
            }
        }

        protected void SearchCertificate_TextChanged(object sender, EventArgs e)
        {
            if (SearchCertificate.Text.ToLower() == "gerar")
            {
                SearchCertificate.Text = "";

                for (int i = 1; i <= 7; i++)
                {
                    Viewer viewer = new Viewer();
                    ViewerBAL viewerBAL = new ViewerBAL();
                    viewer = viewerBAL.GetAccount(User.Identity.Name);

                    Lecture lecture = new Lecture();
                    LectureBAL lectureBAL = new LectureBAL();
                    lecture = lectureBAL.GetLecture(i);

                    Certificate certificate = new Certificate();
                    CertificateBAL certificateBAL = new CertificateBAL();
                    certificate = certificateBAL.GetCertificateById(i);

                    CertificateGenerator.GenerateViewerCertificatePDF(viewer, lecture, certificate);
                }
            }
        }

        protected void DownloadCertificate_Click(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string certificateKey = clickedButton.CommandArgument;
            string userPath = ConfigurationManager.AppSettings["XispiritoPath"] + @"\View\Images\Certificates\Viewers\" + User.Identity.Name + @"\" + certificateKey + ".pdf";

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