namespace Assets.Models
{
    public class CreateContainerInput
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int PlantingArea { get; set; }
        public string CreatedAt { get; set; }
        public string CalculatedAt { get; set; }
        public int GrainCultureId { get; set; }
        public string AverageWeightThousandGrains { get; set; }
        public int AverageStemsPerMeter { get; set; }
        public Status Status { get; set; }
    }
}