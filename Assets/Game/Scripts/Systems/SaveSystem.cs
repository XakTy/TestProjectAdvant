using Game.Scripts.Components;
using Game.Scripts.Other.Dates;
using Game.Scripts.Other.Interfaces;
using Game.Scripts.Other.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace Game
{
	public sealed class SaveSystem : IEcsRunSystem
	{
		private readonly EcsFilter<SaveEvent> _filter = default ;

		private readonly EcsFilter<State> _filterStates = default ;

		private readonly ISaveLoad _saveLoadSystem = default;

		private readonly PlayerData _playerData = default;

		private readonly StaticData _staticData = default;

		public SaveSystem(ISaveLoad saveLoad, StaticData staticData, PlayerData playerData)
		{
			_saveLoadSystem = saveLoad;
			_staticData = staticData;
			_playerData = playerData;
		}


		public void Run()
		{
			if (_filter.IsEmpty()) return;

			foreach (var i in _filter)
			{
				Save();

				var entity = _filter.GetEntity(i);
				entity.Destroy();
			}
		}

		public void Save()
		{
			SaveEntities();

			_saveLoadSystem.Save(_playerData, _staticData.PlayerKey);

			PlayerPrefs.Save();
		}

		private void SaveEntities()
		{
			foreach (var indexState in _filterStates)
			{
				var state = _filterStates.Get1(indexState).value;
				var entity = _filterStates.GetEntity(indexState);
				state.Update(entity);

				_saveLoadSystem.Save(state, state.ID);
			}
		}
	}
}