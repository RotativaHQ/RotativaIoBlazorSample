using Microsoft.AspNetCore.Mvc;
using Rotativaio.AspNetCore;
using RotativaIoBlazorSample.Data;

namespace RotativaIoBlazorSample.Controllers
{
    public class PdfController : Controller
    {
        WeatherForecastService ForecastService;

        public PdfController(WeatherForecastService forecastService)
        {
            ForecastService = forecastService;
        }

        public IActionResult Index()
        {
            return new ViewAsPdf();
        }

        public IActionResult About()
        {
            return new ViewAsPdf("~/Views/Pdf/Index.cshtml")
            {
                FileName = "about.pdf"
            };
        }

        public async Task<IActionResult> Data()
        {
            var forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
            return new ViewAsPdf(forecasts);
        }
        public async Task<IActionResult> DownloadData()
        {
            var forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
            return new ViewAsPdf("~/Views/Pdf/Data.cshtml", forecasts) { FileName = "Data.pdf" };
        }
    }
}
