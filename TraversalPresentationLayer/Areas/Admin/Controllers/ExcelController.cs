using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalPresentationLayer.Models;

namespace TraversalPresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> _destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                _destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
                return _destinationModels;
            }
        }

        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells[1, 1].Value = "Rota";
            worksheet.Cells[1, 2].Value = "Rehber";
            worksheet.Cells[1, 3].Value = "Kontenjan";

            worksheet.Cells[2, 1].Value = "Gürcistan Batum Turu";
            worksheet.Cells[2, 2].Value = "Burak Arslan";
            worksheet.Cells[2, 2].Value = "50";

            worksheet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
            worksheet.Cells[3, 2].Value = "Esra Bulut";
            worksheet.Cells[3, 2].Value = "35";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Statik.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Tur Listesi");
                worksheet.Cell(1, 1).Value = "Şehir";
                worksheet.Cell(1, 2).Value = "Konaklama Süresi";
                worksheet.Cell(1, 3).Value = "Fiyat Süresi";
                worksheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.City;
                    worksheet.Cell(rowCount, 2).Value = item.DayNight;
                    worksheet.Cell(rowCount, 3).Value = item.Price;
                    worksheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DinamikRotaListesi.xlsx");
                }
            }
        }
    }
}
