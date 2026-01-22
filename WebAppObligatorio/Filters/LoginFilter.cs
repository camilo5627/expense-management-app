using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppObligatorio.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? id = context.HttpContext.Session.GetInt32("Id");
            if (id == null)
            {
                context.Result = new RedirectToActionResult("Login", "Usuario", new { error = "Debe iniciar sesion" });
            }
            base.OnActionExecuting(context);
        }
    }
}
