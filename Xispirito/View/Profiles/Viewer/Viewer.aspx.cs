using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Profile_Viewer
{
    public partial class Profile_Viewer : System.Web.UI.Page
    {
        private ViewerBAL viewerBAL = new ViewerBAL();

        private Viewer viewer = new Viewer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && User.Identity.IsAuthenticated)
            {
                if (Request.QueryString["user"] != null && User.Identity.Name == Request.QueryString["user"])
                {
                    viewer.SetEmail(Request.QueryString["user"]);
                    LoadViewerProfile(viewer.GetEmail());
                }
                else
                {
                    Response.Redirect("~/View/Home/Home.aspx");
                }
            }
        }

        private void LoadViewerProfile(string viewerEmail)
        {
            viewer = GetViewerProfile(viewerEmail);

            SetViewerProfile(viewer);
        }

        private Viewer GetViewerProfile(string viewerEmail)
        {
            viewer = viewerBAL.GetAccount(viewerEmail);

            return viewer;
        }

        private void SetViewerProfile(Viewer objViewer)
        {
            NameViewer.Text = objViewer.GetName();
            EmailViewer.Text = objViewer.GetEmail();
            ImageViewer.ImageUrl = objViewer.GetPicture();
        }

        protected void SubmitUpdate_Click(Object sender, EventArgs e)
        {
            
        }

        protected void SubmitUpdate_OnClientClick(Object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "showPopup", "confirm('Deseja aplicar as alterações?')", true);
        }
    }
}