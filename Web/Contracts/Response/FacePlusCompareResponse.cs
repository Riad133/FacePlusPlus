using Newtonsoft.Json;

namespace FacePlusPlus.Web.Contracts.Response
{
    // public class FacePlusCompareResponse
    // {
    //     
    //     public string Status { get; set; }
    //     public long Code { get; set; }
    //     public bool Success { get; set; }
    //     public string Message { get; set; }
    //     public CompareData Data { get; set; }
    //     public string Exception { get; set; }
    // }
    // public partial class CompareData
    // {
    //     public string Confidence { get; set; }
    // }
    public  class FacePlusCompareResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public CompareData Data { get; set; }
        public string Exception { get; set; }
        public string ReqURL { get; set; }


    }

    public class CompareData
    {
        [JsonProperty("confidence")]
        public string confidence { get; set; }
    }
}