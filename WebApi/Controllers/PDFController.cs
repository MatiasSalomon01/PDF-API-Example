using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using QuestPDF.Fluent;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PDFController(IRazorViewEngine viewEngine,ITempDataProvider tempDataProvider) : ControllerBase
{
    [HttpGet("quest-pdf/generate")]
    public async Task<IActionResult> QuestPDFGenerate()
    {
        using var client = new HttpClient();

        var logoImg = client.GetByteArrayAsync("https://placehold.co/2000x400/png");
        var warningImg = client.GetByteArrayAsync("https://images.icon-icons.com/1808/PNG/512/warning_115257.png");
        var infoImg = client.GetByteArrayAsync("https://images.icon-icons.com/523/PNG/512/information_icon-icons.com_52388.png");

        await Task.WhenAll(logoImg, infoImg, warningImg);

        var document = new QuestPDFDocument(logoImg.Result, infoImg.Result, warningImg.Result);
        var pdfBytes = document.GeneratePdf();

        return File(pdfBytes, "application/pdf", "reporte.pdf");
    }

    [HttpGet("razor-page/generate")]
    public async Task<IActionResult> RazorPageGenerate()
    {
        var model = ReportViewModel.Create();

        string html = await RenderViewToStringAsync("Report", model);

        await new BrowserFetcher().DownloadAsync();

        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            Args = ["--no-sandbox"]
        });

        await using var page = await browser.NewPageAsync();
        await page.SetContentAsync(html, new NavigationOptions { WaitUntil = [WaitUntilNavigation.Networkidle0] });

        var pdfBytes = await page.PdfDataAsync(new PdfOptions
        {
            Format = PaperFormat.A4,
            MarginOptions = new MarginOptions { Top = "20px", Bottom = "20px" }
        });

        return File(pdfBytes, "application/pdf", "reporte.pdf");
    }

    private async Task<string> RenderViewToStringAsync(string viewName, object model)
    {
        var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);

        var viewResult = viewEngine.FindView(actionContext, viewName, false);
        
        if (!viewResult.Success)
        {
            throw new InvalidOperationException($"No se encontró la vista {viewName}");
        }

        using var sw = new StringWriter();

        var viewContext = new ViewContext(
            actionContext,
            viewResult.View,
            new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            },
            new TempDataDictionary(HttpContext, tempDataProvider),
            sw,
            new HtmlHelperOptions()
        );

        await viewResult.View.RenderAsync(viewContext);

        return sw.ToString();
    }
}