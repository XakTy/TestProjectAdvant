using Game.Scripts.Other.Interfaces;
using UnityEngine;

namespace Game.Scripts.Other.Player
{
	public sealed class SaveLoadSystem : ISaveLoad
	{
		public T Load<T>(string key) where T : new()
		{
			var jsonLoad = PlayerPrefs.GetString(key);
			var data = JsonUtility.FromJson<T>(jsonLoad);

			if (data == null)
			{
				return new T();
			}

			return data;
		}

		public void Save<T>(T saveObject, string key)
		{
			var toJson = JsonUtility.ToJson(saveObject);
			PlayerPrefs.SetString(key, toJson);
		}
	}
}