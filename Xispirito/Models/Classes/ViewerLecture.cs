using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models
{
    public class ViewerLecture : BaseEntity
    {
        private string ViewerEmail { get; set; }
        private int LectureId { get; set; }

        public ViewerLecture()
        {

        }

        public ViewerLecture(string viewerEmail, int lectureId)
        {
            ViewerEmail = viewerEmail;
            LectureId = lectureId;
        }

        public string GetViewerEmail()
        {
            return ViewerEmail;
        }

        public int GetLectureId()
        {
            return LectureId;
        }
    }
}