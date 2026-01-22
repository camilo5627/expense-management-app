using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppObligatorio.Filters
{
    public class GerenteFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string rol = context.HttpContext.Session.GetString("Rol");
            if (rol != "Gerente")
            {
                context.Result = new RedirectToActionResult("Index", "Pagos", new { error = "Permisos no concedidos" });
            }
            base.OnActionExecuting(context);
        }
    }
}
