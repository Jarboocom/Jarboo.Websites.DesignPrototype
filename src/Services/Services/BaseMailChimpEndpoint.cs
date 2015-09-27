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
    public class BaseMailChimpEndpoint<T, TK> : IMailChimpEndpoint<T, TK>
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

        public virtual BaseMailChimpResponse<IList<T>> Get(TK request)
        {
            var client = GetClient(request);
            var r = PrepareGetListRequest(request);

            var response = client.Execute(r);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                HandleError(response);
            }

            var result = GetResult<IList<T>>(response);

            return result;
        }

        public async virtual Task<BaseMailChimpResponse<IList<T>>> GetAsync(TK request)
        {
            var client = GetClient(request);
            var r = PrepareGetListRequest(request);

            var response = await client.ExecuteTaskAsync(r).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                HandleError(response);
            }

            var result = GetResult<IList<T>>(response);

            return result;
        }

        protected virtual RestRequest PrepareGetListRequest(TK request)
        {
            var r = new RestRequest { RequestFormat = DataFormat.Json, JsonSerializer = new JsonSerializer(), Method = Method.GET };

            SerializeObject(r, request);

            return r;
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
            throw new Exception(error.detail.ToString());
        }

        private BaseMailChimpResponse<TP> GetResult<TP>(IRestResponse resp)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.DebugFormat("Resource: {0}, Result: {1}", typeof(T).Name, resp.Content);                
            }
            var data = JsonConvert.DeserializeObject<TP>(resp.Content);
            return new StandardResponse<TP>
            {
                Result = data,
                Headers = resp.Headers.ToDictionary(k => k.Name, v => v.Value)
            };
        }

        private void SerializeObject(RestRequest r, TK request)
        {
            var properties = request.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                //if there is an ignore property, then we ignore the value
                if (propertyInfo.GetCustomAttributes(typeof(JsonIgnoreAttribute), false).Any())
                {
                    continue;
                }

                var value = propertyInfo.GetValue(request, null);
                var attribute = propertyInfo.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>().FirstOrDefault();

                if (value != null && attribute != null)
                {
                    string name;
                    //setting name
                    if (attribute != null && !string.IsNullOrEmpty(attribute.PropertyName))
                    {
                        //if there is an attribute and it has a name, then we set it
                        name = attribute.PropertyName;
                    }
                    else
                    {
                        //otherwise we set proeprty name lowered
                        name = propertyInfo.Name.ToLowerInvariant();
                    }

                    if (propertyInfo.PropertyType.IsGenericType
                        && typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                    {
                        IEnumerable list = value as IEnumerable;
                        if (list != null)
                        {
                            foreach (var item in list)
                            {
                                r.AddParameter(name, item);
                            }
                        }
                    }
                    else
                    {
                        r.AddParameter(name, value);
                    }
                }
            }
        }
        #endregion
    }
}
