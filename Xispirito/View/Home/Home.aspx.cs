using System;
using System.Drawing;
using System.Web.UI.WebControls;
using Xispirito.Models;
using AspImage = System.Web.UI.WebControls.Image;

namespace Xispirito.View.HomeWithMaster
{
    public partial class Home : System.Web.UI.Page
    {
        private static Color onlineColor = Color.FromArgb(75, 209, 142);
        private static Color inPersonColor = Color.FromArgb(240, 145, 22);
        private static Color hybridColor = Color.FromArgb(138, 37, 177);

        protected void Page_Load(object sender, EventArgs e)
        {
            Random randomGenerator = new Random();

            EventRandomizer(CardImage1, lblTipoEvento1, lblTempoEvento1, randomGenerator, 1);
            EventRandomizer(CardImage2, lblTipoEvento2, lblTempoEvento2, randomGenerator, 2);
            EventRandomizer(CardImage3, lblTipoEvento3, lblTempoEvento3, randomGenerator, 3);
            EventRandomizer(CardImage4, lblTipoEvento4, lblTempoEvento4, randomGenerator, 4);
            EventRandomizer(CardImage5, lblTipoEvento5, lblTempoEvento5, randomGenerator, 5);
            EventRandomizer(CardImage6, lblTipoEvento6, lblTempoEvento6, randomGenerator, 6);
        }

        private void EventRandomizer(AspImage cardImage, Label lblEventType, Label lblEventTime, Random randomGenerator, int cardNumber)
        {
            cardImage.ImageUrl = "\\View\\Images\\Test\\Lecture" + cardNumber + ".png";

            int lectureTypeLenght = (Enum.GetValues(typeof(Modality)).Length);

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
            lblEventType.Text = Enum.GetName(typeof(Modality), lectureType);

            int lectureTime = randomGenerator.Next(15, 120);
            lblEventTime.Text = lectureTime.ToString() + " Min";
        }
    }
}