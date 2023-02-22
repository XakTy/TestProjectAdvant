using System.Collections;
using Game.Scripts.Other.Dates;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Game.Scripts.Other
{
    public sealed class Boot : MonoBehaviour
    {
        public StaticData StaticData;
        private IEnumerator Start()
        {
            Service<StaticData>.Set(StaticData);
           
            GameInitialization.FullInit();
            yield return null;
            Levels.LoadCurrent();
        }
    }
}