using Cintruct.MvcUi.ApiServices.Interfaces;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace Cintruct.MvcUi.ApiServices.Implementations
{
	/// <summary>
	/// Provides implementation for performing HTTP operations with a specified API service.
	/// </summary>
	public class HttpApiService : IHttpApiService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpApiService"/> class.
		/// </summary>
		/// <param name="configuration">The configuration object for accessing service URLs.</param>
		/// <param name="httpClientFactory">The factory used to create <see cref="HttpClient"/> instances.</param>
		public HttpApiService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

		/// <summary>
		/// Sends a DELETE request to the specified endpoint.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the DELETE request.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data of type <typeparamref name="T"/>.</returns>
		public async Task<T> DeleteDataAsync<T>(string service, string endPoint, string? token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_configuration[$"ServiceUrl:{service}"]}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } }
            };
            if (!string.IsNullOrEmpty(token))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }

		/// <summary>
		/// Sends a GET request to the specified endpoint.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the GET request.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data of type <typeparamref name="T"/>.</returns>
		public async Task<T> GetDataAsync<T>(string service, string endPoint, string? token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_configuration[$"ServiceUrl:{service}"]}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } }
            };
            if (!string.IsNullOrEmpty(token))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }

		/// <summary>
		/// Sends a POST request to the specified endpoint with optional JSON data.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the POST request.</param>
		/// <param name="jsonData">Optional. The JSON data to include in the request body.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data of type <typeparamref name="T"/>.</returns>
		public async Task<T> PostDataAsync<T>(string service, string endPoint, string? jsonData = null, string? token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_configuration[$"ServiceUrl:{service}"]}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } },
            };
            if (!string.IsNullOrEmpty(jsonData))
            {
                requestMessage.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }
            if (!string.IsNullOrEmpty(token))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }

		/// <summary>
		/// Sends a PUT request to the specified endpoint with JSON data.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the PUT request.</param>
		/// <param name="jsonData">The JSON data to include in the request body.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data of type <typeparamref name="T"/>.</returns>
		public async Task<T> PutDataAsync<T>(string service, string endPoint, string jsonData, string? token = null)
        {
            var client = _httpClientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_configuration[$"ServiceUrl:{service}"]}{endPoint}"),
                Headers = { { HeaderNames.Accept, "application/json" } },
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };
            if (!string.IsNullOrEmpty(token))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var responseMessage = await client.SendAsync(requestMessage);
            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }
    }
}
