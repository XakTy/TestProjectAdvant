using Leopotam.Ecs;

namespace Game.Scripts.Other.Interfaces
{
	public interface IState
	{
		public string ID { get; set; }

		public void Update(EcsEntity entity);
	}
}