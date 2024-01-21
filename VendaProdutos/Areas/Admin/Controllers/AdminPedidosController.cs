using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.Repositories.Interfaces;
using VendaProdutos.ViewModel;

namespace VendaProdutos.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPedidosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProdutoRepository _produtoRepository;

         

        public AdminPedidosController(AppDbContext context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;

        }

        public IActionResult PedidoProdutos(int? id)
        {
            var pedido = _context.Pedidos
                .Include(pd => pd.PedidoItens)
                .ThenInclude(l => l.Produto)
                .FirstOrDefault(p => p.PedidoId == id);
            if(pedido == null)
            {
                Response.StatusCode = 404;
                return View("PedidoNotFound", id ?? 0); //id.Value
            }
            PedidoProdutoViewModel pedidoProdutos = new PedidoProdutoViewModel()
            {
                Pedido = pedido,
                PedidoDetalhes = pedido.PedidoItens,
                Produtos = _produtoRepository.Produtos
            };
            return View(pedidoProdutos);

        }


        // GET: Admin/AdminPedidos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Pedidos.ToListAsync());
        //}

        //public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "NomeComprador")
        //{
        //    var resultado = _context.Pedidos.AsNoTracking()
        //        .AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(filter))
        //    {
        //        resultado = resultado.Where(p => p.NomeComprador.Contains(filter));
        //    }
        //    var model = await PagingList.CreateAsync(resultado, 10, pageindex, sort, "NomeComprador");

        //    model.RouteValue = new RouteValueDictionary { { "filter", filter } };
        //    return View(model);
        //}



        public async Task<IActionResult> Index(string compradorFilter, string whatsappFilter, string recebedorFilter, string dataEntregaFilter, int? idPedidoFilter, bool? pagamentoEfetuadoFilter, string horaEntregaFilter, int pageindex = 1, string sort = "NomeComprador")
{
    var resultado = _context.Pedidos.AsNoTracking().AsQueryable();

var pagamentoOptions = new List<SelectListItem>
{
    new SelectListItem { Text = "Todos", Value = "", Selected = !pagamentoEfetuadoFilter.HasValue },
    new SelectListItem { Text = "Já pagou", Value = "True", Selected = pagamentoEfetuadoFilter == true },
    new SelectListItem { Text = "Não pagou", Value = "False", Selected = pagamentoEfetuadoFilter == false }
};

            var horasOptions = new List<SelectListItem>
{
 new SelectListItem { Value = "06:00", Text = "Manhã, 06h00 às 06h59"},
 new SelectListItem { Value = "07:00", Text = "Manhã, 07h00 às 07h59"},
 new SelectListItem { Value = "08:00", Text = "Manhã, 08h00 às 08h59"},
 new SelectListItem { Value = "09:00", Text = "Manhã, 09h00 às 09h59"},
 new SelectListItem { Value = "10:00", Text = "Manhã, 10h00 às 10h59"},
 new SelectListItem { Value = "11:00", Text = "Manhã, 11h00 às 11h59"},
 new SelectListItem { Value = "12:00", Text = "Manhã, 12h00 às 12h59"},
 new SelectListItem { Value = "13:00", Text = "Tarde, 13h00 às 13h59"},
 new SelectListItem { Value = "14:00", Text = "Tarde, 14h00 às 14h59"},
 new SelectListItem { Value = "15:00", Text = "Tarde, 15h00 às 15h59"},
 new SelectListItem { Value = "16:00", Text = "Tarde, 16h00 às 16h59"},
 new SelectListItem { Value = "17:00", Text = "Tarde, 17h00 às 17h59"},
 new SelectListItem { Value = "06:00", Text = "Manhã, 06h00 às 06h59"},
 new SelectListItem { Value = "07:00", Text = "Manhã, 07h00 às 07h59"},
 new SelectListItem { Value = "08:00", Text = "Manhã, 08h00 às 08h59"},
 new SelectListItem { Value = "09:00", Text = "Manhã, 09h00 às 09h59"},
 new SelectListItem { Value = "10:00", Text = "Manhã, 10h00 às 10h59"},
 new SelectListItem { Value = "11:00", Text = "Manhã, 11h00 às 11h59"},
 new SelectListItem { Value = "12:00", Text = "Manhã, 12h00 às 12h59"},
 new SelectListItem { Value = "13:00", Text = "Tarde, 13h00 às 13h59"},
 new SelectListItem { Value = "14:00", Text = "Tarde, 14h00 às 14h59"},
 new SelectListItem { Value = "15:00", Text = "Tarde, 15h00 às 15h59"},
 new SelectListItem { Value = "16:00", Text = "Tarde, 16h00 às 16h59"},
 new SelectListItem { Value = "17:00", Text = "Tarde, 17h00 às 17h59"},
 new SelectListItem { Value = "06:00", Text = "Manhã, 06h00 às 06h59"},
 new SelectListItem { Value = "07:00", Text = "Manhã, 07h00 às 07h59"},
 new SelectListItem { Value = "08:00", Text = "Manhã, 08h00 às 08h59"},
 new SelectListItem { Value = "09:00", Text = "Manhã, 09h00 às 09h59"},
 new SelectListItem { Value = "10:00", Text = "Manhã, 10h00 às 10h59"},
 new SelectListItem { Value = "11:00", Text = "Manhã, 11h00 às 11h59"},
 new SelectListItem { Value = "12:00", Text = "Manhã, 12h00 às 12h59"},
 new SelectListItem { Value = "13:00", Text = "Tarde, 13h00 às 13h59"},
 new SelectListItem { Value = "14:00", Text = "Tarde, 14h00 às 14h59"},
 new SelectListItem { Value = "15:00", Text = "Tarde, 15h00 às 15h59"},
 new SelectListItem { Value = "16:00", Text = "Tarde, 16h00 às 16h59"},
 new SelectListItem { Value = "17:00", Text = "Tarde, 17h00 às 17h59"},
                      new SelectListItem { Value = "", Text = "Todos os horários"}

}; 


            // Passar a lista para a view
            ViewData["PagamentoOptions"] = pagamentoOptions;
            // Passar a lista para a view
            ViewData["HorasOptions"] = horasOptions;

            if (!string.IsNullOrWhiteSpace(compradorFilter))
    {
        resultado = resultado.Where(p => p.NomeComprador.Contains(compradorFilter));
    }
            if (idPedidoFilter.HasValue)
            {
                 resultado = resultado.Where(p => p.PedidoId == idPedidoFilter.Value);

            }

            if (!string.IsNullOrWhiteSpace(whatsappFilter))
            {
                resultado = resultado.Where(p => p.WhatsappComprador.Contains(whatsappFilter));
            }

            if (!string.IsNullOrWhiteSpace(recebedorFilter))
            {
                resultado = resultado.Where(p => p.NomeRecebedor.Contains(recebedorFilter));
            }

            if (!string.IsNullOrWhiteSpace(dataEntregaFilter))
            {
                resultado = resultado.Where(p => p.DataDeEntrega.Contains(dataEntregaFilter));
            }

            if (pagamentoEfetuadoFilter.HasValue)
            {
                resultado = resultado.Where(p => p.PagamentoPedido == pagamentoEfetuadoFilter.Value);
            }
            
            if (!string.IsNullOrWhiteSpace(horaEntregaFilter))
            {
                resultado = resultado.Where(p => p.HoraDeEntrega.Contains(horaEntregaFilter));


            }




            decimal somaPagos = 0;
            decimal somaNaoPagos = 0;

            foreach (var pedido in resultado)
            {

                if (pedido.PagamentoPedido) {
                    somaPagos += pedido.TotalPedido;
                }

                if (!pedido.PagamentoPedido)
                {
                    somaNaoPagos += pedido.TotalPedido;
                }
            }

            ViewBag.SomaPedidosPagos = somaPagos;
            ViewBag.SomaPedidosNaoPagos = somaNaoPagos;



            var model = await PagingList.CreateAsync(resultado, 10, pageindex, sort, "DataDeEntrega");

            
            model.RouteValue = new RouteValueDictionary
    {
        { "compradorFilter", compradorFilter },
         { "whatsappFilter", whatsappFilter },
        {"recebedorFilter", recebedorFilter},
        {"dataEntregaFilter", dataEntregaFilter},
       {"pagamentoEfetuadoFilter",pagamentoEfetuadoFilter },
        {"idPedidoFilter", idPedidoFilter},
                        {"horaEntregaFilter", horaEntregaFilter}

                
    };

    return View(model);
}


        // GET: Admin/AdminPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Admin/AdminPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,NomeComprador,WhatsappComprador,NomeRecebedor,BairroRecebedor,RuaRecebedor,QuemEstaEnviando,NumeroCasaRecebedor,NomeDaEmpresa,Setor,PontoDeReferencia,WhatsappRecebedor,DataDeEntrega,HoraDeEntrega,TelefoneCompradorDiferenteDoCadastro,Observacoes,Cartinha,ComprovanteDePagamento,PedidoEnviado,PedidoEntregueEm,PagamentoPedido,PagamentoNaEntrega,EntregaPedido")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Admin/AdminPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Admin/AdminPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,NomeComprador,WhatsappComprador,NomeRecebedor,BairroRecebedor,RuaRecebedor,QuemEstaEnviando,NumeroCasaRecebedor,NomeDaEmpresa,Setor,PontoDeReferencia,WhatsappRecebedor,DataDeEntrega,HoraDeEntrega,TelefoneCompradorDiferenteDoCadastro,Observacoes,Cartinha,ComprovanteDePagamento,PedidoEnviado,PedidoEntregueEm,PagamentoPedido,PagamentoNaEntrega,EntregaPedido,PagamentoParcial,ComprovanteSegundoPagamento,Complemento")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Admin/AdminPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Admin/AdminPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
