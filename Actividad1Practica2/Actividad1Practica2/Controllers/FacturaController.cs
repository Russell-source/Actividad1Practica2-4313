using Microsoft.AspNetCore.Mvc;

namespace CalculadoraMVC.Controllers
{
    public class FacturaController : Controller
    {
        [HttpGet]
        public IActionResult Procesar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Procesar(string monto, string tipo)
        {
            double subtotal = 0;
            double aplicado = 0;
            double total = 0;

            bool valido = double.TryParse(monto, out subtotal);

            if (valido)
            {
                if (tipo == "ITBIS")
                {
                    aplicado = subtotal * 0.18;
                    total = subtotal + aplicado;
                }
                else if (tipo == "Descuento")
                {
                    aplicado = subtotal * 0.15;
                    total = subtotal - aplicado;
                }

                ViewBag.Subtotal = subtotal;
                ViewBag.Tipo = tipo;
                ViewBag.Aplicado = aplicado;
                ViewBag.Total = total;
            }
            else
            {
                ViewBag.Error = "Ingresa un monto válido en números.";
            }

            return View();
        }
    }
}
