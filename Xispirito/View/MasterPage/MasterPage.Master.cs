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

        private Viewer viewer = new Viewer();
        private Speaker speaker = new Speaker();
        private Administrator administrator = new Administrator();

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
            BaseUser user = new BaseUser();
            string userRole = "";
            string userType = "";

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
            userPicture.ImageUrl = user.GetPicture();

            Label UserName = (Label)MasterLoginView.FindControl("UserName");
            UserName.Text = user.GetName();

            Label UserRole = (Label)MasterLoginView.FindControl("UserRole");
            UserRole.Text = userRole;

            LinkButton UserProfile = (LinkButton)MasterLoginView.FindControl("UserProfile");
            UserProfile.PostBackUrl = "~/View/Profiles/" + userType + "/" + userType + ".aspx?user=" + user.GetEmail();

            //LinkButton UserCertificates = (LinkButton)MasterLoginView.FindControl("UserCertificates");
            //UserCertificates.PostBackUrl = "";
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