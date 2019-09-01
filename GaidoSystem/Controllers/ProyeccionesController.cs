using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GaidoSystem.Models;
using System.Dynamic;
using Microsoft.CSharp.RuntimeBinder;

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

            HistorialER hr;
            

            if (_context.ModeloProyeccion.Count()<=1)
            {
                hr = new HistorialER();
                hr.Fecha = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).Fecha;
                hr.VentasNetas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).VentasNetas;
                hr.CostosVentas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).CostosVentas;
                hr.GastosAdmin = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosAdmin;
                hr.GastosVentas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosVentas;
                hr.GastosOperativos = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosOperativos;
                hr.OtrosGastos = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).OtrosGastos;
                hr.Utilidad = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).Utilidad;
                hr.IR = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).IR;
                hr.UtilidadNeta = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).UtilidadNeta;

                modpro = new ModeloProyeccion { ModVentasNetas=0.00m, ModCostosVentas = 0.00m, ModGastosAdmin = 0.00m,
                    ModGastosOperativos = 0.00m, ModGastosVentas = 0.00m, ModOtrosGastos = 0.00m,
                    ModUtilidad = 0.00m,ModIR=0.00m,ModUtilidadNeta=0.00m,HistotialesER = new List<HistorialER> { hr}
                };
                _context.ModeloProyeccion.Add(modpro);
                _context.SaveChanges();
                ViewBag.modelo = _context.ModeloProyeccion.Include(m => m.HistotialesER).FirstOrDefault(a=>a.ModeloProyeccionId==2);//
            }
            else
            {
                hr = _context.HistorialER.FirstOrDefault(a => a.ModeloProyeccionId == 2);
                hr.Fecha = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).Fecha;
                hr.VentasNetas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).VentasNetas;
                hr.CostosVentas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).CostosVentas;
                hr.GastosAdmin = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosAdmin;
                hr.GastosVentas = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosVentas;
                hr.GastosOperativos = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).GastosOperativos;
                hr.OtrosGastos = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).OtrosGastos;
                hr.Utilidad = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).Utilidad;
                hr.IR = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).IR;
                hr.UtilidadNeta = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1).UtilidadNeta;
                _context.HistorialER.Update(hr);
                _context.SaveChanges();
            }
            ViewBag.modelo = _context.ModeloProyeccion.Include(m => m.HistotialesER).FirstOrDefault(a => a.ModeloProyeccionId == 2);
            ViewBag.ultimaproyeccion = _context.Proyecciones.LastOrDefault();
            ViewBag.lastER = _context.HistorialER.LastOrDefault(a => a.ModeloProyeccionId == 1);
            ViewBag.cantidad = _context.Proyecciones.ToList();

            return View();

        }

        // POST: Proyecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fecha,ProVentasNetas,ProCostosVentas,ProGastosAdmin,ProGastosVentas,ProGastosOperativos,ProOtrosGastos,proUtilidad,proIR,proUtilidadNeta")] Proyecciones proyecciones)
        {
            
                var model = _context.ModeloProyeccion.Include(m => m.ListaProyecciones).FirstOrDefault(m => m.ModeloProyeccionId == 2);
                model.ListaProyecciones.Add(proyecciones);
                _context.ModeloProyeccion.Update(model);
                _context.SaveChanges();
                return RedirectToAction();
                
                
            


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
