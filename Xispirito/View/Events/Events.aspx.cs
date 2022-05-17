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
            upcomingLecturesImages.Add(UpcomingEventImage2);
            upcomingLecturesImages.Add(UpcomingEventImage3);
            upcomingLecturesImages.Add(UpcomingEventImage4);
            upcomingLecturesImages.Add(UpcomingEventImage5);
            upcomingLecturesImages.Add(UpcomingEventImage6);
            upcomingLecturesImages.Add(UpcomingEventImage7);
            upcomingLecturesImages.Add(UpcomingEventImage8);
            upcomingLecturesImages.Add(UpcomingEventImage9);
            upcomingLecturesImages.Add(UpcomingEventImage10);

            return upcomingLecturesImages;
        }

        private List<Label> GetUpcomingLecturesTitleLabels()
        {
            List<Label> upcomingLecturesTitleLabels = new List<Label>();
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent1);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent2);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent3);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent4);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent5);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent6);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent7);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent8);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent9);
            upcomingLecturesTitleLabels.Add(TitleUpcomingEvent10);

            return upcomingLecturesTitleLabels;
        }

        private List<Label> GetUpcomingLecturesTypeLabels()
        {
            List<Label> upcomingLecturesTypeLabels = new List<Label>();
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent1);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent2);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent3);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent4);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent5);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent6);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent7);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent8);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent9);
            upcomingLecturesTypeLabels.Add(TypeUpcomingEvent10);

            return upcomingLecturesTypeLabels;
        }

        private List<Label> GetUpcomingLecturesTimeLabels()
        {
            List<Label> upcomingLecturesTimeLabels = new List<Label>();
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent1);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent2);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent3);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent4);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent5);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent6);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent7);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent8);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent9);
            upcomingLecturesTimeLabels.Add(TimeUpcomingEvent10);

            return upcomingLecturesTimeLabels;
        }

        private void LoadEventsCard(List<Lecture> lectureList, List<AspImage> upcomingLecturesImages, List<Label> upcomingLecturesTitleLabels, List<Label> upcomingLecturesTypeLabels, List<Label> upcomingLecturesTimeLabels)
        {
            if (lectureList != null)
            {
                int index = 0;
                foreach (Lecture lecture in lectureList)
                {
                    upcomingLecturesImages[index].ImageUrl = lecture.GetPicture();
                    upcomingLecturesTitleLabels[index].Text = lecture.GetName();

                    string lectureType = lecture.GetModality();
                    upcomingLecturesTypeLabels[index].Text = lectureType;
                    upcomingLecturesTypeLabels[index].BackColor = ModalityColor.GetModalityColor(lectureType);

                    upcomingLecturesTimeLabels[index].Text = lecture.GetTime().ToString() + " Min";
                    index++;
                }
            }
        }
    }
}