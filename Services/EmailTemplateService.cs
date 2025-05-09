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
        return _engine.CompileRenderStringAsync("templateKey", template, model);
    }
}
