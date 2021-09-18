using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace ScreenNShot
{
    internal class Actions
    {
        /// <summary>
        /// Actually saves a PDF out of a Queue of Streams containing images
        /// </summary>
        /// <param name="currentPictures">a  Queue of Streams containing images</param>
        internal static void SavePDF(Queue<Stream> currentPictures)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var path = $"{Properties.Settings.Default.Output_Path}/{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fffff")}.pdf"; // change path dynamically
            var document = new PdfDocument(path);
            while (currentPictures.Count > 0) // if there's pictures in the queue
            {
                Stream stream = currentPictures.Dequeue();
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                var image = XImage.FromStream(stream);
                page.Width = XUnit.FromPoint(image.PointWidth);
                page.Height = XUnit.FromPoint(image.PointHeight);
                gfx.DrawImage(image, 0, 0);
            }
            document.Close();
            Process.Start("explorer.exe", $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\ScreenNShot Output"); // open the document path in explorer
        }
    }
}