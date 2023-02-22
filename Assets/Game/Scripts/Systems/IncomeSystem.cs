using Game.Scripts.Components;
using Game.Scripts.Other.Player;
using Leopotam.Ecs;

namespace Game
{
	public sealed class IncomeSystem : IEcsRunSystem
	{
		private readonly EcsFilter<Level,BusinessDataRef, Multiply, IncomeEvent> _filterIncomeEvent = default;
		private readonly PlayerData _playerData = default;
		private readonly UI _ui = default;
		public void Run()
		{
			foreach (var i in _filterIncomeEvent)
			{
				var level = _filterIncomeEvent.Get1(i).value;
				var data = _filterIncomeEvent.Get2(i).value;
				var multiply = _filterIncomeEvent.Get3(i).value;

				_playerData.Cash += level * data.BasicPrice * multiply;
				_ui.GameScreen.MoneyText.text = $"{_playerData.Cash}";
			}
		}
	}
}