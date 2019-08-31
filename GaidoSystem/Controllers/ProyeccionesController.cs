using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaidoSystem.Models;
using System.Dynamic;

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
        //    @*Ventas netas
        //Costos de ventas
        //Gastos Administrativos
        //Gastos de venta
        //Gastos de Operacion
        //Otros Gastos
        //Utilidad
        //IR
        //Utilidad Neta*@
            ModeloProyeccion modpro;

            HistorialER hr = new HistorialER();
            hr.Fecha = _context.HistorialER.LastOrDefault(a=>a.ModeloProyeccionId==1).Fecha;
            hr.VentasNetas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).VentasNetas;
            hr.CostosVentas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).CostosVentas;
            hr.GastosAdmin = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosAdmin;
            hr.GastosVentas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosVentas;
            hr.GastosOperativos = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosOperativos;
            hr.OtrosGastos = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).OtrosGastos;
            hr.Utilidad = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).Utilidad;
            hr.IR = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).IR;
            hr.UtilidadNeta = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).UtilidadNeta;

            if (_context.ModeloProyeccion.Count()<=1)
            {
                modpro = new ModeloProyeccion { ModVentasNetas=0.00m, ModCostosVentas = 0.00m, ModGastosAdmin = 0.00m,
                    ModGastosOperativos = 0.00m, ModGastosVentas = 0.00m, ModOtrosGastos = 0.00m,
                    ModUtilidad = 0.00m,ModIR=0.00m,ModUtilidadNeta=0.00m,HistotialesER = new List<HistorialER> { hr}
                };
                _context.ModeloProyeccion.Add(modpro);
                _context.SaveChanges();
                modpro = _context.ModeloProyeccion.Include(m => m.HistotialesER).LastOrDefault();
            }
            else
            {
                var er = _context.HistorialER.FirstOrDefault(A => A.ModeloProyeccionId == 2);
                er.Fecha = hr.Fecha;
                er.VentasNetas = hr.VentasNetas;
                er.CostosVentas = hr.CostosVentas;
                er.GastosAdmin = hr.GastosAdmin;
                er.GastosVentas = hr.GastosVentas;
                er.GastosOperativos = hr.GastosOperativos;
                er.OtrosGastos = hr.OtrosGastos;
                er.Utilidad = hr.Utilidad;
                er.IR = hr.IR;
                er.UtilidadNeta = hr.UtilidadNeta;
                _context.HistorialER.Update(er);
                modpro = _context.ModeloProyeccion.Include(m=>m.HistotialesER).FirstOrDefault(a=>a.ModeloProyeccionId==2);
                
            }
           
            return View(modpro);
        }

        // POST: Proyecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModeloProyeccion ModPRo)
        {
            if (ModelState.IsValid)
            {
                _context.ModeloProyeccion.Update(ModPRo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
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
