using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Web.Mvc;
using System.Web.Security;
using Quiron.LojaVirtual.Dominio.Entidade;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio;

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            _repositorio = new AdministradoresRepositorio();

            if (ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdministrador(administrador);

                if (admin != null)
                {
                    if (!(Equals(administrador.Senha, admin.Senha)))
                    {
                        ModelState.AddModelError("", "Senha não confere");

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") &&
                            !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            return Redirect(returnUrl);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") &&
                            !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                            return Redirect(returnUrl);

                    }
                }
                else
                {
                    //Administrador não localizado
                    ModelState.AddModelError("", "Administrador não localizado");
                }
            }

            return View(new Administrador());
        }
    }
}