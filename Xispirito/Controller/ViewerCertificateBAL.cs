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

        public List<Certificate> GetUserCertificates(string userEmail)
        {
            List<ViewerCertificate> viewerCertificates = null;
            viewerCertificates = viewerCertificateDAL.GetAllUserCertificates(userEmail);

            CertificateDAL certificateDAL = new CertificateDAL();
            List<Certificate> certificates = new List<Certificate>();

            if (viewerCertificates != null)
            {
                foreach (ViewerCertificate viewerCertificate in viewerCertificates)
                {
                    certificates.Add(certificateDAL.Select(viewerCertificate.GetCertificateId()));
                }
            }

            return certificates;
        }
    }
}