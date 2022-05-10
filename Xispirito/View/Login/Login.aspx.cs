using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;

namespace Xispirito.View.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignIn_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            string email = SignIn.UserName;
            string password = SignIn.Password;

            // Viewer Login.
            ViewerBAL vDal = new ViewerBAL();
            bool emailFound = vDal.SignIn(email, password);

            if (!emailFound)
            {
                // Speaker Login.
                SpeakerBAL sBAL = new SpeakerBAL();
                emailFound = sBAL.SignIn(email, password);

                if (!emailFound)
                {
                    // Administrator Login.
                    AdministratorBAL aBAL = new AdministratorBAL();
                    emailFound = aBAL.SignIn(email, password);
                }
            }

            if (emailFound)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Logado com Sucesso!", "alert('Seja Bem Vindo!');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Login Inválido!", "alert('Verifique seu E-mail e/ou Senha e tente novamente!');", true);
            }

            e.Authenticated = emailFound;
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            //BaseUser baseUser = new BaseUser();

            //baseUser.SetEmail(SignInEmail.Text);
            //baseUser.SetEncryptedPassword(Cryptography.GetMD5Hash(SignInPassword.Text));

            //// Viewer Login.
            //ViewerDAL vDal = new ViewerDAL();
            //bool emailFound = vDal.SignIn(baseUser.GetEmail(), baseUser.GetEncryptedPassword());
            //if (!emailFound)
            //{
            //    // Speaker Login.
            //    SpeakerDAL sDAL = new SpeakerDAL();
            //    emailFound = sDAL.SignIn(baseUser.GetEmail(), baseUser.GetEncryptedPassword());

            //    if (!emailFound)
            //    {
            //        // Administrator Login.
            //        AdministratorDAL aDAL = new AdministratorDAL();
            //        emailFound = aDAL.SignIn(baseUser.GetEmail(), baseUser.GetEncryptedPassword());
            //    }
            //}
            
            //if (emailFound)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Logado com Sucesso!", "alert('Seja Bem Vindo!');", true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Login Inválido!", "alert('Verifique seu E-mail e/ou Senha e tente novamente!');", true);
            //}

            //LimpaCampos();
            //Login1.UserName = emailSalvo;
        }
    }
}