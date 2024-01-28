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
using ReflectionIT.Mvc.Paging;
using VendaProdutos.Areas.Admin.Servicos;
using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.Repositories;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.Services;
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

            services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));

            services.Configure<IdentityOptions>(options => { 
            options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddScoped<RelatorioVendasService>();
            services.AddScoped<GraficoVendasService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    politica =>
                    {
                        politica.RequireRole("Admin");
                    });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

            services.AddControllersWithViews();

            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

            services.AddMemoryCache();
            services.AddSession();

            //Registra Sitemap aqui no startup
            services.AddTransient<ISitemapService, SitemapService>();
            //Registra Feed de Produtos aqui no startup
            services.AddTransient<IProductFeedService, ProductFeedService>();


        }
        // This method gets called by the runtime. Use this method to public void Configure(IApplicationBuilder app, IWebHostEnviro {

        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial,
            //chama o serviço do sitemap aqui no startup
             ISitemapService sitemapService,
             //chama o serviço do feed de produtos aqui no startup
             IProductFeedService productFeedService)
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

            //Cria os perfis
            seedUserRoleInitial.SeedRoles();
            //Cria os usuários e atributos ao perfil
            seedUserRoleInitial.SeedUsers();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //remover se não quiser passar nome e id do produto na url
endpoints.MapControllerRoute(
     name: "produto-details",
     pattern: "Produto/{nome}-{produtoId}",
     defaults: new { controller = "Produto", action = "Details" }
 );
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                    );
 
                
                endpoints.MapControllerRoute(
                    name: "categoriaFiltro",
                        pattern: "Categoria/{categoria}-{categoriaid}",/*pattern: "Produto/{action}/{categoria?}"*/
                    defaults: new {Controller = "Produto", action = "List" });
 
                endpoints.MapControllerRoute(
        name: "default",
 pattern: "{controller=Home}/{action=Index}/{id?}");


            });





            // Gera o sitemap e armazena na pasta wwwroot
            string sitemapXml = sitemapService.GenerateSitemap();
            string sitemapPath = Path.Combine(env.WebRootPath, "sitemap.xml");
            File.WriteAllText(sitemapPath, sitemapXml);

            // Gera o feed de produtos e armazena no mesmo diretório do sitemap
            string productFeedXml = productFeedService.GenerateProductFeed();
            string productFeedPath = Path.Combine(env.WebRootPath, "productfeed.xml");
            File.WriteAllText(productFeedPath, productFeedXml);
        }
    }
}
