using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FacePlusPlus.Application.Broker;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FacePlusPlus.Application.UseCases.FacePlus.GetCompareResult
{
    public class GetFacePlusCompareByBit64Query:IRequest<Result<FacePlusCompareResponse>>
    {
        public  byte[] Image_1 { get; set; }
        public  byte[] Image_2 { get; set; }

        public GetFacePlusCompareByBit64Query(byte[] image1, byte[] image2)
        {
            Image_1 = image1;
            Image_2 = image2;
        }
    }
    public class GetFacePlusCompareByBit64QueryHandler: IRequestHandler<GetFacePlusCompareByBit64Query, Result<FacePlusCompareResponse>>
    {
        private readonly IConfiguration _configuration;
        private const int CONNECT_TIME_OUT = 30000;
        private const int READ_OUT_TIME = 50000;

        public GetFacePlusCompareByBit64QueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Result<FacePlusCompareResponse>> Handle(GetFacePlusCompareByBit64Query request, CancellationToken cancellationToken)
        {
            var api_key = _configuration.GetValue<string>("FacePlusPlus:Key");
            var api_secret = _configuration.GetValue<string>("FacePlusPlus:Secret");
            var baseUrl= _configuration.GetValue<string>("FacePlusPlus:BaseUrl");
            var url = baseUrl+"/compare";
            var map = new Dictionary<string, string>
            {
                ["api_key"] = api_key,
                ["api_secret"] = api_secret
            };
            var byteMap = new Dictionary<string, byte[]>
            {
                // ["image_file1"] = GetBytesFromFile(file1),
                // ["image_file2"] = GetBytesFromFile(file2)
                ["image_file1"] = request.Image_1,
                ["image_file2"] = request.Image_2
            };

            try
            {
                var result = await PostAsync(url, map, byteMap);
                if (result.IsSuccess)
                {
                    return Result.Success(result.Value);
                }
            }
            catch (Exception e)
            {
                return Result.Failure<FacePlusCompareResponse>($"detail: {e.Message}, statusCode: 500");
            }
            return Result.Failure<FacePlusCompareResponse>("something wrong");
        }
        private static async Task<Result<FacePlusCompareResponse>>PostAsync(string url, IDictionary<string, string> map, IDictionary<string, byte[]> fileMap)
        {
            using var client = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(READ_OUT_TIME)
            };

            using var content = new MultipartFormDataContent();

            foreach (var entry in map)
            {
                content.Add(new StringContent(entry.Value), $"\"{entry.Key}\"");
            }

            if (fileMap != null && fileMap.Count > 0)
            {
                foreach (var fileEntry in fileMap)
                {
                    var fileContent = new ByteArrayContent(fileEntry.Value);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    content.Add(fileContent, $"\"{fileEntry.Key}\"", "image");
                }
            }

            using var response = await client.PostAsync(url, content);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<FacePlusCompareResponse>(responseContent);
                return Result.Success(responseData);
            }
            var responseContentError = await response.Content.ReadAsStringAsync();
           
            return Result.Failure<FacePlusCompareResponse>("Error:  "+responseContentError);
        }

    }
}