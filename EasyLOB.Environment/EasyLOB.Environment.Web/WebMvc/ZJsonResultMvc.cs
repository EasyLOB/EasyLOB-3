using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

// https://github.com/kemmis/Newtonsoft.JsonResult

/*

// Circular Reference
//var result = Json(new { result = data, count = count }, JsonRequestBehavior.AllowGet);

JsonSerializerSettings jsonSettings = new JsonSerializerSettings
{
    //Formatting = Formatting.Indented,
    Formatting = Formatting.None,
    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
};

//var result = Content(JsonConvert.SerializeObject(new { result = data, count = count }, settings));
//var result = Json(JsonConvert.SerializeObject(new { result = data, count = count }, settings));
//var result = NewtonsoftJsonResult(JsonConvert.SerializeObject(new { result = data, count = count }, settings), JsonRequestBehavior.AllowGet);
var result = Json(JsonConvert.SerializeObject(new { result = data, count = count }, settings), null, null, JsonRequestBehavior.AllowGet);

// Controller
protected override JsonResult Json(object data, string contentType,
    System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
{
    return new ZJsonResultMvc
    {
        Data = data,
        ContentType = contentType,
        ContentEncoding = contentEncoding,
        JsonRequestBehavior = behavior
    };
}

*/

namespace EasyLOB.Environment
{
    public class ZJsonResultMvc : System.Web.Mvc.JsonResult
    {
        #region Methods

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("ExecuteResult(ControllerContext context)");
            }

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            response.Write(JsonConvert.SerializeObject(Data, Formatting.Indented));
        }

        #endregion Methods
    }
}