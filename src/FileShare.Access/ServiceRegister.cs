using Microsoft.Extensions.DependencyInjection;

namespace FileShare.Access
{
    public static class ServiceRegister
    {
        public static IServiceCollection UseFileShare(this IServiceCollection services)
        {
            services.AddScoped<IFileShareService, FileShareService>();
            return services;
        }
    }
}