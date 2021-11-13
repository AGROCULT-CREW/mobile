namespace Assets.Models
{
    public class GetContainerInput
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int PlantingArea { get; set; }
        public string CreatedAt { get; set; }
        public string CalculatedAt { get; set; }
        public int GrainCultureId { get; set; }
        public int AverageWeightThousandGrains { get; set; }
        public int AverageStemsPerMeter { get; set; }
        public int BiologicalYield { get; set; }
        public Status Status { get; set; }
    }
}