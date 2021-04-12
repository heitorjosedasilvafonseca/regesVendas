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
    public class VendedoresController : Controller
    {
        private readonly VNDContext _context;

        public VendedoresController(VNDContext context)
        {
            _context = context;
        }

        #region Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await _context.Vendedores.OrderBy(vnd => vnd.Nome).ToListAsync());
        }
        #endregion

        #region Details
        [HttpGet]
        public async Task<ActionResult> Details(long? id)
        {
            Vendedores vendedor = new Vendedores();
            if (id != null)
            {
                vendedor = (await _context.Vendedores.FirstOrDefaultAsync(vnd => vnd.VendedoresId == id));
            }
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(await _context.Vendedores.FirstOrDefaultAsync(vnd => vnd.VendedoresId == id));
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
        public async Task<IActionResult> Create([Bind("Nome,Celular,email,ValorMeta")] Vendedores vendedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(vendedor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Falha ao inserir registro");
            }
            return View(vendedor);
        }

        #endregion

        #region Edit
        [HttpGet]
        public async Task<ActionResult> Edit(long? id)
        {
            Vendedores vendedor = new Vendedores();
            if (id != null)
            {
                vendedor = (await _context.Vendedores.FirstOrDefaultAsync(vnd => vnd.VendedoresId == id));
            }
            if (vendedor == null)
            {
                return NotFound();
            }
            //return View(await _context.Vendedores.FirstOrDefaultAsync(vnd => vnd.VendedoresId == id));
            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long? id,[Bind("VendedoresId,Nome,Celular,email,ValorMeta")] Vendedores vendedor)
        {
            if (id != vendedor.VendedoresId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.Message, "Falha ao atualizar registro");
                }
            }
            return View(vendedor);
        }

        #endregion

        #region Delete
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            Vendedores vendedor = new Vendedores();
            if (id != null)
            {
                vendedor = (await _context.Vendedores.FirstOrDefaultAsync(vnd => vnd.VendedoresId == id));
            }
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(await _context.Vendedores.FirstOrDefaultAsync(vnd => vnd.VendedoresId == id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vendedor = await _context.Vendedores.SingleOrDefaultAsync(vnd => vnd.VendedoresId == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
