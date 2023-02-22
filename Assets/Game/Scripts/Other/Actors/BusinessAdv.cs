using Game.Scripts.Components;
using Game.Scripts.SO.BussinesSO;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Other.Actors
{
	public sealed class BusinessAdv : EntityActor
	{
		[SerializeField] private BusinessViewAdvRef _businessView;
		public void Init(BusinessAdvData businessAdvData)
		{
			_businessView.NameText.text = businessAdvData.Name;
			_businessView.IncomeText.text = businessAdvData.Multiply.ToString();
			_businessView.PriceText.text = businessAdvData.BasicPrice.ToString();
		}
		protected override void InitComponents()
		{
			Entity.Get<BusinessViewAdvRef>() = _businessView;
			Entity.Get<InitEvent>();
		}
	}
}