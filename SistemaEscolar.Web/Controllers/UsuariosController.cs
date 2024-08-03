using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Repositories.Db;

namespace SistemaEscolar.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;

        }
            // GET: UsuariosController
            public ActionResult Index()
            {
                var usuarios = this.usuarioRepository.TraerTodos();
                return View(usuarios);
            }

            // GET: UsuariosController/Details/5
            public ActionResult Details(int id)
            {
                var usuario = this.usuarioRepository.ObtenerPorId(id);
                return View(usuario);
            }

            // GET: UsuariosController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: UsuariosController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Usuarios usuario)
            {
                try
                {
                    this.usuarioRepository.Agregar(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: UsuariosController/Edit/5
            public ActionResult Edit(int id)
            {
                var usuario = this.usuarioRepository.ObtenerPorId(id);
                return View(usuario);
            }

            // POST: UsuariosController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, Usuarios usuario)
            {
                try
                {
                    this.usuarioRepository.Actualizar(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: UsuariosController/Delete/5
            public ActionResult Delete(int id)
            {
                var usuario = this.usuarioRepository.ObtenerPorId(id);
                return View(usuario);
            }

            // POST: UsuariosController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, Usuarios usuario)
            {
                try
                {
                    this.usuarioRepository.Remover(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }
    }
