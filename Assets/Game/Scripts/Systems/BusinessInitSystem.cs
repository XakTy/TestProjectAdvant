using Game.Scripts.Components;
using Game.Scripts.Other.Dates;
using Game.Scripts.Other.Player;
using Game.Scripts.Other.States;
using Game.Scripts.SO.BussinesSO;
using Leopotam.Ecs;

namespace Game
{
	public sealed class BusinessInitSystem : IEcsRunSystem
	{
		private readonly EcsFilter<BusinessViewRef, BusinessDataRef, BusinessStateRef, InitEvent> _filterInit = default;

		private readonly PlayerData _playerData = default;

		private readonly StaticData _staticData = default;

		public void Run()
		{
			if (_filterInit.IsEmpty()) return;

			foreach (var i in _filterInit)
			{
				var businessViewRef = _filterInit.Get1(i);
				var businessData = _filterInit.Get2(i).value;
				var state = _filterInit.Get3(i).value;

				InitText(businessViewRef, businessData, state);

				var entity = _filterInit.GetEntity(i);

				if (state.IsBuy)
				{
					entity.Get<Level>().value = state.Level;
					entity.Get<ProgressValue>().value = state.Progress;
				}

				businessViewRef.LevelUpButton.onClick.AddListener(() => Buy(entity, businessData));

				entity.Get<MaxProgressValue>().value = businessData.TimeIncome;
				entity.Get<Multiply>().value = _staticData.MultiplyForAllBusiness;
				entity.Get<UpdateEvent>();
				entity.Del<InitEvent>();
			}
		}

		private static void InitText(BusinessViewRef businessViewRef, BusinessData businessData, BusinessState state)
		{
			businessViewRef.NameText.text = businessData.Name;
			businessViewRef.LevelText.text = state.Level.ToString();
			businessViewRef.IncomeText.text = (state.Level * businessData.BasicPrice).ToString();
			businessViewRef.PriceText.text = ((state.Level + 1) * businessData.BasicPrice).ToString();
		}

		public void Buy(EcsEntity entity, BusinessData data)
		{
			var level = entity.Get<Level>().value + 1;
			var price = data.BasicPrice;
			if (_playerData.Cash >= level * price)
			{
				_playerData.Cash -= level * price;

				var state = entity.Get<BusinessStateRef>().value;

				if (!state.IsBuy)
				{
					state.IsBuy = true;
					entity.Get<ProgressValue>();
				}

				state.Level = level;

				entity.Get<Level>().value = state.Level;
				entity.Get<UpdateEvent>();
			}
		}

	}
}