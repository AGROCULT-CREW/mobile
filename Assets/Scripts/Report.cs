using Assets.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Report : MonoBehaviour
    {
        private Core _core = Core.GetCore();
        public TMP_Dropdown CultureDropdown;

        void Start()
        {
            UpdateCulture();
        }

        public void UpdateCulture()
        {
            foreach (GetGrainCultureInput culture in _core.Cultures)
            {
                CultureDropdown.options.Add(new TMP_Dropdown.OptionData(culture.Name));
            }
        }
    }
}