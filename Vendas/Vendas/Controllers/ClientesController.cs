using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Data;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class ClientesController : Controller
    {
        private readonly VNDContext _context;

        public ClientesController(VNDContext context)
        {
            _context = context;
        }

        #region Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _context.Clientes.OrderBy(vnd => vnd.Nome).ToListAsync());
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<ActionResult> Details(long? id)
        {
            Clientes cliente = new Clientes();
            if (id != null)
            {
                cliente = (await _context.Clientes.FirstOrDefaultAsync(cli => cli.ClientesId == id));
            }
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        #endregion]

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco,Cidade,Uf,Cep,Celular,email")] Clientes cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Falha ao inserir registro");
            }
            return View(cliente);
        }

        #endregion

        #region Edit
        [HttpGet]
        public async Task<ActionResult> Edit(long? id)
        {
            Clientes cliente = new Clientes();
            if (id != null)
            {
                cliente = (await _context.Clientes.FirstOrDefaultAsync(cli => cli.ClientesId == id));
            }
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long? id, [Bind("ClientesId,Nome,Endereco,Cidade,Uf,Cep,Celular,email")] Clientes cliente)
        {
            if (id != cliente.ClientesId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.Message, "Falha ao atualizar registro");
                }
            }
            return View(cliente);
        }



        #endregion


        #region Delete
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Clientes clientes = new Clientes();
            if (id != null)
            {
                clientes = (await _context.Clientes.FirstOrDefaultAsync(vnd => vnd.ClientesId == id));
            }
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(vnd => vnd.ClientesId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
