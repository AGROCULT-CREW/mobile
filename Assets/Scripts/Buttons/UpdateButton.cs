using Assets.Models;
using Assets.Scripts.Connectors;
using System.Collections.Generic;
using TMPro;

namespace Assets.Scripts.Buttons
{
    public class UpdateButton : BaseButton
    {
        private Core _core = Core.GetCore();
        public TextMeshProUGUI Text;

        public void GetCulture()
        {
            if (_core.IsUpdateCulture)
            {
                foreach (Culture culture in _core.Cultures)
                {
                    Text.text += culture.Id + "\n";
                }

                _core.IsUpdateCulture = !_core.IsUpdateCulture;
            }
            
        }

    }
}