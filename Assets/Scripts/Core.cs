using Assets.Models;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Core
    {
        private static Core core;
        public List<Culture> Cultures { get; set; }
        public bool IsUpdateCulture { get; set; }
        public bool IsHealth { get; set; }

        private Core()
        {
            Cultures = new List<Culture>()
            {
                new Culture()
                {
                    Id = 2,
                    Name = "Подсолнечник/Классические гибриды - ЛГ 5377",
                    AverageWeightThousandGrains = 80
                },
                new Culture()
                {
                    Id = 3,
                    Name = "Подсолнечник/Классические гибриды",
                    AverageWeightThousandGrains = 60
                },
                new Culture()
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