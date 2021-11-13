namespace Assets.Scripts.Connectors
{
    public static class EndPoints
    {
        public const string HealthCheck = "http://172.105.66.134:8000/api/health";
        public const string SendEchoMessage = "http://172.105.66.134:8000/api/echo";
        public const string CreateContainer = "http://172.105.66.134:8000/api/containers";
        public const string GetContainersFiles = "http://172.105.66.134:8000/api/containers/{0}/files";
        public const string UploadContainerPhoto = "http://172.105.66.134:8000/api/containers/{0}/files";
        public const string StartContainerProcessing = "http://172.105.66.134:8000/api/containers/{0}/start";
        public const string GetContainer = "http://172.105.66.134:8000/api/containers/{0}";
        public const string GetGrainCultures = "http://172.105.66.134:8000/api/cultures";
        public const string GetGrainCulture = "http://172.105.66.134:8000/api/cultures/{0}";
    }
}