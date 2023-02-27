using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FacePlusPlus.Web.Contracts.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FacePlusPlus.Web.Controllers
{
    // [ApiController]
    // [Route("[controller]")]
    // public class FaceTestController : ControllerBase
    // {
    //     private const int CONNECT_TIME_OUT = 30000;
    //     private const int READ_OUT_TIME = 50000;
    //   //  private static readonly string boundaryString = GetBoundary();
    //
    //     private static string GetBoundary()
    //     {
    //         var sb = new StringBuilder();
    //         var random = new Random();
    //         for (var i = 0; i < 32; i++)
    //         {
    //             sb.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_".Length)]);
    //         }
    //         return sb.ToString();
    //     }
    //
    //     private static string Encode(string value)
    //     {
    //         return Uri.EscapeDataString(value);
    //     }
    //
    //     private static async Task<byte[]> PostAsync(string url, IDictionary<string, string> map, IDictionary<string, byte[]> fileMap)
    //     {
    //         using var client = new HttpClient
    //         {
    //             Timeout = TimeSpan.FromMilliseconds(READ_OUT_TIME)
    //         };
    //
    //         using var content = new MultipartFormDataContent();
    //
    //         foreach (var entry in map)
    //         {
    //             content.Add(new StringContent(entry.Value), $"\"{entry.Key}\"");
    //         }
    //
    //         if (fileMap != null && fileMap.Count > 0)
    //         {
    //             foreach (var fileEntry in fileMap)
    //             {
    //                 var fileContent = new ByteArrayContent(fileEntry.Value);
    //                 fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
    //                 content.Add(fileContent, $"\"{fileEntry.Key}\"", "image");
    //             }
    //         }
    //
    //         using var response = await client.PostAsync(url, content);
    //
    //         if (!response.IsSuccessStatusCode)
    //         {
    //             throw new Exception($"HTTP {response.StatusCode}: {response.ReasonPhrase}");
    //         }
    //
    //         using var stream = await response.Content.ReadAsStreamAsync();
    //         using var ms = new MemoryStream();
    //         await stream.CopyToAsync(ms);
    //         return ms.ToArray();
    //     }
    //
    //     private static byte[] GetBytesFromFile(IFormFile file)
    //     {
    //         if (file == null)
    //         {
    //             return null;
    //         }
    //
    //         using var stream = file.OpenReadStream();
    //         using var outStream = new MemoryStream(1000);
    //         var b = new byte[1000];
    //         int n;
    //         while ((n = stream.Read(b, 0, b.Length)) > 0)
    //         {
    //             outStream.Write(b, 0, n);
    //         }
    //         return outStream.ToArray();
    //     }
    //
    //     [HttpPost]
    //     public async Task<IActionResult> Index([FromForm]FacePlusCompareFileDto request)
    //     {
    //         var url = "https://api-us.faceplusplus.com/facepp/v3/compare";
    //         var map = new Dictionary<string, string>
    //         {
    //             ["api_key"] = "ufEd4x8QI09UnlvCj-VMnwsdJ_6IWNMU",
    //             ["api_secret"] = "NxZIkhmalL7nu3z9X0kTWw45t-oyq4S9"
    //         };
    //         var byteMap = new Dictionary<string, byte[]>
    //         {
    //             // ["image_file1"] = GetBytesFromFile(file1),
    //             // ["image_file2"] = GetBytesFromFile(file2)
    //             ["image_file1"] = request.Image_1,
    //             ["image_file2"] = request.Image_2
    //         };
    //
    //         try
    //         {
    //             var bytes = await PostAsync(url, map, byteMap);
    //             var str = Encoding.UTF8.GetString(bytes);
    //             return Content(str, "application/json");
    //         }
    //         catch (Exception e)
    //         {
    //             return Problem(detail: e.Message, statusCode: 500);
    //         }
    //     }
    // }
    // // public class WeatherForecastController : ControllerBase
    // // {
    // //     private static readonly string[] Summaries = new[]
    // //     {
    // //         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // //     };
    // //
    // //     private readonly ILogger<WeatherForecastController> _logger;
    // //
    // //     public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // //     {
    // //         _logger = logger;
    // //     }
    // //
    // //     [HttpGet]
    // //     public IEnumerable<WeatherForecast> Get()
    // //     {
    // //         var rng = new Random();
    // //         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    // //         {
    // //             Date = DateTime.Now.AddDays(index),
    // //             TemperatureC = rng.Next(-20, 55),
    // //             Summary = Summaries[rng.Next(Summaries.Length)]
    // //         })
    // //         .ToArray();
    // //     }
    // // }
}
