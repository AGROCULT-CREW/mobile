namespace Assets.Models
{
    public class CreateContainerOutput
    {
        public string Note { get; set; }
        public int PlantingArea { get; set; }
        public int GrainCultureId { get; set; }
        public int CustomAverageStemsPerMeter { get; set; }
        public int CustomAverageWeightThousandGrains { get; set; }
    }
}