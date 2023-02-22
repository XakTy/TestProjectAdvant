using Game.Scripts.Other.Actors;
using Game.Scripts.Other.Containers;
using UnityEngine;

namespace Game.Scripts.Other.Dates
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Prefabs")]
	    public BusinessView businessPrefab;
	    public BusinessAdv businessAdvPrefab;

	    [Header("Levels")]
        public Levels Levels;
        
        [Header("Required prefabs")]        
        public UI UI;

        [Header("Business")]
        public float MultiplyForAllBusiness;
		public BasicBusiness[] Businnes;

        [Header("PlayerSettings")]
        public string PlayerKey;
    }
}