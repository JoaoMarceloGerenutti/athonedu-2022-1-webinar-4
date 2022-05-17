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
            List<Label> upcomingLecturesTitleLabels = new List<Label>(GetUpcomingLecturesTitleLabels());
            List<Label> upcomingLecturesTypeLabels = new List<Label>(GetUpcomingLecturesTypeLabels());
            List<Label> upcomingLecturesTimeLabels = new List<Label>(GetUpcomingLecturesTimeLabels());

            List<Lecture> upcomingLectures = new List<Lecture>();
            upcomingLectures = lectureBAL.GetUpcomingLecturesList(upcomingLecturesTitleLabels.Count());

            LoadEventsCard(upcomingLectures, upcomingLecturesImages, upcomingLecturesTitleLabels, upcomingLecturesTypeLabels, upcomingLecturesTimeLabels);
        }

        private List<AspImage> GetUpcomingLecturesImages()
        {
            List<AspImage> upcomingLecturesImages = new List<AspImage>();
            upcomingLecturesImages.Add(UpcomingEventImage1);

            //upcomingLecturesImages.Add(ImageRecentlyAdded2);
            //upcomingLecturesImages.Add(ImageRecentlyAdded3);
            //upcomingLecturesImages.Add(ImageRecentlyAdded4);
            //upcomingLecturesImages.Add(ImageRecentlyAdded5);
            //upcomingLecturesImages.Add(ImageRecentlyAdded6);
            //upcomingLecturesImages.Add(ImageRecentlyAdded7);
            //upcomingLecturesImages.Add(ImageRecentlyAdded8);
            //upcomingLecturesImages.Add(ImageRecentlyAdded9);
            //upcomingLecturesImages.Add(ImageRecentlyAdded10);

            return upcomingLecturesImages;
        }

        private List<Label> GetUpcomingLecturesTitleLabels()
        {
            List<Label> upcomingLecturesTitleLabels = new List<Label>();
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent1);

            //upcomingLecturesLabels.Add(lblRecentlyAdded2);
            //upcomingLecturesLabels.Add(lblRecentlyAdded3);
            //upcomingLecturesLabels.Add(lblRecentlyAdded4);
            //upcomingLecturesLabels.Add(lblRecentlyAdded5);
            //upcomingLecturesLabels.Add(lblRecentlyAdded6);
            //upcomingLecturesLabels.Add(lblRecentlyAdded7);
            //upcomingLecturesLabels.Add(lblRecentlyAdded8);
            //upcomingLecturesLabels.Add(lblRecentlyAdded9);
            //upcomingLecturesLabels.Add(lblRecentlyAdded10);

            return upcomingLecturesTitleLabels;
        }

        private List<Label> GetUpcomingLecturesTypeLabels()
        {
            List<Label> upcomingLecturesTypeLabels = new List<Label>();
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent1);

            return upcomingLecturesTypeLabels;
        }

        private List<Label> GetUpcomingLecturesTimeLabels()
        {
            List<Label> upcomingLecturesTimeLabels = new List<Label>();
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent1);

            return upcomingLecturesTimeLabels;
        }

        private void LoadEventsCard(List<Lecture> lectureList, List<AspImage> upcomingImages, List<Label> upcomingTitles, List<Label> upcomingTypes, List<Label> upcomingTimes)
        {
            if (lectureList != null)
            {
                int index = 0;
                foreach (Lecture lecture in lectureList)
                {
                    upcomingImages[index].ImageUrl = lecture.GetPicture();
                    upcomingTitles[index].Text = lecture.GetName();

                    Modality modality = (Modality)lecture.GetModality();
                    upcomingTypes[index].Text = modality.ToString();

                    upcomingTimes[index].Text = lecture.GetTime().ToString() + " Min";
                    index++;
                }
            }
        }
    }
}