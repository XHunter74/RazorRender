using Microsoft.AspNetCore.Mvc;
using RazorRender.Models;
using RazorRender.Services.Interfaces;

namespace RazorRender.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IViewRenderService _viewRenderService;

    public EmailController(IViewRenderService viewRenderService)
    {
        _viewRenderService = viewRenderService;
    }

    [HttpGet("preview")]
    public async Task<IActionResult> Preview()
    {
        var emailModel = new EmailModel
        {
            Name = "Serhiy",
            Email = "test@example.com",
            Items = new List<string> { "Item1", "Item2", "Item3" }
        };
        var html = await _viewRenderService.RenderToStringAsync("Emails/Welcome", emailModel);
        return Content(html, "text/html");
    }
}