using Game.Scripts.Components;
using Game.Scripts.Other.Actors;
using Game.Scripts.Other.Containers;
using Game.Scripts.Other.Dates;
using Game.Scripts.Other.Player;
using Game.Scripts.Other.States;
using Leopotam.Ecs;
using Game.Scripts.SO.BussinesSO;
using UnityEngine;
using Game.Scripts.Other.Interfaces;

namespace Game
{
	public sealed class InitializeSystem : IEcsInitSystem
    {
	    private readonly EcsWorld _world = default;

        private readonly SceneData _sceneData = default;

		private readonly ISaveLoad _saveLoadSystem = default;

		private readonly StaticData _staticData = default;

		private readonly UI _ui = default;

		private readonly PlayerData _playerData = default;

		public InitializeSystem(EcsWorld world, SceneData sceneData, ISaveLoad saveLoad, StaticData staticData,
			UI ui, PlayerData playerData)
		{
			_world = world;
			_sceneData = sceneData;
			_saveLoadSystem = saveLoad;
			_staticData = staticData;
			_ui = ui;
			_playerData = playerData;
		}

		public void Init()
        {
	        _ui.GameScreen.MoneyText.text = $"{_playerData.Cash}";
			InstantiateBusiness();
        }

        private void InstantiateBusiness()
        {
	        foreach (var basicBusiness in _staticData.Businnes)
	        {
		        var loadBussine = Object.Instantiate(_staticData.businessPrefab, _sceneData.Container);
		        loadBussine.Init(_world);
		        loadBussine.Entity.Get<BusinessDataRef>().value = basicBusiness.Data;

		        InitBusinessAdvanced(basicBusiness, loadBussine);
		        InitStateBusiness(basicBusiness, loadBussine);
	        }
        }

        private void InitStateBusiness(BasicBusiness basicBusiness, BusinessView loadBussine)
        {
	        var state = _saveLoadSystem.Load<BusinessState>(basicBusiness.Data.ID);
	        state.ID = basicBusiness.Data.ID;

	        if (basicBusiness.IsBuy && !state.IsBuy)
	        {
		        state.Level = 1;
		        state.IsBuy = basicBusiness.IsBuy;
	        }

	        loadBussine.Entity.Get<BusinessStateRef>().value = state;
	        loadBussine.Entity.Get<State>().value = state;
        }

        private void InitBusinessAdvanced(BasicBusiness basicBusiness, BusinessView loadBussine)
        {
	        if (basicBusiness.Data.BusinessAdvanced.Length == 0) return;

			foreach (var businessAdvData in basicBusiness.Data.BusinessAdvanced)
			{
				var container = loadBussine.Entity.Get<BusinessViewRef>().ContainerAdv;

				var advBusiness = CreateAdvBusiness(container, businessAdvData, out var state);

				advBusiness.Entity.Get<Parent>().value = loadBussine.Entity;
		        advBusiness.Entity.Get<BusinessAdvDataRef>().value = businessAdvData;
				advBusiness.Entity.Get<BusinessStateAdvRef>().value = state;
				advBusiness.Entity.Get<State>().value = state;
	        }
        }

        private BusinessAdv CreateAdvBusiness(RectTransform container, BusinessAdvData businessAdvData,
	        out BusinessAdvState state)
        {
	        var advBusiness = Object.Instantiate(_staticData.businessAdvPrefab,
		        container);

	        advBusiness.Init(_world);
	        advBusiness.Init(businessAdvData);

	        state = _saveLoadSystem.Load<BusinessAdvState>(businessAdvData.ID);
	        state.ID = businessAdvData.ID;
	        return advBusiness;
        }
    }
}