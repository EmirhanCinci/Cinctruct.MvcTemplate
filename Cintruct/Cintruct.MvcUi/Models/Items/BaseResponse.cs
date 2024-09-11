namespace Cintruct.MvcUi.Models.Items
{
	public abstract class BaseResponse<TEntityId>
	{
		public TEntityId Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public bool IsDeleted { get; set; }
	}
}
