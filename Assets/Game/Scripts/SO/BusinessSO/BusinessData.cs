using System.Security.Cryptography;
using UnityEngine;

namespace Game.Scripts.SO.BussinesSO
{
	[CreateAssetMenu(fileName = "BussinesView", menuName = "Bussines/Data", order = 0)]
	public sealed class BusinessData : ScriptableObject
	{

		[SerializeField] private string _id;

		[SerializeField] private string _name;

		[SerializeField] private float _timeIncome;

		[SerializeField] private float _basicPrice;

		[SerializeField] private BusinessAdvData[] _businessAdvanced;
		public string ID => _id;
		public string Name => _name;
		public float TimeIncome => _timeIncome;
		public float BasicPrice => _basicPrice;
		public BusinessAdvData[] BusinessAdvanced => _businessAdvanced;
	}
}