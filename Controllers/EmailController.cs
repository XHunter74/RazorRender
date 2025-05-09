using Microsoft.AspNetCore.Mvc;
using RazorRender.Models;
using RazorRender.Services.Interfaces;

namespace RazorRender.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IViewRenderService _viewRenderService;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly ITemplateSourceService _templateSourceService;

    public EmailController(
        IViewRenderService viewRenderService,
        IEmailTemplateService emailTemplateService,
        ITemplateSourceService templateSourceService)
    {
        _viewRenderService = viewRenderService;
        _emailTemplateService = emailTemplateService;
        _templateSourceService = templateSourceService;
    }

    [HttpGet("razor")]
    public async Task<IActionResult> RazorRenderAsync()
    {
        var emailModel = new EmailModel
        {
            Name = "Serhiy",
            Email = "test@example.com",
            Items = ["Item1", "Item2", "Item3"]
        };
        var html = await _viewRenderService.RenderToStringAsync("Emails/Welcome", emailModel);
        return Content(html, "text/html");
    }

    [HttpGet("razor-light")]
    public async Task<IActionResult> RazorLightRenderAsync()
    {
        var template = await _templateSourceService.GetTemplateSourceAsync("Emails/Welcome");
        var emailModel = new EmailModel
        {
            Name = "Serhiy",
            Email = "test@example.com",
            Items = ["Item1", "Item2", "Item3"]
        };
        var html = await _emailTemplateService.RenderTemplateAsync(template, emailModel);
        return Content(html, "text/html");
    }
}