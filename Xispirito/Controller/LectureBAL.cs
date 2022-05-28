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

        public List<Lecture> GetUpcomingLecturesList()
        {
            List<Lecture> lectureList = new List<Lecture>();
            lectureList = lectureDAL.UpcomingLecturesList();

            return lectureList;
        }

        public List<Lecture> GetUpcomingLecturesList(int maxQuantity)
        {
            List<Lecture> lectureList = new List<Lecture>();
            lectureList = lectureDAL.UpcomingLecturesList(maxQuantity);

            return lectureList;
        }

        public List<Lecture> GetLecturesList()
        {
            List<Lecture> lectureList = new List<Lecture>();
            lectureList = lectureDAL.LecturesList();

            return lectureList;
        }

        public List<Lecture> GetLecturesList(int maxQuantity)
        {
            List<Lecture> lectureList = new List<Lecture>();
            lectureList = lectureDAL.LecturesList(maxQuantity);

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