using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using VendaProdutos.Context;
using VendaProdutos.Models;
using VendaProdutos.ViewModel;

namespace VendaProdutos.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPedidosController : Controller
    {
        private readonly AppDbContext _context;

        public AdminPedidosController(AppDbContext context)
        {
            _context = context;
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
                PedidoDetalhes = pedido.PedidoItens
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



        public async Task<IActionResult> Index(string compradorFilter, string whatsappFilter, string recebedorFilter, string dataEntregaFilter, int? idPedidoFilter, bool? pagamentoEfetuadoFilter, int pageindex = 1, string sort = "NomeComprador")
{
    var resultado = _context.Pedidos.AsNoTracking().AsQueryable();

var pagamentoOptions = new List<SelectListItem>
{
    new SelectListItem { Text = "Todos", Value = "", Selected = !pagamentoEfetuadoFilter.HasValue },
    new SelectListItem { Text = "Sim", Value = "True", Selected = pagamentoEfetuadoFilter == true },
    new SelectListItem { Text = "Não", Value = "False", Selected = pagamentoEfetuadoFilter == false }
};

            // Passar a lista para a view
            ViewData["PagamentoOptions"] = pagamentoOptions;

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



            var model = await PagingList.CreateAsync(resultado, 10, pageindex, sort, "NomeComprador");

            
            model.RouteValue = new RouteValueDictionary
    {
        { "compradorFilter", compradorFilter },
         { "whatsappFilter", whatsappFilter },
        {"recebedorFilter", recebedorFilter},
        {"dataEntregaFilter", dataEntregaFilter},
       {"pagamentoEfetuadoFilter",pagamentoEfetuadoFilter },
        {"idPedidoFilter", idPedidoFilter}


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
        public async Task<IActionResult> Create([Bind("PedidoId,NomeComprador,WhatsappComprador,NomeRecebedor,BairroRecebedor,RuaRecebedor,ComplementoRecebedor,NumeroCasaRecebedor,NomeDaEmpresa,Setor,PontoDeReferencia,WhatsappRecebedor,DataDeEntrega,HoraDeEntrega,TelefoneCompradorDiferenteDoCadastro,Observacoes,Cartinha,ComprovanteDePagamento,PedidoEnviado,PedidoEntregueEm,PagamentoPedido,PagamentoNaEntrega,EntregaPedido")] Pedido pedido)
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
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,NomeComprador,WhatsappComprador,NomeRecebedor,BairroRecebedor,RuaRecebedor,ComplementoRecebedor,NumeroCasaRecebedor,NomeDaEmpresa,Setor,PontoDeReferencia,WhatsappRecebedor,DataDeEntrega,HoraDeEntrega,TelefoneCompradorDiferenteDoCadastro,Observacoes,Cartinha,ComprovanteDePagamento,PedidoEnviado,PedidoEntregueEm,PagamentoPedido,PagamentoNaEntrega,EntregaPedido,TotalPedido,TotalItensPedido")] Pedido pedido)
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
