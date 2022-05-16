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
            // Loading Upcoming Events.
            List<AspImage> upcomingLecturesImages = new List<AspImage>(GetUpcomingLecturesImages());
            List<Label> upcomingLecturesLabels = new List<Label>(GetUpcomingLecturesLabels());

            List<Lecture> upcomingLectures = new List<Lecture>();
            upcomingLectures = lectureBAL.GetUpcomingLecturesList(upcomingLecturesLabels.Count());

            LoadEventsCard(upcomingLecturesImages, upcomingLecturesLabels, upcomingLectures);
        }

        private List<AspImage> GetUpcomingLecturesImages()
        {
            List<AspImage> upcomingLecturesImages = new List<AspImage>();
            upcomingLecturesImages.Add(ImageRecentlyAdded1);
            upcomingLecturesImages.Add(ImageRecentlyAdded2);
            upcomingLecturesImages.Add(ImageRecentlyAdded3);
            upcomingLecturesImages.Add(ImageRecentlyAdded4);
            upcomingLecturesImages.Add(ImageRecentlyAdded5);
            upcomingLecturesImages.Add(ImageRecentlyAdded6);
            upcomingLecturesImages.Add(ImageRecentlyAdded7);
            upcomingLecturesImages.Add(ImageRecentlyAdded8);
            upcomingLecturesImages.Add(ImageRecentlyAdded9);
            upcomingLecturesImages.Add(ImageRecentlyAdded10);

            return upcomingLecturesImages;
        }

        private List<Label> GetUpcomingLecturesLabels()
        {
            List<Label> upcomingLecturesLabels = new List<Label>();
            upcomingLecturesLabels.Add(lblRecentlyAdded1);
            upcomingLecturesLabels.Add(lblRecentlyAdded2);
            upcomingLecturesLabels.Add(lblRecentlyAdded3);
            upcomingLecturesLabels.Add(lblRecentlyAdded4);
            upcomingLecturesLabels.Add(lblRecentlyAdded5);
            upcomingLecturesLabels.Add(lblRecentlyAdded6);
            upcomingLecturesLabels.Add(lblRecentlyAdded7);
            upcomingLecturesLabels.Add(lblRecentlyAdded8);
            upcomingLecturesLabels.Add(lblRecentlyAdded9);
            upcomingLecturesLabels.Add(lblRecentlyAdded10);

            return upcomingLecturesLabels;
        }

        private void LoadEventsCard(List<AspImage> aspImages, List<Label> aspLabels, List<Lecture> lectureList)
        {
            if (lectureList != null)
            {
                int index = 0;
                foreach (Lecture lecture in lectureList)
                {
                    aspImages[index].ImageUrl = lecture.GetPicture();
                    aspLabels[index].Text = lecture.GetName();
                    index++;
                }
            }
        }
    }
}