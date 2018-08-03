using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidade;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar()
        {
            var produto = new Produto();

            return RedirectToAction("Index");
        }
    }
}