using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Interfaces;

namespace SistemaEscolar.Web.Controllers
{
    public class ProfesoresController : Controller
    {

        private readonly IProfesoresRepository profesoresRepository;

        public ProfesoresController(IProfesoresRepository profesoresRepository)
        {
            this.profesoresRepository = profesoresRepository;
        }

        // GET: ProfesoresController
        public ActionResult Index()
        {
            var profesores = this.profesoresRepository.TraerTodos();
            return View(profesores);
        }

        // GET: ProfesoresController/Details/5
        public ActionResult Details(int id)
        {
            var profesores = this.profesoresRepository.ObtenerPorId(id);

            return View(profesores);
        }

        // GET: ProfesoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesores profesores)
        {
            try
            {
                this.profesoresRepository.Agregar(profesores);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfesoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var profesores = this.profesoresRepository.ObtenerPorId(id);
            return View(profesores);
        }

        // POST: ProfesoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Profesores profesores)
        {
            try
            {
                this.profesoresRepository.Actualizar(profesores);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfesoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfesoresController/Delete/5
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
