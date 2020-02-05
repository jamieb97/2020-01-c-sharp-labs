using System;
using System.Diagnostics;
using Xceed.Words.NET;

namespace lab_46_microsoft_office
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "MicrosoftWordReport.docx";
            var doc = DocX.Create(fileName);
            doc.InsertParagraph("This is a Microsoft Word Report");
            doc.InsertParagraph("This contains test report data");
            doc.InsertParagraph("5 tests have passed and two have failed");
            doc.Save();

            //Process.Start("", fileName);
            Process.Start("WINWORD.EXE",fileName);
        }
    }
}
