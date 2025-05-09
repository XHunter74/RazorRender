namespace RazorRender.Services.Interfaces;

public interface ITemplateSourceService
{
    Task<string> GetTemplateSourceAsync(string template);
}
