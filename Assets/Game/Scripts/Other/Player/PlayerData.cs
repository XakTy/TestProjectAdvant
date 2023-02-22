using System;
using UnityEngine;

namespace Game.Scripts.Other.Player
{
	[Serializable]
	public sealed class PlayerData
	{
		[SerializeField] private float _cash;
		private UI _ui;

		public float Cash
		{
			get
			{
				return _cash;
			}

			set
			{
				_cash = value;
				_ui.GameScreen.MoneyText.text = _cash.ToString();
			}
		}

		public void Construct(UI ui)
		{
			_ui = ui;
		}
	}
}