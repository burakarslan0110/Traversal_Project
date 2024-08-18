using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class PDFReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReport/" + "StatikPDFRaporu.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Rezarvasyon PDF Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/PDFReport/StatikPDFRaporu.pdf","application/pdf", "StatikPDFRaporu.pdf");
        }

        public IActionResult StaticCustomerPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReport/" + "StatikMüşteriPDFRaporu.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC No");

            pdfPTable.AddCell("Deneme");
            pdfPTable.AddCell("Deneme");
            pdfPTable.AddCell("1111111111");

            pdfPTable.AddCell("Deneme2");
            pdfPTable.AddCell("Deneme2");
            pdfPTable.AddCell("22222222222");

            pdfPTable.AddCell("Deneme3");
            pdfPTable.AddCell("Deneme3");
            pdfPTable.AddCell("33333333333");

            document.Add(pdfPTable);

            document.Close();
            return File("/PDFReport/StatikMüşteriPDFRaporu.pdf", "application/pdf", "StatikMüşteriPDFRaporu.pdf");
        }
    }
}
