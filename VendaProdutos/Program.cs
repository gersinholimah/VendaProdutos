using Microsoft.AspNetCore.Hosting;
using VendaProdutos.Areas.Admin.Servicos;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.Repositories;
using VendaProdutos.Services;

namespace VendaProdutos;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
}









 













//Startup migrado exceto o gerador de sitemap e o feed de produtos





 



//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using System.Configuration;
//using VendaProdutos.Areas.Admin.Servicos;
//using VendaProdutos.Context;
//using VendaProdutos.Models;
//using VendaProdutos.Repositories.Interfaces;
//using VendaProdutos.Repositories;
//using VendaProdutos.Services;
//using ReflectionIT.Mvc.Paging;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.Configure<ConfigurationImagens>(builder.Configuration.GetSection("ConfigurationPastaImagens"));

//builder.Services.Configure<IdentityOptions>(options => {
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 8;
//    options.Password.RequiredUniqueChars = 1;
//});

//builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
//builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
//builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

//builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

//builder.Services.AddScoped<RelatorioVendasService>();
//builder.Services.AddScoped<GraficoVendasService>();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Admin",
//        politica =>
//        {
//            politica.RequireRole("Admin");
//        });
//});

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

//builder.Services.AddControllersWithViews();

//builder.Services.AddPaging(options =>
//{
//    options.ViewName = "Bootstrap4";
//    options.PageParameterName = "pageindex";
//});

//builder.Services.AddMemoryCache();
//builder.Services.AddSession();

////Registra Sitemap aqui no startup
//builder.Services.AddTransient<ISitemapService, SitemapService>();
////Registra Feed de Produtos aqui no startup
//builder.Services.AddTransient<IProductFeedService, ProductFeedService>();





















////registrar serviços
//var app = builder.Build();




//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();

//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to app.UseHsts(),
//    app.UseHsts();

//}
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

//////Cria os perfis
////seedUserRoleInitial.SeedRoles();
//////Cria os usuários e atributos ao perfil
////seedUserRoleInitial.SeedUsers();

//app.UseSession();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    //remover se não quiser passar nome e id do produto na url
//    endpoints.MapControllerRoute(
//         name: "produto-details",
//         pattern: "Produto/{nome}-{produtoId}",
//         defaults: new { controller = "Produto", action = "Details" }
//     );
//    endpoints.MapControllerRoute(
//          name: "areas",
//          pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
//        );


//    endpoints.MapControllerRoute(
//        name: "categoriaFiltro",
//            pattern: "Categoria/{categoria}-{categoriaid}",/*pattern: "Produto/{action}/{categoria?}"*/
//        defaults: new { Controller = "Produto", action = "List" });

//    endpoints.MapControllerRoute(
//name: "default",
//pattern: "{controller=Home}/{action=Index}/{id?}");


//});





























////configurar o pipeline do request da aplicação
//app.Run();

//void CriarPerfisUsuarios(WebApplication app)
//{
//    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
//    using (var scope = scopedFactory.CreateScope())
//    {
//        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
//        service.SeedUsers();
//        service.SeedRoles();
//    }

//}

