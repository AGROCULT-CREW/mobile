using UnityEngine.SceneManagement;

namespace Assets.Scripts.Buttons
{
    public class ReportButton : BaseButton
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("Report");
        }
    }
}