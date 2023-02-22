using Game.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.Other.Actors
{
	public sealed class BusinessView : EntityActor
	{
		[SerializeField] private BusinessViewRef businessViewRef;
		protected override void InitComponents()
		{
			Entity.Get<BusinessViewRef>() = businessViewRef;
			Entity.Get<InitEvent>();
		}
	}
}