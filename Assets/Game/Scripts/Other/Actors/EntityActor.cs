using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Other.Actors
{
	public abstract class EntityActor : MonoBehaviour
	{
		private EcsEntity _entity;
		public EcsEntity Entity => _entity;

		public bool IsDestroy;
		public void Init(EcsWorld world)
		{
			_entity = world.NewEntity();
			InitComponents();
			DestroyActor();
		}
		public void Init()
		{
			var world = Service<EcsWorld>.Get();

			if (world != null)
			{
				_entity = world.NewEntity();
			}

			InitComponents();
			DestroyActor();
		}

		private void DestroyActor()
		{
			if (IsDestroy)
			{
				Object.Destroy(this);
			}
		}
		protected abstract void InitComponents();
	}
}