using Microsoft.Extensions.DependencyInjection;

namespace nexgen.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}
