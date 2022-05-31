using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using Xispirito.Controller;

namespace Xispirito.Models
{

    public static class CertificateGenerator
    {
        public static void GenerateViewerCertificatePDF(Viewer viewer, Lecture lecture, Certificate certificate)
        {
            string outsideProjectPath = @"D:\Visual Studio\TCC Athon\2022-1-webinar-4\Xispirito\";
            string insideProjectPath = @"View\Images\Certificates\";
            string path = @"Viewers\";
            string userEmail = viewer.GetEmail() + @"\";
            string filename = Cryptography.GetMD5Hash(certificate.GetId().ToString());
            string extension = ".pdf";
            string fullPath = outsideProjectPath + insideProjectPath + path + userEmail + filename + extension;

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.Statement;
            page.Height = 600;
            page.Width = 800;

            XGraphics gfx = XGraphics.FromPdfPage(page);

            gfx.DrawImage(PdfSharp.Drawing.XImage.FromFile(outsideProjectPath + certificate.GetCertificateModelDirectory()), 0, 0, page.Width, page.Height);

            XFont font = new XFont("Arial", 14, XFontStyle.Regular);
            XFont boldFont = new XFont("Arial", 12, XFontStyle.Bold);

            double textPositionY = 0;
            string text = "Certificamos que " + viewer.GetName() + ", participou da atividade:";
            gfx.DrawString(text,
                font, XBrushes.Black,
                new XRect(0, textPositionY, page.Width, page.Height),
                XStringFormats.Center
            );

            PdfSharp.Drawing.XSize nextText = gfx.MeasureString(text, font);
            textPositionY += nextText.Height;

            text = lecture.GetName() + ",";
            gfx.DrawString(text,
                boldFont, XBrushes.Black,
                new XRect(0, textPositionY, page.Width, page.Height),
                XStringFormats.Center
            );

            nextText = gfx.MeasureString(text, boldFont);
            textPositionY += nextText.Height;

            text = "realizada em " + lecture.GetDate().ToString("dd/MM/yyyy") + ", contabilizando a carga horária total de " + lecture.GetTime() + " Minutos.";
            gfx.DrawString(text,
                font, XBrushes.Black,
                new XRect(0, textPositionY, page.Width, page.Height),
                XStringFormats.Center
            );

            nextText = gfx.MeasureString(text, font);
            textPositionY += nextText.Height * 3;

            boldFont = new XFont("Arial", 16, XFontStyle.Bold);

            text = "Sorocaba, " + lecture.GetDate().ToString("dd") + " de " + lecture.GetDate().ToString("MMMM") + " de " + lecture.GetDate().ToString("yyyy") + ".";
            gfx.DrawString(text,
                boldFont, XBrushes.Black,
                new XRect(0, textPositionY, page.Width, page.Height),
                XStringFormats.Center
            );

            // Certificate Key.
            gfx.DrawString(Cryptography.GetMD5Hash(certificate.GetId().ToString()),
                boldFont, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.BottomLeft
            );

            document.Save(fullPath);
            SaveViewerCertificate(viewer.GetEmail(), certificate.GetId());

            string filePath = outsideProjectPath + insideProjectPath + path + userEmail;
            string outputPath = filePath;
            ConvertPdfToJpg(filePath, filename, outputPath);
        }

        private static void SaveViewerCertificate(string userEmail, int certificateId)
        {
            ViewerCertificateBAL viewerCertificateBAL = new ViewerCertificateBAL();
            viewerCertificateBAL.SaveViewerCertificate(userEmail, certificateId);
        }

        private static void ConvertPdfToJpg(string filePath, string fileName, string outputPath)
        {
            //Process.Start("", );
        }
    }
}