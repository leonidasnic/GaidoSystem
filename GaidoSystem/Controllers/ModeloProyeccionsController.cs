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
    public class ModeloProyeccionsController : Controller
    {
        private readonly GaidoSystemContext _context;

        public ModeloProyeccionsController(GaidoSystemContext context)
        {
            _context = context;
        }

        // GET: ModeloProyeccions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModeloProyeccion.ToListAsync());
        }

        // GET: ModeloProyeccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloProyeccion = await _context.ModeloProyeccion
                .FirstOrDefaultAsync(m => m.ModeloProyeccionId == id);
            if (modeloProyeccion == null)
            {
                return NotFound();
            }

            return View(modeloProyeccion);
        }

        // GET: ModeloProyeccions/Create
        public async    Task <IActionResult> Create()
        {
            return View(await _context.ModeloProyeccion.Include(a=>a.HistotialesER).ToListAsync());
        }

        // POST: ModeloProyeccions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModeloProyeccionId,Fecha,ModVentasNetas,ModCostosVentas,ModGastosAdmin,ModGastosVentas,ModGastosOperativos,ModOtrosGastos")] ModeloProyeccion modeloProyeccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloProyeccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloProyeccion);
        }

        // GET: ModeloProyeccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloProyeccion = await _context.ModeloProyeccion.FindAsync(id);
            if (modeloProyeccion == null)
            {
                return NotFound();
            }
            return View(modeloProyeccion);
        }

        // POST: ModeloProyeccions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModeloProyeccionId,Fecha,ModVentasNetas,ModCostosVentas,ModGastosAdmin,ModGastosVentas,ModGastosOperativos,ModOtrosGastos")] ModeloProyeccion modeloProyeccion)
        {
            if (id != modeloProyeccion.ModeloProyeccionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloProyeccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProyeccionExists(modeloProyeccion.ModeloProyeccionId))
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
            return View(modeloProyeccion);
        }

        // GET: ModeloProyeccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloProyeccion = await _context.ModeloProyeccion
                .FirstOrDefaultAsync(m => m.ModeloProyeccionId == id);
            if (modeloProyeccion == null)
            {
                return NotFound();
            }

            return View(modeloProyeccion);
        }

        // POST: ModeloProyeccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloProyeccion = await _context.ModeloProyeccion.FindAsync(id);
            _context.ModeloProyeccion.Remove(modeloProyeccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProyeccionExists(int id)
        {
            return _context.ModeloProyeccion.Any(e => e.ModeloProyeccionId == id);
        }
    }
}
