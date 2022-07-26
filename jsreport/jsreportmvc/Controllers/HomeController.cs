using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using jsreportmvc.Models;
using jsreport.AspNetCore;
using jsreport.Types;

namespace jsreportmvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public IJsReportMVCService JsReportMVCService { get; }

    public HomeController(ILogger<HomeController> logger, IJsReportMVCService jsReportMVCService)
    {
        _logger = logger;
        JsReportMVCService = jsReportMVCService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [MiddlewareFilter(typeof(JsReportPipeline))]
    public IActionResult Report()
    {
        HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);

        return View();

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
