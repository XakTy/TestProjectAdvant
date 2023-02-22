using Game.Scripts.Components;
using Game.Scripts.Other.Dates;
using Leopotam.Ecs;

namespace Game
{
	public sealed class ProgressValueSystem : IEcsRunSystem
	{
		private readonly EcsFilter<ProgressValue, MaxProgressValue> _filterProgress = default ;
		private readonly RuntimeData _runtimeData = default;

		public void Run()
		{
			foreach (var i in _filterProgress)
			{
				ref var progress = ref _filterProgress.Get1(i).value;
				var max = _filterProgress.Get2(i).value;

				progress += _runtimeData.deltaTime;

				if (progress >= max)
				{
					var entity = _filterProgress.GetEntity(i);
					entity.Get<IncomeEvent>();
					progress = 0f;
				}
			}
		}
	}
}