using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Components
{
	[Serializable]
	public struct BusinessViewRef
	{
		public RectTransform ContainerAdv;
		public Button LevelUpButton;
		public Image ProgressImage;
		public TMP_Text PriceText;
		public TMP_Text NameText;
		public TMP_Text LevelText;
		public TMP_Text IncomeText;
	}
}