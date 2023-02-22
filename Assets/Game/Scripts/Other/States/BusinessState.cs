using System;
using Game.Scripts.Components;
using Game.Scripts.Other.Interfaces;
using Leopotam.Ecs;

namespace Game.Scripts.Other.States
{
	[Serializable]
	public class BusinessState : IState
	{
		public string ID { get; set; }
		public void Update(EcsEntity entity)
		{
			if (entity.Has<ProgressValue>())
			{
				 Progress = entity.Get<ProgressValue>().value;
			}
		}

		public bool IsBuy;
		public int Level;
		public float Progress;
		public BusinessAdvState[] BusinessAdvStates;
	}
}