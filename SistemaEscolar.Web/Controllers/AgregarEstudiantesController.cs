using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Escolar.Data.Interfaces;

namespace SistemaEscolar.Web.Controllers
{
    public class AgregarEstudiantesController : Controller
    {
        private readonly IAgregarEstudiantesRepository agregarEstudiantes;

        public AgregarEstudiantesController(IAgregarEstudiantesRepository AgregarEstudiantes)
        {
            agregarEstudiantes = AgregarEstudiantes;
        }
        // GET: AgregarEstudiantesController

        public ActionResult Index()
        {
            var AgregarEstudiantes = this.agregarEstudiantes.TraerTodos();
            return View(AgregarEstudiantes); 
        }

        // GET: AgregarEstudiantesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgregarEstudiantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgregarEstudiantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AgregarEstudiantesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgregarEstudiantesController/Edit/5
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

        // GET: AgregarEstudiantesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgregarEstudiantesController/Delete/5
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
