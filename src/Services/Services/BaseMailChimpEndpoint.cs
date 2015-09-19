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

namespace Services.Services
{
    public abstract class BaseMailChimpEndpoint<T, TK> : IMailChimpEndpoint<T, TK>
        where T : BaseMailChimpResource
        where TK: BaseMailChimpRequest
    {
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
            var restRequest = new RestRequest { Method = Method.POST };

            SerializeObject(restRequest, request);

            return restRequest;
        }

        #region Helpers
        private RestClient GetClient(TK request)
        {
            var client = new RestClient(string.Join(@"/", MailChimpEndpoint, request.Url));

            client.AddDefaultHeader("Authorization", string.Format("apikey {0}", ApiKey));

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

        private void SerializeObject(RestRequest request, TK resource)
        {
            var properties = resource.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                //if there is an ignore property, then we ignore the value
                if (propertyInfo.GetCustomAttributes(typeof(JsonIgnoreAttribute), false).Any())
                {
                    continue;
                }

                var value = propertyInfo.GetValue(resource, null);
                var attribute = propertyInfo.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>().FirstOrDefault();

                if (attribute != null)
                {
                    if (attribute.Required == Required.Always && value == null)
                    {
                        throw new Exception(propertyInfo.Name);
                    }
                }

                if (value != null)
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
                                request.AddParameter(name, item);
                            }
                        }
                    }
                    else
                    {
                        request.AddParameter(name, value);
                    }
                }
            }
        }

        private BaseMailChimpResponse<T> GetResult<T>(IRestResponse resp)
        {
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
