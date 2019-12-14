using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyLOB.Environment
{
    /// <summary>
    /// OData Helper.
    /// </summary>
    public class ODataHelper
    {
        /// <summary>
        /// Get exception from operation result.
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        public static HttpResponseException OperationResultResponseException(HttpRequestMessage request, ZOperationResult operationResult)
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                //Formatting = Formatting.Indented
                Formatting = Formatting.None
            };

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(operationResult, jsonSettings)),
                StatusCode = HttpStatusCode.BadRequest
            };

            return new HttpResponseException(response);
        }
    }
}