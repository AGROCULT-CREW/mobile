using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Cam : MonoBehaviour
    {
        private Core _core = Core.GetCore();
        public RawImage[] rimg = new RawImage[15];

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

        public void DestroyPhoto(int i)
        {
            Destroy(rimg[i].texture);
        }

        public void OnClick(int i)
        {
            //if (NativeCamera.IsCameraBusy())
            //{
            //    return;
            //}
            TakePicture(2048, i);
        }

        private void TakePicture(int maxSize, int i)
        {
            NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
            {
                text.text = ("Image path: " + path);
                if (path != null)
                {
                    Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
                    if (texture == null)
                    {
                        Debug.Log("Couldn't load texture from " + path);
                        return;
                    }

                    if (!Core.Textures.ContainsKey(i))
                    {
                        Core.Textures.Add(i, texture);
                    }
                    else
                    {
                        Core.Textures[i] = texture;
                    }
                    rimg[i].texture = Core.Textures[i];
                }
            }, maxSize);
        }
    }
}