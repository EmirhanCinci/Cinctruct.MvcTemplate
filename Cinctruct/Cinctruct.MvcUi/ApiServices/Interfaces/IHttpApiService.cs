namespace Cintruct.MvcUi.ApiServices.Interfaces
{
    public interface IHttpApiService
    {
        Task<T> DeleteDataAsync<T>(string service, string endPoint, string? token = null);
        Task<T> GetDataAsync<T>(string service, string endPoint, string? token = null);
        Task<T> PostDataAsync<T>(string service, string endPoint, string? jsonData = null, string? token = null);
        Task<T> PutDataAsync<T>(string service, string endPoint, string jsonData, string? token = null);
    }
}
