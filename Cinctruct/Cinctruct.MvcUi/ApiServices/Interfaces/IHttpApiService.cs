namespace Cintruct.MvcUi.ApiServices.Interfaces
{
	/// <summary>
	/// Provides methods for performing HTTP operations with a specified API service.
	/// </summary>
	public interface IHttpApiService
    {
		/// <summary>
		/// Sends a DELETE request to the specified endpoint.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the DELETE request.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data.</returns>
		Task<T> DeleteDataAsync<T>(string service, string endPoint, string? token = null);

		/// <summary>
		/// Sends a GET request to the specified endpoint.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the GET request.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data.</returns>
		Task<T> GetDataAsync<T>(string service, string endPoint, string? token = null);

		/// <summary>
		/// Sends a POST request to the specified endpoint.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the POST request.</param>
		/// <param name="jsonData">Optional. The JSON data to include in the request body.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data.</returns>
		Task<T> PostDataAsync<T>(string service, string endPoint, string? jsonData = null, string? token = null);

		/// <summary>
		/// Sends a PUT request to the specified endpoint.
		/// </summary>
		/// <typeparam name="T">The type of the response data.</typeparam>
		/// <param name="service">The name of the API service.</param>
		/// <param name="endPoint">The endpoint for the PUT request.</param>
		/// <param name="jsonData">The JSON data to include in the request body.</param>
		/// <param name="token">Optional. The authentication token for the request.</param>
		/// <returns>A task that represents the asynchronous operation. The task result contains the response data.</returns>
		Task<T> PutDataAsync<T>(string service, string endPoint, string jsonData, string? token = null);
    }
}
