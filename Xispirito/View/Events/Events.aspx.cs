using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;
using AspImageButton = System.Web.UI.WebControls.ImageButton;

namespace Xispirito.View.Events
{
    public partial class Events : System.Web.UI.Page
    {
        private LectureBAL lectureBAL = new LectureBAL();
        private List<AspImageButton> upcomingLecturesImages;
        private List<Label> upcomingLecturesTitleLabels;
        private List<Label> upcomingLecturesTypeLabels;
        private List<Label> upcomingLecturesTimeLabels;
        private List<Lecture> upcomingLectures;

        private AreaBAL areaBAL = new AreaBAL();
        private List<AspImageButton> areaImages;
        private List<Label> areaTitleLabels;
        private List<Area> areaLectures;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Loading Upcoming Events.
            upcomingLecturesImages = new List<AspImageButton>(GetUpcomingLecturesImages());
            upcomingLecturesTitleLabels = new List<Label>(GetUpcomingLecturesTitleLabels());
            upcomingLecturesTypeLabels = new List<Label>(GetUpcomingLecturesTypeLabels());
            upcomingLecturesTimeLabels = new List<Label>(GetUpcomingLecturesTimeLabels());

            upcomingLectures = new List<Lecture>();
            upcomingLectures = lectureBAL.GetUpcomingLecturesList(upcomingLecturesTitleLabels.Count());

            LoadUpcomingEventsCard(upcomingLectures, upcomingLecturesImages, upcomingLecturesTitleLabels, upcomingLecturesTypeLabels, upcomingLecturesTimeLabels);

            // Loading Area Events.
            areaImages = new List<AspImageButton>(GetAreaImages());
            areaTitleLabels = new List<Label>(GetAreaTitleLabels());

            areaLectures = new List<Area>();
            areaLectures = areaBAL.GetAreaList(areaTitleLabels.Count());

            LoadAreaEventsCard(areaLectures, areaImages, areaTitleLabels);
        }

        private List<AspImageButton> GetUpcomingLecturesImages()
        {
            List<AspImageButton> upcomingLecturesImages = new List<AspImageButton>();
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

        private void LoadUpcomingEventsCard(List<Lecture> lectureList, List<AspImageButton> upcomingLecturesImages, List<Label> upcomingLecturesTitleLabels, List<Label> upcomingLecturesTypeLabels, List<Label> upcomingLecturesTimeLabels)
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

        private void EventRegistryRedirect(int eventId)
        {
            Response.Redirect("~/View/Registry/Registry.aspx?event=" + eventId);
        }

        protected void UpcomingEvent1_Click(object sender, ImageClickEventArgs e)
        {
            int index = 0;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent2_Click(object sender, ImageClickEventArgs e)
        {
            int index = 1;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent3_Click(object sender, ImageClickEventArgs e)
        {
            int index = 2;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent4_Click(object sender, ImageClickEventArgs e)
        {
            int index = 3;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent5_Click(object sender, ImageClickEventArgs e)
        {
            int index = 4;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent6_Click(object sender, ImageClickEventArgs e)
        {
            int index = 5;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent7_Click(object sender, ImageClickEventArgs e)
        {
            int index = 6;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent8_Click(object sender, ImageClickEventArgs e)
        {
            int index = 7;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent9_Click(object sender, ImageClickEventArgs e)
        {
            int index = 8;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        protected void UpcomingEvent10_Click(object sender, ImageClickEventArgs e)
        {
            int index = 9;
            if (upcomingLectures.Count() > index)
            {
                if (upcomingLectures[index] != null)
                {
                    int eventId = upcomingLectures[index].GetId();
                    EventRegistryRedirect(eventId);
                }
            }
        }

        private List<AspImageButton> GetAreaImages()
        {
            List<AspImageButton> areaImages = new List<AspImageButton>();
            areaImages.Add(AreaEventImage1);
            areaImages.Add(AreaEventImage2);
            areaImages.Add(AreaEventImage3);
            areaImages.Add(AreaEventImage4);
            areaImages.Add(AreaEventImage5);
            areaImages.Add(AreaEventImage6);
            areaImages.Add(AreaEventImage7);
            areaImages.Add(AreaEventImage8);
            areaImages.Add(AreaEventImage9);
            areaImages.Add(AreaEventImage10);

            return areaImages;
        }

        private List<Label> GetAreaTitleLabels()
        {
            List<Label> areaTitleLabels = new List<Label>();
            areaTitleLabels.Add(TitleArea1);
            areaTitleLabels.Add(TitleArea2);
            areaTitleLabels.Add(TitleArea3);
            areaTitleLabels.Add(TitleArea4);
            areaTitleLabels.Add(TitleArea5);
            areaTitleLabels.Add(TitleArea6);
            areaTitleLabels.Add(TitleArea7);
            areaTitleLabels.Add(TitleArea8);
            areaTitleLabels.Add(TitleArea9);
            areaTitleLabels.Add(TitleArea10);

            return areaTitleLabels;
        }

        private void LoadAreaEventsCard(List<Area> areaList, List<AspImageButton> areaImages, List<Label> areaTitleLabels)
        {
            if (areaList != null)
            {
                int index = 0;
                foreach (Area area in areaList)
                {
                    areaImages[index].ImageUrl = area.GetPicture();
                    areaTitleLabels[index].Text = area.GetName();
                    index++;
                }
            }
        }

        private void EventPageListRedirect(int areaId)
        {
            //TEST
            Response.Redirect("~/View/Profiles/Profile-Speaker/Profile-Speaker.aspx");

            //Response.Redirect("~/View/Registry/Registry.aspx?event=" + areaId);
        }

        protected void AreaEvent1_Click(object sender, ImageClickEventArgs e)
        {
            int index = 0;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent2_Click(object sender, ImageClickEventArgs e)
        {
            int index = 1;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent3_Click(object sender, ImageClickEventArgs e)
        {
            int index = 2;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent4_Click(object sender, ImageClickEventArgs e)
        {
            int index = 3;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent5_Click(object sender, ImageClickEventArgs e)
        {
            int index = 4;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent6_Click(object sender, ImageClickEventArgs e)
        {
            int index = 5;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent7_Click(object sender, ImageClickEventArgs e)
        {
            int index = 6;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent8_Click(object sender, ImageClickEventArgs e)
        {
            int index = 7;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent9_Click(object sender, ImageClickEventArgs e)
        {
            int index = 8;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }

        protected void AreaEvent10_Click(object sender, ImageClickEventArgs e)
        {
            int index = 9;
            if (areaLectures.Count() > index)
            {
                if (areaLectures[index] != null)
                {
                    int areaId = areaLectures[index].GetId();
                    EventPageListRedirect(areaId);
                }
            }
        }
    }
}