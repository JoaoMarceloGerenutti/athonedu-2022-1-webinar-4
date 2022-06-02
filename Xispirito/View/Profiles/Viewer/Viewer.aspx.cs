using System;
using System.Web.UI;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.Profile_Viewer
{
    public partial class Profile_Viewer : Page
    {
        private ViewerBAL viewerBAL = new ViewerBAL();

        private Viewer viewer = new Viewer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    viewer.SetEmail(User.Identity.Name);
                    LoadViewerProfile(viewer.GetEmail());
                }
                else
                {
                    Response.Redirect("~/View/Login/Login.aspx");
                }
            }
        }

        private void LoadViewerProfile(string viewerEmail)
        {
            GetViewerProfile(viewerEmail);
            SetViewerProfile(viewer);
        }

        private void GetViewerProfile(string viewerEmail)
        {
            Viewer objViewer = new Viewer();
            objViewer = viewerBAL.GetAccount(viewerEmail);

            viewer = objViewer;
        }

        private void SetViewerProfile(Viewer objViewer)
        {
            NameViewer.Text = objViewer.GetName();
            EmailViewer.Text = objViewer.GetEmail();
            ImageViewer.ImageUrl = objViewer.GetPicture();
        }

        protected void SubmitUpdate_Click(Object sender, EventArgs e)
        {
            _ = new Viewer();
            Viewer updatedViewer = viewerBAL.GetAccount(User.Identity.Name);

            string updateName = NameViewer.Text;
            if (!string.IsNullOrEmpty(updateName) && updatedViewer.GetName() != updateName)
            {
                updatedViewer.SetName(updateName);
            }

            if (!string.IsNullOrEmpty(PasswordViewer.Text))
            {
                string updatePassword = Cryptography.GetMD5Hash(PasswordViewer.Text);

                if (updatedViewer.GetEncryptedPassword() != updatePassword)
                {
                    updatedViewer.SetEncryptedPassword(updatePassword);
                }
            }

            if (updatedViewer != viewer)
            {
                viewerBAL.UpdateViewerAccount(updatedViewer);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Perfil Atualizado com Sucesso!", "alert('Perfil Atualizado com Sucesso!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Faça algum Alteração!", "alert('Altere alguma Informação para atualizar os dados do Perfil!');", true);
            }
        }
    }
}