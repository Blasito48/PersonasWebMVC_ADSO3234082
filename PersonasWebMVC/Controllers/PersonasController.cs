using Microsoft.AspNetCore.Mvc;
using PersonasWebMVC.Models;

namespace PersonasWebMVC.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarPersona(PersonasModel Modelo)
        {
            long id = Modelo.id;
            string name = Modelo.Nombre;
            string tel = Modelo.Telefono;
            if (Models.ClaseFunciiones.Func_Insertar(name, tel))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
    }
}
