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
            return View(await _context.AnualidadER.ToListAsync());
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
            return View();
        }

        // POST: AnualidadERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnualidadERId,Year,Notas")] AnualidadER anualidadER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anualidadER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anualidadER);
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
