using Microsoft.AspNetCore.Mvc;
using RazorRender.Models;
using RazorRender.Services.Interfaces;

namespace RazorRender.Controllers;

/// <summary>
/// Controller for rendering email templates.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IViewRenderService _viewRenderService;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly ITemplateSourceService _templateSourceService;
    private readonly EmailModel _emailModel = new()
    {
        Name = "Serhiy",
        Email = "test@example.com",
        Items = ["Item1", "Item2", "Item3"]
    };

    public EmailController(
            IViewRenderService viewRenderService,
            IEmailTemplateService emailTemplateService,
            ITemplateSourceService templateSourceService)
    {
        _viewRenderService = viewRenderService;
        _emailTemplateService = emailTemplateService;
        _templateSourceService = templateSourceService;
    }

    /// <summary>
    /// Renders an email template using Razor views.
    /// </summary>
    /// <returns></returns>
    [HttpGet("razor")]
    public async Task<IActionResult> RazorRenderAsync()
    {
        var html = await _viewRenderService.RenderToStringAsync("Emails/Welcome", _emailModel);
        return Content(html, "text/html");
    }

    /// <summary>
    /// Renders an email template using RazorLight.
    /// </summary>
    /// <returns></returns>
    [HttpGet("razor-light")]
    public async Task<IActionResult> RazorLightRenderAsync()
    {
        var template = await _templateSourceService.GetTemplateSourceAsync("Emails/Welcome");
        var html = await _emailTemplateService.RenderTemplateAsync(template, _emailModel);
        return Content(html, "text/html");
    }
}