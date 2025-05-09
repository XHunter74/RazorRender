using RazorLight;
using RazorRender.Services.Interfaces;

namespace RazorRender.Services;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly RazorLightEngine _engine;

    public EmailTemplateService(RazorLightEngine engine)
    {
        _engine = engine;
    }

    public Task<string> RenderTemplateAsync<T>(string template, T model)
    {
        var templateKey = GenerateTemplateKey(template);

        return _engine.CompileRenderStringAsync(templateKey, template, model);
    }

    private static string GenerateTemplateKey(string templateName)
    {
        // Use a hash to create a unique key for the template
        return $"template_{templateName.GetHashCode()}";
    }
}
