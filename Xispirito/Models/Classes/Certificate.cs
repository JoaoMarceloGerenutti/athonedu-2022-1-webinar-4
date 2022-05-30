using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models
{
    public class Certificate : BaseEntity
    {
        private int CertificateId { get; set; }
        private int LectureId { get; set; }

        public Certificate()
        {

        }

        public Certificate(int certificateId, int lectureId, bool isActive)
        {
            CertificateId = certificateId;
            LectureId = lectureId;
            IsActive = isActive;
        }

        public int GetId()
        {
            return CertificateId;
        }

        public int GetLectureId()
        {
            return LectureId;
        }
    }
}