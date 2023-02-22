using UnityEngine;

namespace Game.Scripts.SO.BussinesSO
{
	[CreateAssetMenu(fileName = "BussinesView", menuName = "Bussines/Adv_Data", order = 0)]
	public sealed class BusinessAdvData : ScriptableObject
	{
		[SerializeField] private string _id;

		[SerializeField] private string _name;

		[SerializeField] private float _basicPrice;

		[SerializeField] private float _multiply;
		public string ID => _id;
		public string Name => _name;
		public float BasicPrice => _basicPrice;
		public float Multiply => _multiply;
	}
}