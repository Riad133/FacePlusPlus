using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FacePlusPlus.Application.Broker;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace FacePlusPlus.Application.UseCases.FacePlus.GetCompareResult
{
    public class GetFacePlusCompareQuery: IRequest<Result<FacePlusCompareResponse>>
    {
        public  string Image1 { get; private set; }
        public  string Image2 { get; private set; }
        public GetFacePlusCompareQuery( string image1,string image2)
        {
            Image1 = image1;
            Image2 = image2;
        }
    }

    public class GetFacePlusCompareQueryHandler: IRequestHandler<GetFacePlusCompareQuery, Result<FacePlusCompareResponse>>
    {
        private readonly IConfiguration _configuration;

        public GetFacePlusCompareQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
      

        

        public async Task<Result<FacePlusCompareResponse>> Handle(GetFacePlusCompareQuery userRequest, CancellationToken cancellationToken)
        {
            var api_key = _configuration.GetValue<string>("FacePlusPlus:Key");
            var api_secret = _configuration.GetValue<string>("FacePlusPlus:Secret");
            var baseUrl= _configuration.GetValue<string>("FacePlusPlus:BaseUrl");
           
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            Dictionary<String,String> dictionary = new Dictionary<string, string>();
        
            dictionary.Add("api_key", api_key);
            dictionary.Add("api_secret", api_secret);
            dictionary.Add("image_url1",userRequest.Image1);
            dictionary.Add("image_url2",userRequest.Image2);
            var content = new FormUrlEncodedContent(dictionary);
           
            var response = await client.PostAsync($"{baseUrl}/compare", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<FacePlusCompareResponse>(responseContent);
                return Result.Success(responseData);
            }
           
                
            var responseContentError = await response.Content.ReadAsStringAsync();
               
            
            return  Result.Failure<FacePlusCompareResponse>(responseContentError);
        }
        
    }
}