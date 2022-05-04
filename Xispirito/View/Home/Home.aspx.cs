using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xispirito.Models;
using AspImage = System.Web.UI.WebControls.Image;

namespace Xispirito.View.Home
{
    public partial class Home : System.Web.UI.Page
    {
        private static Color onlineColor = Color.FromArgb(75, 209, 142);
        private static Color inPersonColor = Color.FromArgb(240, 145, 22);
        private static Color hybridColor = Color.FromArgb(138, 37, 177);

        protected void Page_Load(object sender, EventArgs e)
        {
            Random randomGenerator = new Random();

            EventRandomizer(CardImage1, lblTipoEvento1, lblTempoEvento1, randomGenerator);
            EventRandomizer(CardImage2, lblTipoEvento2, lblTempoEvento2, randomGenerator);
            EventRandomizer(CardImage3, lblTipoEvento3, lblTempoEvento3, randomGenerator);
            EventRandomizer(CardImage4, lblTipoEvento4, lblTempoEvento4, randomGenerator);
            EventRandomizer(CardImage5, lblTipoEvento5, lblTempoEvento5, randomGenerator);
            EventRandomizer(CardImage6, lblTipoEvento6, lblTempoEvento6, randomGenerator);
        }

        private void EventRandomizer(AspImage cardImage, Label lblEventType, Label lblEventTime, Random randomGenerator)
        {
            cardImage.ImageUrl = "\\View\\Images\\Test.png";

            int lectureTypeLenght = (Enum.GetValues(typeof(LectureType)).Length);

            int lectureType = randomGenerator.Next(lectureTypeLenght);

            switch (lectureType)
            {
                case 0:
                    lblEventType.BackColor = onlineColor;
                    break;

                case 1:
                    lblEventType.BackColor = inPersonColor;
                    break;

                case 2:
                    lblEventType.BackColor = hybridColor;
                    break;

                default:
                    throw new System.IndexOutOfRangeException();
            }
            lblEventType.Text = Enum.GetName(typeof(LectureType), lectureType);

            int lectureTime = randomGenerator.Next(15, 120);
            lblEventTime.Text = lectureTime.ToString() + " Min";
        }
    }
}