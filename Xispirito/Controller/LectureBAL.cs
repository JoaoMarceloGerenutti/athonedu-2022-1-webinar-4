using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xispirito.DAL;
using Xispirito.Models;

namespace Xispirito.Controller
{
    public class LectureBAL
    {
        private LectureDAL lectureDAL { get; set; }

        public LectureBAL()
        {
            lectureDAL = new LectureDAL();
        }

        public List<Lecture> GetUpcomingLecturesList(int lectureQuantity)
        {
            List<Lecture> lectureList = new List<Lecture>();
            lectureList = lectureDAL.UpcomingLecturesList(lectureQuantity);

            return lectureList;
        }

        public Lecture GetLecture(int lectureId)
        {
            Lecture lecture = new Lecture();
            lecture = lectureDAL.Select(lectureId);

            return lecture;
        }
    }
}