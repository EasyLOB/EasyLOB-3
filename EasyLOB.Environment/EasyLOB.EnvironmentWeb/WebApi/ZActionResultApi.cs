using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace EasyLOB.Environment
{
    public class ZActionResultApi : IHttpActionResult
    {
        #region Properties

        private readonly HttpRequestMessage _request;

        private readonly ZOperationResult _operationResult;

        #endregion Properties

        #region Methods

        public ZActionResultApi(HttpRequestMessage request, ZOperationResult operationResult)
        {
            _request = request;
            _operationResult = operationResult;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpStatusCode httpStatusCode = _operationResult.Ok ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            var response = _request.CreateResponse<ZOperationResult>(httpStatusCode, _operationResult);

            return Task.FromResult(response);
        }

        #endregion Methods
    }
}