using Microsoft.AspNetCore.Mvc;
using System;

namespace TuProyecto.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Datos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Datos(string nombre, DateTime fechaNacimiento)
        {
            int edad = CalcularEdad(fechaNacimiento);
            int añoNacimiento = fechaNacimiento.Year;

            ViewBag.Mensaje = $"Hola, {nombre}. Tienes {edad} años y tu año de nacimiento es {añoNacimiento}.";
            return View();
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }
    }
}
