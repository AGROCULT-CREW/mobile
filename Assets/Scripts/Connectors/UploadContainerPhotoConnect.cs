using Assets.Models;
using Assets.Scripts.Deserializers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Connectors
{
    public class UploadContainerPhotoConnect : ConnectBase
    {
        private string Url = EndPoints.UploadContainerPhoto;

        protected override IEnumerator SendRequest()
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            foreach (var item in Core.Textures)
            {
                formData.Add(new MultipartFormDataSection("item.Key", ImageConversion.EncodeToJPG(item.Value)));
            }
            


            using UnityWebRequest request = UnityWebRequest.Post(Url, formData);
            // Request and wait for the desired page.
            yield return request.SendWebRequest();
            TextMeshPro.text = request.downloadHandler.text;
            _deserializer = new Deserializer();
            _core.UploadContainerPhotoInput = _deserializer.Deserialize<UploadContainerPhotoInput>(request.downloadHandler.text);
            //_core.IsUpdateCulture = true;
        }
    }
}