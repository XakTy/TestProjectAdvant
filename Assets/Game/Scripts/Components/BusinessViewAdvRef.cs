using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Components
{
	[Serializable]
	public struct BusinessViewAdvRef
	{
		public GameObject[] ObjectsForDisable;
		public Button ButtonBuy;
		public TMP_Text PriceText;
		public TMP_Text NameText;
		public TMP_Text IncomeText;
	}
}