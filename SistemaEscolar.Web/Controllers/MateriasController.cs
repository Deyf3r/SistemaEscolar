using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Interfaces;

namespace SistemaEscolar.Web.Controllers
{
    public class MateriasController : Controller
    {
        private readonly IMateriasRepository materiasRepository;

        public MateriasController(IMateriasRepository materiasRepository)
        {
            this.materiasRepository = materiasRepository;
        }


        // GET: MateriasController


        public ActionResult Index()
        {
            var materias = this.materiasRepository.TraerTodos();
            return View(materias);
        }

        // GET: MateriasController/Details/5
        public ActionResult Details(int id)
        {
            var materias = this.materiasRepository.ObtenerPorId(id);
            return View(materias);
        }

        // GET: MateriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Materias materias)
        {
            try
            {
                this.materiasRepository.Agregar(materias);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MateriasController/Edit/5
        public ActionResult Edit(int id)
        {
            var materias = this.materiasRepository.ObtenerPorId(id);
            return View(materias);
        }

        // POST: MateriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Materias materias)
        {
            try
            {
                this.materiasRepository.Actualizar(materias);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
