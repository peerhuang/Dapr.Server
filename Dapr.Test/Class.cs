using Dapr.Client;

namespace Dapr
{
    public abstract class DaprClientService
    {
        private readonly DaprClient _daprClient;

        protected DaprClientService()
        {
            _daprClient = new DaprClientBuilder().Build();
        }

        private HttpRequestMessage CreateInvokeMethodRequest(HttpMethod httpMethod, string appId, string methodName, Dictionary<string, object> getMethodQueryStringParams)
        {
            var request = _daprClient.CreateInvokeMethodRequest(httpMethod, appId, methodName, getMethodQueryStringParams);
            //if (_currentTenant.Id != null)
            //{
            //    request.Headers.Add("tenantId", _currentTenant.Id.ToString());
            //}
            //request.Headers.Add("header-sign", HeaderSign.HeaderSign.GenerateSign());
            return request;
        }

        private HttpRequestMessage CreateInvokeMethodRequest<TRequest>(HttpMethod httpMethod, string appId, string methodName, TRequest data)
        {
            var request = _daprClient.CreateInvokeMethodRequest(httpMethod, appId, methodName, data);
            //if (_currentTenant.Id != null)
            //{
            //    request.Headers.Add("tenantId", _currentTenant.Id.ToString());
            //}
            //request.Headers.Add("header-sign", HeaderSign.HeaderSign.GenerateSign());
            return request;
        }

        protected Task InvokeMethodAsync<TRequest>(HttpMethod httpMethod, string appId, string methodName, TRequest data)
        {
            var request = this.CreateInvokeMethodRequest(httpMethod, appId, methodName, data);
            return _daprClient.InvokeMethodAsync(request);
        }

        protected Task<TResponse> InvokeMethodAsync<TRequest, TResponse>(HttpMethod httpMethod, string appId, string methodName, TRequest data)
        {
            var request = this.CreateInvokeMethodRequest(httpMethod, appId, methodName, data);
            return _daprClient.InvokeMethodAsync<TResponse>(request);
        }

        protected Task<TResponse> InvokeGetAsync<TResponse>(string appId, string methodName, Dictionary<string, object> getMethodQueryStringParams = null)
        {
            var request = this.CreateInvokeMethodRequest(HttpMethod.Get, appId, methodName, getMethodQueryStringParams);
            return _daprClient.InvokeMethodAsync<TResponse>(request);
        }
    }
}