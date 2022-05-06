using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xispirito.Models.Classes
{
    public class Lecture : BaseEntity
    {
        private int IdLecture { get; set; }
        private string NameLecture { get; set; }
        private Area AreaLecture { get; set; }
        private int TimeLecture { get; set; }
        private DateTime DateLecture { get; set; }
        private string DescriptionLecture { get; set; }
        private Modality ModalityLecture { get; set; }
        private bool IsLectureLimited { get; set; }
        private int LectureLimit { get; set; }
        private List<Speaker> SpeakerList { get; set; }
        private List<Viewer> ViewerList { get; set; }

        public Lecture(int idLecture, string nameLecture, Area areaLecture, int timeLecture, DateTime dateLecture, string descriptionLecture, Modality modalityLecture, bool isLectureLimited, int lectureLimit, List<Speaker> speakerList, List<Viewer> viewerList)
        {
            IdLecture = idLecture;
            NameLecture = nameLecture;
            AreaLecture = areaLecture;
            TimeLecture = timeLecture;
            DateLecture = dateLecture;
            DescriptionLecture = descriptionLecture;
            ModalityLecture = modalityLecture;
            IsLectureLimited = isLectureLimited;
            LectureLimit = lectureLimit;
            SpeakerList = speakerList;
            ViewerList = viewerList;
        }

        public int GetIdLecture()
        {
            return IdLecture;
        }

        public string GetNameLecture()
        {
            return NameLecture;
        }

        public bool GetIsActive()
        {
            return IsActive;
        }

        public void Deactivate()
        {
            IsActive = true;
        }
    }
}