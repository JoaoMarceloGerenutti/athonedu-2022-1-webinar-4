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

        private List<ViewerCertificate> viewerCertificates = new List<ViewerCertificate>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && User.Identity.IsAuthenticated)
            {
                if (Request.QueryString["certificateSearch"] != null)
                {
                    string search = Request.QueryString["certificateSearch"];
                    viewerCertificates = viewerCertificateBAL.GetFilterUserCertificates(User.Identity.Name, search);
                    FilterCertificate.Text = search;
                }
                else
                {
                    viewerCertificates = viewerCertificateBAL.GetUserCertificates(User.Identity.Name);
                }

                if (viewerCertificates != null)
                {
                    MyCertificates.Text += "(" + viewerCertificates.Count + ")";
                    ListViewCertificates.DataSource = viewerCertificates;
                    ListViewCertificates.DataBind();
                }
                else
                {
                    MyCertificates.Text += "(0)";
                }
            }
        }

        protected void ListViewCertificates_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ViewerCertificate viewerCertificate = (ViewerCertificate)e.Item.DataItem;

                string certificateKey = Cryptography.GetMD5Hash(viewerCertificate.GetViewer().GetEmail() + viewerCertificate.GetCertificate().GetId().ToString());
                string path = @"\View\Images\Certificates\Viewers\" + viewerCertificate.GetViewer().GetEmail() + @"\" + certificateKey;

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

        protected void SearchCertificate_Click(object sender, EventArgs e)
        {
            string search = FilterCertificate.Text;

            if (search.ToLower() == "gerar")
            {
                FilterCertificate.Text = "";

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
            else
            {
                if (search != null)
                {
                    Response.Redirect("~/View/Certificates/Viewers/Certificates.aspx?certificateSearch=" + search);
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