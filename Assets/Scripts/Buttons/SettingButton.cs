using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Buttons
{
    public class SettingButton : BaseButton
    {
        public GameObject Object;

        public void Open()
        {
            Object.SetActive(true);
        }
        public void Close()
        {
            Object.SetActive(false);
        }
    }
}