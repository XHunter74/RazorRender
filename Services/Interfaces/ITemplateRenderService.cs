namespace RazorRender.Services.Interfaces;

public interface ITemplateRenderService
{
    Task<string> RenderTemplateAsync<T>(string template, T model);
}
