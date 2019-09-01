using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaidoSystem.Models;

namespace GaidoSystem.Controllers
{
    public class AnualidadERsController : Controller
    {
        private readonly GaidoSystemContext _context;

        public AnualidadERsController(GaidoSystemContext context)
        {
            _context = context;
        }

        // GET: AnualidadERs
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: AnualidadERs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anualidadER = await _context.AnualidadER
                .FirstOrDefaultAsync(m => m.AnualidadERId == id);
            if (anualidadER == null)
            {
                return NotFound();
            }

            return View(anualidadER);
        }

        // GET: AnualidadERs/Create
        public IActionResult Create()
        {
            ViewBag.ModeloAuto = _context.ModeloProyeccion.FirstOrDefault(a => a.ModeloProyeccionId == 1);
            ViewBag.lastER = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1);
            ViewBag.lastPro = _context.Proyecciones.LastOrDefault(a => a.ModeloProyeccionId == 1);
            ViewBag.procount = _context.Proyecciones.Where(a => a.ModeloProyeccionId == 1).ToList();
            
            return View();
        }

        // POST: AnualidadERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fecha,ProVentasNetas,ProCostosVentas,ProGastosAdmin,ProGastosVentas,ProGastosOperativos,ProOtrosGastos,proUtilidad,proIR,proUtilidadNeta")] Proyecciones proyecciones )
        {
            var model = _context.ModeloProyeccion.Include(m => m.ListaProyecciones).FirstOrDefault(m => m.ModeloProyeccionId == 1);
            model.ListaProyecciones.Add(proyecciones);
            _context.ModeloProyeccion.Update(model);
            _context.SaveChanges();
            return RedirectToAction();
        }

        // GET: AnualidadERs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anualidadER = await _context.AnualidadER.FindAsync(id);
            if (anualidadER == null)
            {
                return NotFound();
            }
            return View(anualidadER);
        }

        // POST: AnualidadERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnualidadERId,Year,Notas")] AnualidadER anualidadER)
        {
            if (id != anualidadER.AnualidadERId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anualidadER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnualidadERExists(anualidadER.AnualidadERId))
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
            return View(anualidadER);
        }

        // GET: AnualidadERs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anualidadER = await _context.AnualidadER
                .FirstOrDefaultAsync(m => m.AnualidadERId == id);
            if (anualidadER == null)
            {
                return NotFound();
            }

            return View(anualidadER);
        }

        // POST: AnualidadERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anualidadER = await _context.AnualidadER.FindAsync(id);
            _context.AnualidadER.Remove(anualidadER);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnualidadERExists(int id)
        {
            return _context.AnualidadER.Any(e => e.AnualidadERId == id);
        }
    }
}
