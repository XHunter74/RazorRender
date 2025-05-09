namespace RazorRender.Services.Interfaces;

public interface IEmailTemplateService
{
    Task<string> RenderTemplateAsync<T>(string template, T model);
}
