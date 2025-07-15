using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PDFController : ControllerBase
{
    [HttpGet("/quest-pdf/generate")]
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
}
