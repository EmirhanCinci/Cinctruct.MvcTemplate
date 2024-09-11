namespace Cintruct.MvcUi.Models
{
	public class ResponseBody<T>
	{
		public int StatusCode { get; set; }
		public bool IsSuccessful { get; set; }
		public string StatusMessage { get; set; } = string.Empty;
		public T? Data { get; set; }
		public List<string> ErrorMessages { get; set; } = new List<string>();
	}
}
