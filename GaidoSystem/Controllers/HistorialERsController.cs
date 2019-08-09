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
    public class HistorialERsController : Controller
    {
        private readonly GaidoSystemContext _context;

        public HistorialERsController(GaidoSystemContext context)
        {
            _context = context;
        }

        // GET: HistorialERs
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistorialER.ToListAsync());
        }

        // GET: HistorialERs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialER = await _context.HistorialER
                .FirstOrDefaultAsync(m => m.HistorialERId == id);
            if (historialER == null)
            {
                return NotFound();
            }

            return View(historialER);
        }

        // GET: HistorialERs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistorialERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistorialERId,Fecha,VentasNetas,CostosVentas,GastosAdmin,GastosVentas,GastosOperativos,OtrosGastos")] HistorialER historialER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historialER);
        }

        // GET: HistorialERs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialER = await _context.HistorialER.FindAsync(id);
            if (historialER == null)
            {
                return NotFound();
            }
            return View(historialER);
        }

        // POST: HistorialERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistorialERId,Fecha,VentasNetas,CostosVentas,GastosAdmin,GastosVentas,GastosOperativos,OtrosGastos")] HistorialER historialER)
        {
            if (id != historialER.HistorialERId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialERExists(historialER.HistorialERId))
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
            return View(historialER);
        }

        // GET: HistorialERs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialER = await _context.HistorialER
                .FirstOrDefaultAsync(m => m.HistorialERId == id);
            if (historialER == null)
            {
                return NotFound();
            }

            return View(historialER);
        }

        // POST: HistorialERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialER = await _context.HistorialER.FindAsync(id);
            _context.HistorialER.Remove(historialER);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialERExists(int id)
        {
            return _context.HistorialER.Any(e => e.HistorialERId == id);
        }
    }
}
