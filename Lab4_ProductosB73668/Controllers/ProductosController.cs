using Lab4_ProductosB73668.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_ProductosB73668.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            List<Producto> productos = ProductoRepositorio.ObtenerTodos();
            return View(productos);
        }

        public IActionResult Detalles(int id)
        {
            Producto? producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return RedirectToAction("Index");

            return View(producto);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);

            ProductoRepositorio.Agregar(producto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Producto? producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return RedirectToAction("Index");

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (!ModelState.IsValid) return View(producto);

            ProductoRepositorio.Actualizar(producto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Producto? producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return RedirectToAction("Index");

            return View(producto);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            ProductoRepositorio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}