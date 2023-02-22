using System.Collections;
using Game.Scripts.Components;
using Game.Scripts.Other.Dates;
using Game.Scripts.Other.Interfaces;
using Game.Scripts.Other.Player;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using NaughtyAttributes;
using UnityEngine;

namespace Game.Scripts.Other
{
    public sealed class Game : MonoBehaviour
    {
	    private EcsWorld _world;
	    private EcsSystems _systems;

	    private ISaveLoad _saveLoadSystem;
	    private PlayerData _playerData;
	    private SaveSystem _saveSystem;

		[SerializeField] private SceneData _sceneData;
		[SerializeField] private RuntimeData _runtimeData;
		[SerializeField] private StaticData _staticData;


        IEnumerator Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif

            GameInitialization.InitializeUi(_staticData);
            _runtimeData = new RuntimeData();
            _saveLoadSystem = new SaveLoadSystem();

            InitlizationPlayer();

            _saveSystem = new SaveSystem();


			_systems
                // register your systems here, for example:
                .Add(new InitializeSystem())

                .Add(new ProgressValueSystem())

                .Add(new BusinessProgressViewSystem())
                .Add(new BusinessInitSystem())
                .Add(new BusinessAdvInitSystem())
                .Add(new BusinessUpdateViewSystem())
                
                .Add(_saveSystem)
                .Add(new IncomeSystem())

                // inject 
                .Inject(_sceneData)
                .Inject(_runtimeData)
                .Inject(_staticData)
                .Inject(_saveLoadSystem)
                .Inject(_playerData)
                .Inject(Service<UI>.Get())

                .OneFrame<IncomeEvent>()
                .OneFrame<InitEvent>()
                .OneFrame<UpdateEvent>()
                
                

                .Init();
            Init();
            yield return null;
        }

        private void Init()
        {
	        Application.quitting += Save;

        }

		private void InitlizationPlayer()
        {
	        _playerData = _saveLoadSystem.Load<PlayerData>(_staticData.PlayerKey);
	        _playerData.Construct(Service<UI>.Get());
        }

        //private void ServiceInject()
        //{
	       // Service<SceneData>.Set(_sceneData);
	       // Service<RuntimeData>.Set(_runtimeData);
	       // Service<StaticData>.Set(_staticData);
	       // Service<EcsWorld>.Set(_world);
        //}

        private void Update()
        {
	        _runtimeData.deltaTime = Time.deltaTime;
            _systems?.Run();
        }

        void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
	            _saveSystem.Save();
            }
		}

		void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
	            _saveSystem.Save();
			}
		}
		private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }

            PlayerPrefs.Save();
		}

        [Button("Save")]
        public void Save()
        {
	        _world.NewEntity().Get<SaveEvent>();
        }
    }
}