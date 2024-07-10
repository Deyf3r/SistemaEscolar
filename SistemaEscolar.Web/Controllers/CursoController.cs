using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Interfaces;

namespace SistemaEscolar.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly CursoRepository cursoRepository;

        public CursoController(CursoRepository cursoRepository)
        {
            this.cursoRepository = cursoRepository;
        }
        // GET: CursoController
        public ActionResult Index()
        {
            var cursos = this.cursoRepository.TraerTodos();
            return View(cursos);
        }

        // GET: CursoController/Details/5
        public ActionResult Details(int id)
        {   
            var cursos = cursoRepository.ObtenerPorId(id);
            return View(cursos);
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cursos curso)
        {
            try
            {
                this.cursoRepository.Agregar(curso);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursoController/Edit/5
        public ActionResult Edit(int id)
        {
            var cursos = cursoRepository.ObtenerPorId(id);
            return View(cursos);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cursos curso)
        {
            
            try
            {
                this.cursoRepository.Actualizar(curso);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CursoController/Delete/5
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
