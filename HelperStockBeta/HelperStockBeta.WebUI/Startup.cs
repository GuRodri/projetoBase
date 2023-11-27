using HelperStockBeta.Infra.IoC;

namespace HelperStockBeta.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) 
        {
            
            Configuration = configuration;
        }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddInfrastruture(Configuration);
            services.AddControllersWithViews();
        }

    }
}
