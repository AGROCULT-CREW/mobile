using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Cam : MonoBehaviour
    {
        public Button btn;
        public TextMeshProUGUI text;

        void Start()
        {
            if (NativeCamera.CheckPermission() != NativeCamera.Permission.Granted)
            {
                GetAccess();
            }
        }

        private void GetAccess()
        {
            NativeCamera.RequestPermission();
        }

        public void TakePicture(int maxSize = 2048)
        {
            NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
            {
                text.text += "Image path: " + path + "\n";
                if (path != null)
                {
                    // Create a Texture2D from the captured image
                    Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
                    if (texture == null)
                    {
                        text.text += "Couldn't load texture from " + path + "\n";
                        return;
                    }

                    // Assign texture to a temporary quad and destroy it after 5 seconds
                    GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                    quad.transform.forward = Camera.main.transform.forward;
                    quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);

                    Material material = quad.GetComponent<Renderer>().material;
                    if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                        material.shader = Shader.Find("Legacy Shaders/Diffuse");

                    material.mainTexture = texture;

                    Destroy(quad, 5f);

                    // If a procedural texture is not destroyed manually, 
                    // it will only be freed after a scene change
                    Destroy(texture, 5f);
                }
            }, maxSize);

            text.text += "Permission result: " + permission + "\n";
        }
    }
}