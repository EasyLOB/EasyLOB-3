using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

// ActionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ActionContext.ModelState);

namespace EasyLOB.Environment
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        #region Methods

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }

        #endregion Methods
    }
}