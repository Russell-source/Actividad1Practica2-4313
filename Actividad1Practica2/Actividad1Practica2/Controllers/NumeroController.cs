using Microsoft.AspNetCore.Mvc;

namespace CalculadoraMVC.Controllers
{
    public class NumeroController : Controller
    {
        [HttpGet]
        public IActionResult Verificar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verificar(string numero)
        {
            int n;
            bool esValido = int.TryParse(numero, out n);
            bool esFibonacci = esValido && EsFibonacci(n);

            ViewBag.Numero = numero;
            ViewBag.EsValido = esValido;
            ViewBag.EsFibonacci = esFibonacci;

            return View();
        }

        private bool EsFibonacci(int n)
        {
            int x1 = 5 * n * n + 4;
            int x2 = 5 * n * n - 4;
            return EsCuadradoPerfecto(x1) || EsCuadradoPerfecto(x2);
        }

        private bool EsCuadradoPerfecto(int x)
        {
            int raiz = (int)Math.Sqrt(x);
            return raiz * raiz == x;
        }
    }
}
