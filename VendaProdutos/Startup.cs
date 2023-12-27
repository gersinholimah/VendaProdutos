//using Microsoft.Extensions.DependencyInjection;

//namespace VendaProdutos
//{
//    public class Startup
//    {
//    }
//}




using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft. Extensions. Hosting;
using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.Repositories;
using VendaProdutos.Repositories.Interfaces;
namespace VendaProdutos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

            services.AddControllersWithViews();

            services.AddMemoryCache();
            services.AddSession();

        }
        // This method gets called by the runtime. Use this method to public void Configure(IApplicationBuilder app, IWebHostEnviro {

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to app.UseHsts(),
                app.UseHsts();

            }
            app.UseHttpsRedirection(); 
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "categoriaFiltro", 
                    pattern: "Produto/{action}/{categoria?}",
                    defaults: new {Controller = "Produto", action = "List" });
 
                endpoints.MapControllerRoute(
        name: "default",
 pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
