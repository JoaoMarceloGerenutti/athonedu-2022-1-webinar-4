using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;
using AspImage = System.Web.UI.WebControls.Image;

namespace Xispirito.View.HomeWithMaster
{

    public partial class Home : System.Web.UI.Page
    {
        private LectureBAL lectureBAL = new LectureBAL();

        private static Color onlineColor = Color.FromArgb(75, 209, 142);
        private static Color inPersonColor = Color.FromArgb(240, 145, 22);
        private static Color hybridColor = Color.FromArgb(138, 37, 177);

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