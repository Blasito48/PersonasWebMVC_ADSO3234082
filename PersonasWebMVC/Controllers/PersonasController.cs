using Microsoft.AspNetCore.Mvc;
using PersonasWebMVC.Models;

namespace PersonasWebMVC.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Index()
        {
            List<PersonasModel> lista = new List<PersonasModel>();
            lista = Models.ClaseFunciiones.Func_TraerDatos();
            return View(lista);
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
        [HttpPost]
        public IActionResult EditPersona(PersonasModel Modelo)
        {
            long id = Modelo.id;
            string name = Modelo.Nombre;
            string tel = Modelo.Telefono;
            if (Models.ClaseFunciiones.Func_Editar(id,name, tel))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult EliminarPersona(long id)
        {
            //llamar
            TempData["Mensaje"] = "Persona Elininada";
            TempData["ID"] = id.ToString();
            RedirectToAction("Index");
            if (Models.ClaseFunciiones.Func_Eliminar(id))
            {
                //llamar seetalrt
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult EditarPersona(PersonasModel Modelo)
        {
            long id = Modelo.id;
            PersonasModel model = new PersonasModel();
            model = ClaseFunciiones.Func_Traer1Persona(id);
            return View(model);
        }
    }
}
