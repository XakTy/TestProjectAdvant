using System;
using Game.Scripts.Other.Interfaces;
using Leopotam.Ecs;

namespace Game.Scripts.Other.States
{
	[Serializable]
	public class BusinessAdvState : IState
	{
		public string ID { get; set; }
		public void Update(EcsEntity entity)
		{
		}

		public bool IsBuy;
	}
}