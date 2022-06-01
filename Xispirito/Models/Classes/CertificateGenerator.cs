﻿using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.IO;
using Xispirito.Controller;

namespace Xispirito.Models
{

    public static class CertificateGenerator
    {
        public static void GenerateViewerCertificatePDF(Viewer viewer, Lecture lecture, Certificate certificate)
        {
            // Home.
            string outsideProjectPath = @"D:\VisualStudio\TCCAthon\2022-1-webinar-4\Xispirito\";

            //// Work
            //string outsideProjectPath = @"C:\Users\MATHEUS\Desktop\TCC\2022-1-webinar-4\Xispirito\";

            string insideProjectPath = @"View\Images\Certificates\";
            string path = @"Viewers\";
            string userEmail = viewer.GetEmail() + @"\";
            string fileName = Cryptography.GetMD5Hash(certificate.GetId().ToString());
            string extension = ".pdf";
            string fullPath = outsideProjectPath + insideProjectPath + path + userEmail + fileName + extension;

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
            gfx.DrawString(fileName,
                boldFont, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.BottomLeft
            );

            document.Save(fullPath);
            SaveViewerCertificate(viewer.GetEmail(), certificate.GetId());
            document.Close();

            string inputPath = outsideProjectPath + insideProjectPath + path + userEmail + fileName;
            string outputPath = inputPath;

            ConvertPdfToPng(inputPath, outputPath);
        }

        private static void SaveViewerCertificate(string userEmail, int certificateId)
        {
            ViewerCertificateBAL viewerCertificateBAL = new ViewerCertificateBAL();
            viewerCertificateBAL.SaveViewerCertificate(userEmail, certificateId);
        }

        private static void ConvertPdfToPng(string inputFilePath, string outputFilePath)
        {
            string arguments = string.Format(@"-density 300 {0}.pdf {1}.png", inputFilePath, outputFilePath);
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = arguments,
                FileName = @"D:\Program Files\ImageMagick-7.1.0-Q16-HDRI\magick.exe"
            };
            startInfo.UseShellExecute = false;

            Process.Start(startInfo).WaitForExit();
        }
    }
}