using MovieExplorer.Core.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Services
{
    public class BaseProvider
    {
        // The Http Client
        private HttpClient _httpClient;

        // Base URL of the project.
        public const string BaseURL = "http://api.themoviedb.org/3/movie/";

        private const string StreamContentTypeHeader = "application/octet-stream";
        private const string JsonContentTypeHeader = "application/json";

        // Json Settings.
        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings()
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public BaseProvider()
        {
            _httpClient = new HttpClient();
        }

        protected async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod httpMethod, string requestUrl, TRequest requestBody)
        {
            var request = new HttpRequestMessage(httpMethod, BaseURL);
            request.RequestUri = new Uri(requestUrl);
            if (requestBody != null)
            {
                if(requestBody is Stream)
                {
                    request.Content = new StreamContent(requestBody as Stream);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(StreamContentTypeHeader);
                }
                else
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(requestBody, jsonSettings), Encoding.UTF8, JsonContentTypeHeader);
                }
            }

            // If response is successful and not null read data.
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                string responseContent = null;

                if (response.Content != null)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                }

                if(!string.IsNullOrWhiteSpace(responseContent))
                {
                    return JsonConvert.DeserializeObject<TResponse>(responseContent, jsonSettings);
                }
                return default(TResponse);
            }
            else
            {
                if (response.Content != null && response.Content.Headers.ContentType.MediaType.Contains(JsonContentTypeHeader))
                {
                    var errorObjectString = await response.Content.ReadAsStringAsync();
                    ExceptionHandlingError ex = JsonConvert.DeserializeObject<ExceptionHandlingError>(errorObjectString);

                    if (ex.Message != null)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    else
                    {
                        ExceptionHandling serviceEx = JsonConvert.DeserializeObject<ExceptionHandling>(errorObjectString);
                        if (ex != null)
                        {
                            Debug.WriteLine(serviceEx.Source, serviceEx.Message, response.StatusCode);
                        }
                        else
                        {
                            Debug.WriteLine("Unknown", "Unknown Error", response.StatusCode);
                        }
                    }
                }
                response.EnsureSuccessStatusCode();
            }
            return default(TResponse);
        }
    }
}
