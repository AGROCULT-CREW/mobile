using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Buttons
{
    public class ReportListButton : MonoBehaviour
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("ReportList");
        }
    }
}