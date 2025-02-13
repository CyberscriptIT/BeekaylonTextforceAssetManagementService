namespace TextForce.AssetManagement.Service.Models.CommonEntities
{
    public class Response
    {
        public string Message { get; set; } = string.Empty;
        public object? data { get; set; } = "";
        public bool Success { get; set; } = true;
        public int StatusCode { get; set; } = 200;
    }
}
