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
            var modelopro = await _context.ModeloProyeccion.Include(a=>a.HistotialesER).FirstAsync(a=>a.ModeloProyeccionId==1);
            
            //TODO:modelo proreccion
            return View(modelopro);
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
        public async Task<IActionResult> Create([Bind("HistorialERId,Fecha,VentasNetas,CostosVentas,GastosAdmin,GastosVentas,GastosOperativos,OtrosGastos,Utilidad,IR,UtilidadNeta")] HistorialER historialER)
        {
            if (ModelState.IsValid)
            {
                ModeloProyeccion modproyeccion;
                //TODO:Primero Ingresar un ModeloPRoyeccion de 0.0%
                if (_context.ModeloProyeccion.Count()== 0) {
                    modproyeccion = new ModeloProyeccion {
                        Fecha = DateTime.Today,
                        ModVentasNetas = Convert.ToDecimal(0.00),
                        ModCostosVentas = Convert.ToDecimal(0.00),
                        ModGastosAdmin = Convert.ToDecimal(0.00),
                        ModGastosVentas = Convert.ToDecimal(0.00),
                        ModGastosOperativos = Convert.ToDecimal(0.00),
                        ModOtrosGastos = Convert.ToDecimal(0.00),
                        ModUtilidad = Convert.ToDecimal(0.00),
                        ModIR = Convert.ToDecimal(0.00),
                        ModUtilidadNeta = Convert.ToDecimal(0.00),
                         HistotialesER = new List<HistorialER>
                       {
                           historialER
                       }
                };
                    _context.Add(modproyeccion);
                    _context.SaveChanges();
                }
                else
                { 
                    var modelo= _context.ModeloProyeccion.Include(a=>a.HistotialesER).FirstOrDefault(a=>a.ModeloProyeccionId==1);
                    var firstEr= modelo.HistotialesER.FirstOrDefault(a=>a.HistorialERId==1);
                    //modelo.ModVentasNetas = firstEr.VentasNetas;
                    //modelo.ModCostosVentas = firstEr.CostosVentas;
                    //modelo.ModGastosAdmin = firstEr.GastosAdmin;
                    //modelo.ModGastosVentas = firstEr.GastosVentas;
                    //modelo.ModGastosOperativos = firstEr.GastosOperativos;
                    //modelo.ModOtrosGastos = firstEr.OtrosGastos;
                    //modelo.ModUtilidad = firstEr.Utilidad;
                    //modelo.ModIR = firstEr.IR;
                    //modelo.ModUtilidadNeta = firstEr.UtilidadNeta;
                    modelo.HistotialesER.Add(historialER);
                    List<HistorialER> lister = modelo.HistotialesER.Where(a => a.HistorialERId != 1).ToList();
                    foreach (var item in lister)
                    {
                        modelo.ModVentasNetas = Convert.ToDecimal(Math.Round((item.VentasNetas/ firstEr.VentasNetas),2));
                        modelo.ModCostosVentas = Convert.ToDecimal(Math.Round((item.CostosVentas / firstEr.CostosVentas), 2));
                        modelo.ModGastosAdmin = Convert.ToDecimal(Math.Round((item.GastosAdmin / firstEr.GastosAdmin), 2));
                        modelo.ModGastosVentas = Convert.ToDecimal(Math.Round((item.GastosVentas / firstEr.GastosVentas), 2));
                        modelo.ModGastosOperativos = Convert.ToDecimal(Math.Round((item.GastosOperativos / firstEr.GastosOperativos), 2));
                        modelo.ModOtrosGastos = Convert.ToDecimal(Math.Round((item.OtrosGastos / firstEr.OtrosGastos), 2));
                        modelo.ModUtilidad= Convert.ToDecimal(Math.Round((item.Utilidad / firstEr.Utilidad), 2));
                        modelo.ModIR = Convert.ToDecimal(Math.Round((item.IR / firstEr.IR), 2));
                        modelo.ModUtilidadNeta = Convert.ToDecimal(Math.Round((item.UtilidadNeta / firstEr.UtilidadNeta), 2));
                    }
                _context.Update(modelo);
                await _context.SaveChangesAsync();
                }
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

        public ActionResult toProyectar()
        {
            return RedirectToAction("Create", "Proyecciones");
        }
    }
}
