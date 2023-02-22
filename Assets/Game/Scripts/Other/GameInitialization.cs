using Game.Scripts.Other.Dates;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Game.Scripts.Other
{
    static class GameInitialization
    {
        public static void FullInit()
        {
            InitializeUi();
        }

        public static UI InitializeUi()
        {
            var configuration = Service<StaticData>.Get();
            var ui = Service<UI>.Get();
            if (ui == null)
            {
	            Debug.LogError(configuration.UI);
                ui = Object.Instantiate(configuration.UI);
                Service<UI>.Set(ui);
            }

            return ui;
        }

        public static UI InitializeUi(StaticData configuration)
        {
	        var ui = Service<UI>.Get();
	        if (ui == null)
	        {
		        Debug.LogError(configuration.UI);
		        ui = Object.Instantiate(configuration.UI);
		        Service<UI>.Set(ui);
	        }

	        return ui;
        }
	}
}