using System;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.MasterPage
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private ViewerBAL viewerBAL = new ViewerBAL();
        private SpeakerBAL speakerBAL = new SpeakerBAL();
        private AdministratorBAL administratorBAL = new AdministratorBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Page.User.Identity.IsAuthenticated)
            {
                // Load User Information.
                GetUserInformation();
            }
        }

        private void GetUserInformation()
        {
            BaseUser user;
            string userRole;
            string userType;

            string accountEmail = Page.User.Identity.Name.ToString();
            if (FindViewerAccount(accountEmail))
            {
                user = viewerBAL.GetAccount(accountEmail);
                userRole = "Aluno";
                userType = "Viewer";
            }
            else if (FindSpeakerAccount(accountEmail))
            {
                user = speakerBAL.GetAccount(accountEmail);
                userRole = "Palestrante";
                userType = "Speaker";
            }
            else
            {
                user = administratorBAL.GetAccount(accountEmail);
                userRole = "Administrador";
                userType = "Administrator";
            }
            SetUserInformation(user, userRole, userType);
        }

        private void SetUserInformation(BaseUser user, string userRole, string userType)
        {
            Image userPicture = (Image)MasterLoginView.FindControl("UserPicture");
            if (user.GetPicture() != "")
            {
                userPicture.ImageUrl = user.GetPicture();
            }
            else
            {
                userPicture.ImageUrl = @"~/View/Images/User.png";
            }

            Label UserName = (Label)MasterLoginView.FindControl("UserName");
            UserName.Text = user.GetName();

            Label UserRole = (Label)MasterLoginView.FindControl("UserRole");
            UserRole.Text = userRole;

            Image image = (Image)MasterLoginView.FindControl("Profile");
            LinkButton UserProfile = (LinkButton)MasterLoginView.FindControl("UserProfile");
            if (userType == "Administrator")
            {
                UserProfile.PostBackUrl = "~/View/Lectures/CRUD/Lecture-CRUD.aspx";
                UserProfile.Text = "Administrar";

                image.ImageUrl = @"~/View/Images/Administrator.png";
            }
            else
            {
                UserProfile.PostBackUrl = @"~/View/Profiles/" + userType + "/" + userType + ".aspx";
                UserProfile.Text = "Editar Perfil";

                image.ImageUrl = @"~/View/Images/Profile.png";
            }

            LinkButton UserCertificates = (LinkButton)MasterLoginView.FindControl("UserCertificates");
            UserCertificates.PostBackUrl = "~/View/Certificates/" + userType + "s" + "/Certificates.aspx";

            Certificates.PostBackUrl = UserCertificates.PostBackUrl;
        }

        private bool FindViewerAccount(string userEmail)
        {
            bool accountFound = viewerBAL.VerifyAccount(userEmail);

            if (accountFound == true)
            {
                accountFound = viewerBAL.VerifyAccountStatus(viewerBAL.GetAccount(userEmail));
            }
            return accountFound;
        }

        private bool FindSpeakerAccount(string userEmail)
        {
            bool accountFound = speakerBAL.VerifyAccount(userEmail);

            if (accountFound == true)
            {
                accountFound = speakerBAL.VerifyAccountStatus(speakerBAL.GetAccount(userEmail));
            }
            return accountFound;
        }
    }
}