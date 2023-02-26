namespace FacePlusPlus.Web.Contracts.Response
{
    public class FacePlusCompareResponse
    {
        
        public string Status { get; set; }
        public long Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public CompareData Data { get; set; }
        public string Exception { get; set; }
    }
    public partial class CompareData
    {
        public string Confidence { get; set; }
    }
}