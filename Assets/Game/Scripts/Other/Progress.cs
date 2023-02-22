using UnityEngine;

namespace Game.Scripts.Other
{
    static partial class Progress
    {
        public static int CurrentLevel
        {
            get => PlayerPrefs.GetInt("CurrentLevel", 0);
            set => PlayerPrefs.SetInt("CurrentLevel", value);
        }
    }
}