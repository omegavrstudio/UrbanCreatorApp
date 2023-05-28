using QuestCity.Core.Interfaces;

namespace QuestCity.GameCore.Interfaces
{
	public interface IDistrictsService : IService
	{
		public void OnSelected(BaseDistrict district);
		public void OnDeselected(BaseDistrict district);

		public void ÑolorizeDestrict(BaseDistrict district);
	}
}
