using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Certificates.Viewer
{
    public partial class ViewerCertificates : System.Web.UI.Page
    {
        private ViewerCertificateBAL viewerCertificateBAL = new ViewerCertificateBAL();
        private List<Certificate> certificates;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && User.Identity.IsAuthenticated)
            {
                if (Request.QueryString["user"] != null && User.Identity.Name == Request.QueryString["user"])
                {
                    certificates = new List<Certificate>();
                    certificates = viewerCertificateBAL.GetUserCertificates(User.Identity.Name);

                    ListViewCertificates.DataSource = certificates;
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
                Certificate certificate = (Certificate)e.Item.DataItem;
                Lecture lectures = (Lecture)e.Item.DataItem;

                //Image certificateImage = (Image)e.Item.FindControl("CertificateImage");
                //certificateImage.ImageUrl = certificate.GetPicture();

                //Label titleLabel = (Label)e.Item.FindControl("CertificateTitle");
                //titleLabel.Text = lectures.GetName();

                //Label dateLabel = (Label)e.Item.FindControl("CertificateDate");
                //dateLabel.Text = certificate.GetModality();

                //Button downloadButton = (Button)e.Item.FindControl("DownloadCertificate");
                //downloadButton.PostBackUrl = certificate.GetTime().ToString();
            }
        }
    }
}