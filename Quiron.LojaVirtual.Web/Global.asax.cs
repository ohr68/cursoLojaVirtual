using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Web.App_Start;
using Quiron.LojaVirtual.Web.Infraestrutura;

namespace Quiron.LojaVirtual.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Carrinho), new CarrinhoModelBinder());
        }
    }
}
