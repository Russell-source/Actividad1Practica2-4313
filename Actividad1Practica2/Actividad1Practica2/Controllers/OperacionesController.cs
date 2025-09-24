using Microsoft.AspNetCore.Mvc;

namespace CalculadoraMVC.Controllers
{
    public class OperacionesController : Controller
    {
        [HttpGet]
        public IActionResult Calcular()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(string valor1, string valor2, string operador)
        {
            double resultado = 0;
            double v1 = 0;
            double v2 = 0;

            bool valido1 = double.TryParse(valor1, out v1);
            bool valido2 = double.TryParse(valor2, out v2);

            if (valido1 && valido2)
            {
                switch (operador)
                {
                    case "Sumar": resultado = v1 + v2; break;
                    case "Restar": resultado = v1 - v2; break;
                    case "Multiplicar": resultado = v1 * v2; break;
                    case "Dividir": resultado = v2 != 0 ? v1 / v2 : double.NaN; break;
                    case "Potencia": resultado = Math.Pow(v1, v2); break;
                }

                ViewBag.Resultado = resultado;
            }
            else
            {
                ViewBag.Error = "Ingresa valores numéricos válidos.";
            }

            return View();
        }
    }
}
