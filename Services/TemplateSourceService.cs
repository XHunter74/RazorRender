using RazorRender.Services.Interfaces;

namespace RazorRender.Services;

public class TemplateSourceService : ITemplateSourceService
{
    public Task<string> GetTemplateSourceAsync(string template)
    {
        var viewPath = Path.Combine("Views", $"{template}.cshtml");
        if (!Path.Exists(viewPath))
        {
            throw new FileNotFoundException($"View file '{template}' not found.");
        }
        return File.ReadAllTextAsync(viewPath);
    }
}
