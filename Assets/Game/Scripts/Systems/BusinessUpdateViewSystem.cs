using Game.Scripts.Components;
using Leopotam.Ecs;

namespace Game
{
	public sealed class BusinessUpdateViewSystem : IEcsRunSystem
	{
		private readonly EcsFilter<BusinessViewRef, Level, BusinessDataRef, Multiply, UpdateEvent> _filterUpdateView = default;
		public void Run()
		{
			if (_filterUpdateView.IsEmpty()) return;

			foreach (var i in _filterUpdateView)
			{
				var businessViewRef = _filterUpdateView.Get1(i);
				var level = _filterUpdateView.Get2(i).value;
				var data = _filterUpdateView.Get3(i).value;
				var multiply = _filterUpdateView.Get4(i).value;

				businessViewRef.LevelText.text = level.ToString();
				businessViewRef.IncomeText.text = (level * data.BasicPrice * multiply).ToString();
				businessViewRef.PriceText.text = ((level + 1) * data.BasicPrice).ToString();
			}
		}
	}
}