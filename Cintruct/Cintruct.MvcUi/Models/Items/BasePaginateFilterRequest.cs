namespace Cintruct.MvcUi.Models.Items
{
	public abstract class BasePaginateFilterRequest : BaseFilterRequest
	{
		public int Index { get; set; } = 0;
		public int Size { get; set; } = 10;
	}
}
