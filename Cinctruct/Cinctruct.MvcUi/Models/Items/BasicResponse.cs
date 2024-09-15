namespace Cintruct.MvcUi.Models.Items
{
	public abstract class BasicResponse<TEntityId> : BaseResponse<TEntityId>
	{
		public string Name { get; set; } = string.Empty;
	}
}
