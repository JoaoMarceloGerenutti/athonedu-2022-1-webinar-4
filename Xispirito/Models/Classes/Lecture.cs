using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class Lecture : BaseEntity
    {
        private int LectureId { get; set; }
        private string LectureName { get; set; }
        private List<Area> AreaList { get; set; }
        private int LectureTime { get; set; }
        private DateTime LectureDate { get; set; }
        private string LectureDescription { get; set; }
        private Modality LectureModality { get; set; }
        private bool IsLectureLimited { get; set; }
        private int LectureLimit { get; set; }
        private List<Speaker> SpeakerList { get; set; }
        private List<Viewer> ViewerList { get; set; }

        public Lecture(int lectureId, string lectureName, List<Area> areaList, int lectureTime, DateTime lectureDate, string lectureDescription, Modality lectureModality, bool isLectureLimited, int lectureLimit, List<Speaker> speakerList, List<Viewer> viewerList)
        {
            LectureId = lectureId;
            LectureName = lectureName;
            AreaList = areaList;
            LectureTime = lectureTime;
            LectureDate = lectureDate;
            LectureDescription = lectureDescription;
            LectureModality = lectureModality;
            IsLectureLimited = isLectureLimited;
            LectureLimit = lectureLimit;
            SpeakerList = speakerList;
            ViewerList = viewerList;
        }

        public int GetLectureId()
        {
            return LectureId;
        }

        public string GetLectureName()
        {
            return LectureName;
        }

        public List<Area> GetAreaList()
        {
            return AreaList;
        }

        public int GetLectureTime()
        {
            return LectureTime;
        }

        public DateTime GetLectureDate()
        {
            return LectureDate;
        }

        public string GetLectureDescription()
        {
            return LectureDescription;
        }

        public Modality GetLectureModality()
        {
            return LectureModality;
        }

        public bool GetIsLectureLimited()
        {
            return IsLectureLimited;
        }

        public int GetLectureLimit()
        {
            return LectureLimit;
        }

        public List<Speaker> GetSpeakerList()
        {
            return SpeakerList;
        }

        public List<Viewer> GetViewerList()
        {
            return ViewerList;
        }
    }
}