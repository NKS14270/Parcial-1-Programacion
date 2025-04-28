using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Parcial_1__Programacion.Data;
using Parcial_1__Programacion.Models;

namespace Parcial_1__Programacion.Controllers
{
    public class PacientesController : Controller
    {

        DataDB data = new DataDB(); 
        // GET: PacientesController
        public ActionResult Index()
        {
            List<Paciente> lista = data.ListarPacientes(0 ,0);
            return View(lista);
        }

        // GET: PacientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacientesController/Create
        public ActionResult Create()
        {
            List<Obrasocial> listaobrasocial = data.ListarObras(0);
            ViewBag.Obrassociales = new SelectList(listaobrasocial, "Id", "Nombre");
            return View();
        }

        // POST: PacientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (collection["Nombre"].ToString().Trim() != "")
                {
                    if (int.TryParse((collection["Edad"]), out int edad))
                    {
                        if (collection["Sintomas"].ToString().Trim() != "")
                        {
                            Paciente paciente = new Paciente()
                            {
                                Nombre = collection["Nombre"].ToString(),
                                Edad = edad,
                                IdObrasocial = int.Parse(collection["IdObrasocial"]),
                                Sintomas = collection["Sintomas"].ToString()
                            };
                            data.CrearPaciente(paciente);
                            return RedirectToAction(nameof(Index));
                        }
                        else
                            return View();
                    }
                    else
                        return View();

                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PacientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PacientesController/Delete/5
        public ActionResult Delete(int id)
        {
            data.EliminarPaciente(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: PacientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
