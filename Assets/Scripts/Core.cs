using Assets.Models;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Core
    {
        private static Core core;

        public static Dictionary<int,Texture2D> Textures = new Dictionary<int, Texture2D>(); //Таблица фото
        public List<GetGrainCultureInput> Cultures { get; set; }
        public CreateContainerInput CreateContainerInput { get; set; }
        public GetContainerInput GetContainerInput { get; set; }
        public GetContainerFilesInput GetContainerFilesInput { get; set; }
        public GetGrainCultureInput GetGrainCultureInput { get; set; }
        public StartContainerProcessingInput StartContainerProcessingInput { get; set; }
        public UploadContainerPhotoInput UploadContainerPhotoInput { get; set; }
        public bool IsUpdateCulture { get; set; }
        public bool IsHealth { get; set; }

        private Core()
        {
            Cultures = new List<GetGrainCultureInput>()
            {
                new GetGrainCultureInput()
                {
                    Id = 2,
                    Name = "Подсолнечник/Классические гибриды - ЛГ 5377",
                    AverageWeightThousandGrains = 80
                },
                new GetGrainCultureInput()
                {
                    Id = 3,
                    Name = "Подсолнечник/Классические гибриды",
                    AverageWeightThousandGrains = 60
                },
                new GetGrainCultureInput()
                {
                    Id = 4,
                    Name = "Подсолнечник/Классические гибриды - НК РОКИ",
                    AverageWeightThousandGrains = 680
                },
            };
        }

        public static Core GetCore()
        {
            return core ??= new Core();
        }
    }
}