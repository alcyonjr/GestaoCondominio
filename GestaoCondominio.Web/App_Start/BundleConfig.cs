using System.Web;
using System.Web.Optimization;

namespace GestaoCondominio.Web
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/assets/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/js/jquery-3.1.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/assets/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/assets/js/angular.min.js",
            "~/assets/js/angular-resource.min.js",
            "~/assets/js/angular-route.min.js",
            "~/assets/js/ui-bootstrap-tpls-2.5.0.min.js",
            "~/assets/js/ngToast.js",
            "~/assets/js/angular-sanitize.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/assets/app/main.js",
                "~/assets/app/routes.js",
                "~/assets/app/propriedades.js",
                "~/assets/app/interceptor/login.interceptor.js",
                "~/assets/app/interceptor/exception.interceptor.js",
                "~/assets/app/services/apartamento.service.js",
                "~/assets/app/services/morador.service.js",
                "~/assets/app/services/usuario.service.js",
                "~/assets/app/controllers/apartamento.controller.js",                
                "~/assets/app/controllers/morador.controller.js",
                "~/assets/app/controllers/login.controller.js",
                "~/assets/app/controllers/usuario.controller.js"                
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/assets/css/bootstrap.css",
                "~/assets/css/light-bootstrap-dashboard.css",
                "~/assets/css/site.css",
                "~/assets/css/ngToast.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/assets/css/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform()));
        }
    }
}
