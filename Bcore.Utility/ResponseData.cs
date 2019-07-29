namespace Bcore.Utility
{
    public class ResponseData
    {
        public int IsSuccess { get; set; }
        public int ResultId { get; set; }
        public object Data { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DebugInfo { get; set; }
    }
}
