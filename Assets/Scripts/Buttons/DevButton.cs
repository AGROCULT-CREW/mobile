using UnityEngine.SceneManagement;

namespace Assets.Scripts.Buttons
{
    public class DevButton : BaseButton
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("TestConnection");
        }
    }
}

