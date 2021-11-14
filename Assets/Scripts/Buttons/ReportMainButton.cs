using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Buttons
{
    public class ReportMainButton : BaseButton
    {
        public GameObject PanelReportList;
        public GameObject PanelReportMain;

        public void Open()
        {
            PanelReportList.SetActive(false);
            PanelReportMain.SetActive(true);
        }

        public void Close()
        {
            PanelReportList.SetActive(true);
            PanelReportMain.SetActive(false);
        }

        public void BackMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}