using Microsoft.Extensions.DependencyInjection;

namespace Reservatio.Config.Localization
{
    public static class LocalizationSettings
    {
        public static void SetLocalization(this IServiceCollection services)
        {
           services.AddLocalization(options => options.ResourcesPath = "Resources");
        }
    }
}
