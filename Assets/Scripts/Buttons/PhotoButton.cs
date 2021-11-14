using UnityEngine.SceneManagement;

namespace Assets.Scripts.Buttons
{
    public class PhotoButton : BaseButton
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("Photo");
        }
    }
}