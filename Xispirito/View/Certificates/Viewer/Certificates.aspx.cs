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

                Image certificateImage = (Image)e.Item.FindControl("CertificateImage");
                certificateImage.ImageUrl = @"\View\Images\Certificates\Viewer\" + viewerCertificate.GetViewer().GetEmail() + @"\" + Cryptography.GetMD5Hash(viewerCertificate.GetCertificate().GetId().ToString()) + ".jpg";

                Label titleLabel = (Label)e.Item.FindControl("CertificateTitle");
                titleLabel.Text = viewerCertificate.GetLecture().GetName();

                Label dateLabel = (Label)e.Item.FindControl("CertificateDate");
                dateLabel.Text = viewerCertificate.GetLecture().GetDate().ToString("dd/MM/yyyy HH:mm");

                //Button downloadButton = (Button)e.Item.FindControl("DownloadCertificate");
                //downloadButton.PostBackUrl = certificate.GetTime().ToString();
            }
        }
    }
}