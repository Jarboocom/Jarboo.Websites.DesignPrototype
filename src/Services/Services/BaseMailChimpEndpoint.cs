using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Domain.MailChimps;
using RestSharp;
using Newtonsoft.Json;
using System.Collections;
using System.Net;
using RestSharp.Serializers;
using JsonSerializer = Services.Domain.MailChimps.JsonSerializer;
using log4net;
using RestSharp.Authenticators;

namespace Services.Services
{
    public abstract class BaseMailChimpEndpoint<T, TK> : IMailChimpEndpoint<T, TK>
        where T : BaseMailChimpResource
        where TK: BaseMailChimpRequest
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (BaseMailChimpEndpoint<T, TK>));

        private readonly string MailChimpEndpoint = "https://us9.api.mailchimp.com/3.0";

        protected string ApiKey { get; set; }

        protected BaseMailChimpEndpoint(string apiKey)
        {
            ApiKey = apiKey;
        }

        public BaseMailChimpResponse<T> Post(TK request)
        {
            var client = GetClient(request);
            var restRequest = PreaparePostRequest(request);
            
            var response = client.Execute(restRequest);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                HandleError(response);
            }

            var data = GetResult<T>(response);

            return data;
        }

        public async Task<BaseMailChimpResponse<T>> PostAsync(TK request)
        {
            var client = GetClient(request);
            var restRequest = PreaparePostRequest(request);

            var response = await client.ExecuteTaskAsync(restRequest).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                HandleError(response);
            }

            var data = GetResult<T>(response);

            return data;
        }

        protected virtual RestRequest PreaparePostRequest(TK request)
        {
            var restRequest = new RestRequest { Method = Method.POST, RequestFormat = DataFormat.Json };
            restRequest.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(request), ParameterType.RequestBody);
            return restRequest;
        }

        #region Helpers
        private RestClient GetClient(TK request)
        {
            var client = new RestClient(string.Join(@"/", MailChimpEndpoint, request.Url));
            client.Authenticator = new HttpBasicAuthenticator("APIKey", ApiKey);
            return client;
        }

        private void HandleError(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception(response.ErrorMessage);
            }
            var error = JsonConvert.DeserializeObject<dynamic>(response.Content);
            throw new Exception(error.Message.ToString());
        }

        private BaseMailChimpResponse<T> GetResult<T>(IRestResponse resp)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.DebugFormat("Resource: {0}, Result: {1}", typeof(T).Name, resp.Content);                
            }
            var data = JsonConvert.DeserializeObject<T>(resp.Content);
            return new StandardResponse<T>
            {
                Result = data,
                Headers = resp.Headers.ToDictionary(k => k.Name, v => v.Value)
            };
        }
        #endregion
    }
}
