
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendaProdutos.Untilities
{
    public class NotFoundMiddleware  
    {
        private readonly RequestDelegate _next;
private readonly ILogger<NotFoundMiddleware> _logger;
 public NotFoundMiddleware(RequestDelegate next, ILogger<NotFoundMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
 public async Task Invoke(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 404)
            {
                _logger.LogInformation($"Handling 404 error for request {context.Request.Path}");
                context.Response.StatusCode = 404;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(@"
<html>
<head>
<meta charset=""utf-8""><meta http-equiv=""Content-Language"" content=""pt-BR"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">

</head>
<body data-spy=""scroll"">
    <section id=""para-voce"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-5 col-lg-6"">
                    <div style=""font-size: 161px; font-weight: bold; color: #ff4d00; text-align: center; font-family: tahoma, sans-serif;"">
                        404
                    </div>
                </div>
                <article class=""col-md-7 col-lg-6"">
                    <h2 class=""mt_30_gen tit1_gen cor_fo0_gen mt_13_gen"" style=""font-family: tahoma, sans-serif; text-align: center; font-size: 35px; color: #000; margin: auto; max-width: 581px; line-height: 35px;"">
                        <span style=""color: #ff4d00; font-family: tahoma, sans-serif;display:block"">Não conseguimos encontrar</span> o que você estava procurando.
                    </h2>
                    <a href=""https://pradois.com.br/"" style=""display: block; background: #00a650; border-radius: 50px; height: 60px; line-height: 60px; text-align: center; max-width: 300px; font-family: tahoma, sans-serif; font-size: 25px; color: #fff; text-decoration: none; margin: 30px auto;"">Voltar a Home</a>
                    <p class=""descri1_gen color_fr0_gen mt_22_gen"" style=""font-family: tahoma, sans-serif; text-align: center; font-size: 24px; color: #4a4a4a; max-width: 790px; line-height: 38px; margin: 15px auto 0 auto;"">
                        Infelizmente a página que você estava procurando não foi encontrada. Ela pode estar temporariamente indisponível, pode ter sido movida ou não existir mais.
                    </p>
                </article>
            </div>
        </div>
    </section>
</body>
</html>");
}

            if (context.Response.StatusCode == 500)
            {
                _logger.LogInformation($"Handling 500 error for request {context.Request.Path}");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(@"
<html>
<head>
<meta charset=""utf-8""><meta http-equiv=""Content-Language"" content=""pt-BR"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">

</head>
<body data-spy=""scroll"">
    <section id=""para-voce"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-5 col-lg-6"">
                    <div style=""font-size: 161px; font-weight: bold; color: #ff4d00; text-align: center; font-family: tahoma, sans-serif;"">
                        500
                    </div>
                </div>
                <article class=""col-md-7 col-lg-6"">
                    <h2 class=""mt_30_gen tit1_gen cor_fo0_gen mt_13_gen"" style=""font-family: tahoma, sans-serif; text-align: center; font-size: 35px; color: #000; margin: auto; max-width: 581px; line-height: 35px;"">
                        <span style=""color: #ff4d00; font-family: tahoma, sans-serif;"">Tente novamente mais tarde</span> nosso site está em manutenção.
                    </h2>
                    <a href=""https://api.whatsapp.com/send?phone=+5575991702469&text=OL%C3%A1%2C+como+o+site+est%C3%A1+em+manuten%C3%A7%C3%A3o%2C+eu+gostaria+de+fazer+meu+pedido+aqui+pelo+whatsapp+mesmo."" style=""display: block; background: #00a650; border-radius: 50px; height: 60px; line-height: 60px; text-align: center; max-width: 300px; font-family: tahoma, sans-serif; font-size: 25px; color: #fff; text-decoration: none; margin: 30px auto;"">Comprar pelo Whatsapp</a>
                    <p class=""descri1_gen color_fr0_gen mt_22_gen"" style=""font-family: tahoma, sans-serif; text-align: center; font-size: 24px; color: #4a4a4a; max-width: 790px; line-height: 38px; margin: 15px auto 0 auto;"">
                        No momento nosso time de tecnologia está dando manutenção no site. Em breve você poderá comprar por ele novamente, mas ainda é possível fazer pedido no nosso Whatsapp: <a href=""https://api.whatsapp.com/send?phone=+5575991702469&text=OL%C3%A1%2C+como+o+site+est%C3%A1+em+manuten%C3%A7%C3%A3o%2C+eu+gostaria+de+fazer+meu+pedido+aqui+pelo+whatsapp+mesmo."">(75) 9 9170-2469</a>.
                    </p>
                </article>
            </div>
        </div>
    </section>
</body>
</html>");
            }
        }
    }
}
