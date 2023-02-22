using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class UI : MonoBehaviour
    {
	    public GameScreen GameScreen;

        public EventSystem EventSystem;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (!EventSystem.current && EventSystem.current != EventSystem)
            {
                EventSystem.gameObject.SetActive(false);
            }
            else
            {
                EventSystem.gameObject.SetActive(true);
            }
        }

        public void CloseAll()
        {
	        GameScreen.Show(false);
        }
    }
}