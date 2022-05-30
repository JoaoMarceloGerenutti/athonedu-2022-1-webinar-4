using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models
{
    public class ViewerCertificate
    {
        private string CertificatePicture { get; set; }
        private string ViewerEmail { get; set; }
        private int CertificateId { get; set; }

        public ViewerCertificate()
        {

        }

        public ViewerCertificate(string certificatePicture, string viewerEmail, int certificateId)
        {
            CertificatePicture = certificatePicture;
            ViewerEmail = viewerEmail;
            CertificateId = certificateId;
        }

        public string GetCertificatePicture()
        {
            return CertificatePicture;
        }

        public string GetViewerEmail()
        {
            return ViewerEmail;
        }

        public int GetCertificateId()
        {
            return CertificateId;
        }
    }
}