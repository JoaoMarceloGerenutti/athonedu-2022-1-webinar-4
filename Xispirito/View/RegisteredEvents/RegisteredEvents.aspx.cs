using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.RegisteredEvents
{
    public partial class RegisteredEvents : Page
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
                    FilterEvents.Text = search;
                }
                else
                {
                    viewerCertificates = viewerCertificateBAL.GetUserCertificates(User.Identity.Name);
                }

                if (viewerCertificates != null)
                {
                    MyEvents.Text += "(" + viewerCertificates.Count + ")";
                    ListViewEvents.DataSource = viewerCertificates;
                    ListViewEvents.DataBind();
                }
                else
                {
                    MyEvents.Text += "(0)";
                }
            }
        }

        protected void SearchEvents_Click(object sender, EventArgs e)
        {
            string search = FilterEvents.Text;

            if (search != null)
            {
                Response.Redirect("~/View/RegisteredEvents/RegisteredEvents.aspx?eventSearch=" + search);
            }
        }

        protected void ListViewEvents_ItemDataBound(object sender, ListViewItemEventArgs e)
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
    }
}