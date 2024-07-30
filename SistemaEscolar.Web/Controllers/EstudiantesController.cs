using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Interfaces;

namespace SistemaEscolar.Web.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly IAgregarEstudiantesRepository agregarEstudiantesRepository;

        public EstudiantesController(IAgregarEstudiantesRepository agregarEstudiantesRepository)
        {
            this.agregarEstudiantesRepository = agregarEstudiantesRepository;
        }


        // GET: EstudiantesController
        public ActionResult Index()
        {
            var estudiantes = this.agregarEstudiantesRepository.TraerTodos();
            return View(estudiantes);
        }

        // GET: EstudiantesController/Details/5
        public ActionResult Details(int id)
        {
            var estudiantes = this.agregarEstudiantesRepository.ObtenerPorId(id);
            return View(estudiantes);
        }

        // GET: EstudiantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudiantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiantes estudiantes)
        {
            try
            {
                this.agregarEstudiantesRepository.Agregar(estudiantes);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstudiantesController/Edit/5
        public ActionResult Edit(int id)
        {
            var estudiantes = this.agregarEstudiantesRepository.ObtenerPorId(id);
            return View(estudiantes);
        }

        // POST: EstudiantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estudiantes estudiantes)
        {
            try
            {
                this.agregarEstudiantesRepository.Actualizar(estudiantes);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
