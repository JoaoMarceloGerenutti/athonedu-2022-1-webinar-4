using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Controller;
using Xispirito.Models;

namespace Xispirito.View.RegisteredEvents
{
    public partial class RegisteredEvents : Page
    {
        private ViewerLectureBAL viewerLectureBAL = new ViewerLectureBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && User.Identity.IsAuthenticated)
            {
                LoadEventsDataBound(viewerLectureBAL.GetUserLecturesRegistration(User.Identity.Name));
            }
        }

        private void LoadEventsDataBound(List<ViewerLecture> viewerLectures)
        {
            string title = "Meus Eventos ";
            if (viewerLectures != null)
            {
                MyEvents.Text = title + "(" + viewerLectures.Count + ")";
                ListViewEvents.Items.Clear();
                ListViewEvents.DataSource = viewerLectures;
                ListViewEvents.DataBind();
            }
            else
            {
                MyEvents.Text = title + "(0)";
            }
        }

        protected void SearchEvents_Click(object sender, EventArgs e)
        {
            string search = FilterEvents.Text;

            if (search != null)
            {
                LoadEventsDataBound(viewerLectureBAL.GetUserLecturesRegistration(User.Identity.Name, search));
            }
        }

        protected void ListViewEvents_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ViewerLecture viewerLecture = (ViewerLecture)e.Item.DataItem;

                Image eventImage = (Image)e.Item.FindControl("EventImage");
                eventImage.ImageUrl = viewerLecture.GetLecture().GetPicture();

                Label titleLabel = (Label)e.Item.FindControl("EventTitle");
                titleLabel.Text = viewerLecture.GetLecture().GetName();

                Label modalityLabel = (Label)e.Item.FindControl("EventModality");
                modalityLabel.Text = viewerLecture.GetLecture().GetModality();
                modalityLabel.ForeColor = ModalityColor.GetModalityColor(viewerLecture.GetLecture().GetModality());

                Image addressImage = (Image)e.Item.FindControl("AddressIcon");
                Label addressLabel = (Label)e.Item.FindControl("EventAddress");

                if (viewerLecture.GetLecture().GetModality() == Enum.GetName(typeof(Modality), 0))
                {
                    addressImage.Visible = false;
                    addressLabel.Visible = false;
                }
                else
                {
                    addressLabel.Text = viewerLecture.GetLecture().GetAddress();
                }

                Label dateLabel = (Label)e.Item.FindControl("EventDate");
                dateLabel.Text = viewerLecture.GetLecture().GetDate().ToString("dd/MM/yyyy HH:mm");

                DateTime endDateTime = viewerLecture.GetLecture().GetDate();
                endDateTime = endDateTime.AddMinutes(viewerLecture.GetLecture().GetTime());
                dateLabel.Text += " - " + endDateTime.ToString("dd/MM/yyyy HH:mm");

                Button watchButton = (Button)e.Item.FindControl("WatchLecture");
                watchButton.CommandArgument = "";
                watchButton.BackColor = ModalityColor.GetModalityColor(viewerLecture.GetLecture().GetModality());

                if (viewerLecture.GetLecture().GetModality() != Enum.GetName(typeof(Modality), 1))
                {
                    if (viewerLecture.GetLecture().GetDate() <= DateTime.Now && viewerLecture.GetLecture().GetDate() < endDateTime)
                    {
                        watchButton.Visible = true;
                    }
                }

                Button cancelButton = (Button)e.Item.FindControl("CancelSubscription");
                cancelButton.CommandArgument = viewerLecture.GetLecture().GetId().ToString();
            }
        }

        protected void CancelSubscription_Click(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int lectureId = Convert.ToInt32(clickedButton.CommandArgument);

            ViewerLecture objViewerLecture = new ViewerLecture();
            objViewerLecture = viewerLectureBAL.GetUserLectureRegistration(User.Identity.Name, lectureId);
            viewerLectureBAL.DeleteUserSubscription(objViewerLecture);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Inscrição Cancelada!", "alert('Sua Inscrição a Palestra foi Cancelada!');", true);
            LoadEventsDataBound(viewerLectureBAL.GetUserLecturesRegistration(User.Identity.Name));
        }
    }
}