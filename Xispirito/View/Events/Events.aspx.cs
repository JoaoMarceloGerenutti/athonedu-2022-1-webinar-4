using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;
using AspImage = System.Web.UI.WebControls.Image;

namespace Xispirito.View.Events
{
    public partial class Events : System.Web.UI.Page
    {
        private LectureBAL lectureBAL = new LectureBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Loading Next Events.
            List<AspImage> nextLecturesImages = new List<AspImage>(GetNextLecturesImages());
            List<Label> nextLecturesLabels = new List<Label>(GetNextLecturesLabels());
            List<Lecture> nextLectures = new List<Lecture>(GetNextEventsList(nextLecturesLabels.Count()));

            LoadEventsCard(nextLecturesImages, nextLecturesLabels, nextLectures);
        }

        private List<AspImage> GetNextLecturesImages()
        {
            List<AspImage> nextLecturesImages = new List<AspImage>();
            nextLecturesImages.Add(ImageRecentlyAdded1);
            nextLecturesImages.Add(ImageRecentlyAdded2);
            nextLecturesImages.Add(ImageRecentlyAdded3);
            nextLecturesImages.Add(ImageRecentlyAdded4);
            nextLecturesImages.Add(ImageRecentlyAdded5);
            nextLecturesImages.Add(ImageRecentlyAdded6);
            nextLecturesImages.Add(ImageRecentlyAdded7);
            nextLecturesImages.Add(ImageRecentlyAdded8);
            nextLecturesImages.Add(ImageRecentlyAdded9);
            nextLecturesImages.Add(ImageRecentlyAdded10);

            return nextLecturesImages;
        }

        private List<Label> GetNextLecturesLabels()
        {
            List<Label> nextLecturesLabels = new List<Label>();
            nextLecturesLabels.Add(lblRecentlyAdded1);
            nextLecturesLabels.Add(lblRecentlyAdded2);
            nextLecturesLabels.Add(lblRecentlyAdded3);
            nextLecturesLabels.Add(lblRecentlyAdded4);
            nextLecturesLabels.Add(lblRecentlyAdded5);
            nextLecturesLabels.Add(lblRecentlyAdded6);
            nextLecturesLabels.Add(lblRecentlyAdded7);
            nextLecturesLabels.Add(lblRecentlyAdded8);
            nextLecturesLabels.Add(lblRecentlyAdded9);
            nextLecturesLabels.Add(lblRecentlyAdded10);

            return nextLecturesLabels;
        }

        private void LoadEventsCard(List<AspImage> aspImage, List<Label> aspLabel, List<Lecture> lectureList)
        {
            int index = 0;
            foreach (Lecture lecture in lectureList)
            {
                aspImage[index].ImageUrl = lecture.GetPicture();
                aspLabel[index].Text = lecture.GetName();
                index++;
            }
        }

        private List<Lecture> GetNextEventsList(int listSize)
        {
            List<Lecture> lectureList = new List<Lecture>(lectureBAL.GetNextLecturesList(listSize));
            return lectureList;
        }
    }
}