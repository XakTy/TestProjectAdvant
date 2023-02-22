using Game.Scripts.Components;
using Leopotam.Ecs;

namespace Game
{
	public sealed class BusinessProgressViewSystem : IEcsRunSystem
	{
		private readonly EcsFilter<BusinessViewRef, ProgressValue, MaxProgressValue> _filterProgressView = default;
		public void Run()
		{
			foreach (var i in _filterProgressView)
			{
				var progressImage = _filterProgressView.Get1(i).ProgressImage;
				var progress = _filterProgressView.Get2(i).value;
				var max = _filterProgressView.Get3(i).value;

				progressImage.fillAmount = progress / max;
			}
		}
	}
}