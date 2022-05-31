using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class ViewerCertificateBAL
    {
        private ViewerCertificateDAL viewerCertificateDAL { get; set; }

        public ViewerCertificateBAL()
        {
            viewerCertificateDAL = new ViewerCertificateDAL();
        }

        public List<ViewerCertificate> GetUserCertificates(string userEmail)
        {
            List<ViewerCertificate> viewerCertificates = null;
            viewerCertificates = viewerCertificateDAL.GetAllUserCertificates(userEmail);

            return viewerCertificates;
        }

        public void SaveViewerCertificate(string userEmail, int certificateId)
        {
            viewerCertificateDAL.RegisterUserCertificate(userEmail, certificateId);
        }
    }
}