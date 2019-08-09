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
    public class ProyeccionesController : Controller
    {
        private readonly GaidoSystemContext _context;

        public ProyeccionesController(GaidoSystemContext context)
        {
            _context = context;
        }

        // GET: Proyecciones
        public async Task<IActionResult> Index()
        {
            var gaidoSystemContext = _context.Proyecciones.Include(p => p.ModeloProyeccion);
            return View(await gaidoSystemContext.ToListAsync());
        }

        // GET: Proyecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecciones = await _context.Proyecciones
                .Include(p => p.ModeloProyeccion)
                .FirstOrDefaultAsync(m => m.ProyeccionesId == id);
            if (proyecciones == null)
            {
                return NotFound();
            }

            return View(proyecciones);
        }

        // GET: Proyecciones/Create
        public IActionResult Create()
        {
            ViewData["ModeloProyeccionId"] = new SelectList(_context.ModeloProyeccion, "ModeloProyeccionId", "ModeloProyeccionId");
            return View();
        }

        // POST: Proyecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProyeccionesId,Fecha,ProVentasNetas,ProCostosVentas,ProGastosAdmin,ProGastosVentas,ProGastosOperativos,ProOtrosGastos,ModeloProyeccionId")] Proyecciones proyecciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyecciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModeloProyeccionId"] = new SelectList(_context.ModeloProyeccion, "ModeloProyeccionId", "ModeloProyeccionId", proyecciones.ModeloProyeccionId);
            return View(proyecciones);
        }

        // GET: Proyecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecciones = await _context.Proyecciones.FindAsync(id);
            if (proyecciones == null)
            {
                return NotFound();
            }
            ViewData["ModeloProyeccionId"] = new SelectList(_context.ModeloProyeccion, "ModeloProyeccionId", "ModeloProyeccionId", proyecciones.ModeloProyeccionId);
            return View(proyecciones);
        }

        // POST: Proyecciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProyeccionesId,Fecha,ProVentasNetas,ProCostosVentas,ProGastosAdmin,ProGastosVentas,ProGastosOperativos,ProOtrosGastos,ModeloProyeccionId")] Proyecciones proyecciones)
        {
            if (id != proyecciones.ProyeccionesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyecciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyeccionesExists(proyecciones.ProyeccionesId))
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
            ViewData["ModeloProyeccionId"] = new SelectList(_context.ModeloProyeccion, "ModeloProyeccionId", "ModeloProyeccionId", proyecciones.ModeloProyeccionId);
            return View(proyecciones);
        }

        // GET: Proyecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proyecciones = await _context.Proyecciones
                .Include(p => p.ModeloProyeccion)
                .FirstOrDefaultAsync(m => m.ProyeccionesId == id);
            if (proyecciones == null)
            {
                return NotFound();
            }

            return View(proyecciones);
        }

        // POST: Proyecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proyecciones = await _context.Proyecciones.FindAsync(id);
            _context.Proyecciones.Remove(proyecciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyeccionesExists(int id)
        {
            return _context.Proyecciones.Any(e => e.ProyeccionesId == id);
        }
    }
}
