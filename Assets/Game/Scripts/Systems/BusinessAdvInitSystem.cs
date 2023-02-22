using Game.Scripts.Components;
using Game.Scripts.Other.Dates;
using Game.Scripts.Other.Player;
using Game.Scripts.Other.States;
using Game.Scripts.SO.BussinesSO;
using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	public sealed class BusinessAdvInitSystem : IEcsRunSystem
	{
		private readonly EcsFilter<BusinessViewAdvRef, BusinessStateAdvRef, BusinessAdvDataRef, Parent, InitEvent> _filterBusinessAdv = default;

		private readonly PlayerData _playerData = default;

		private const float DIV_VALUE = 100f;

		public BusinessAdvInitSystem(PlayerData playerData)
		{
			_playerData = playerData;
		}
		public void Run()
		{
			if (_filterBusinessAdv.IsEmpty()) return;

			foreach (var i in _filterBusinessAdv)
			{
				var businessViewRef = _filterBusinessAdv.Get1(i);
				var state = _filterBusinessAdv.Get2(i).value;
				var data = _filterBusinessAdv.Get3(i).value;
				var parentEntity = _filterBusinessAdv.Get4(i).value;

				var entity = _filterBusinessAdv.GetEntity(i);

				if (state.IsBuy)
				{
					BuyMultiply(businessViewRef, parentEntity, data);
					entity.Destroy();
					continue;
				}

				businessViewRef.ButtonBuy.onClick.AddListener(() => Buy(businessViewRef, state, data, parentEntity));
				entity.Del<InitEvent>();
			}
		}

		public void Buy(BusinessViewAdvRef view, BusinessAdvState state, BusinessAdvData data, EcsEntity parentEntity)
		{
			if (_playerData.Cash >= data.BasicPrice)
			{
				_playerData.Cash -= data.BasicPrice;

				state.IsBuy = true;
				BuyMultiply(view, parentEntity, data);
			}
		}

		private static void BuyMultiply(BusinessViewAdvRef businessViewRef, EcsEntity parentEntity, BusinessAdvData data)
		{
			DisableButton(businessViewRef);
			parentEntity.Get<Multiply>().value += data.Multiply / DIV_VALUE;
			parentEntity.Get<UpdateEvent>();
		}

		private static void DisableButton(BusinessViewAdvRef view)
		{
			view.ButtonBuy.interactable = false;
			view.PriceText.text = "Куплено";
			foreach (var gameObject in view.ObjectsForDisable)
			{
				gameObject.SetActive(false);
			}
		}
	}
}