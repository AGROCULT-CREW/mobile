namespace Assets.Models
{
    public class GetContainerFilesInput
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string UniqueFileName { get; set; }
        public string S3Path { get; set; }
        public string CreatedAt { get; set; }
        public string CalculatedAt { get; set; }
        public int ContainerId { get; set; }
        public Status Status { get; set; }
    }
}