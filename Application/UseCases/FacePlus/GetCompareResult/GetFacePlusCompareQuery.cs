using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;

namespace FacePlusPlus.Application.UseCases.FacePlus.GetCompareResult
{
    public class GetFacePlusCompareQuery: IRequest<Result>
    {
        public string Image1 { get; private set; }
        public string Image2 { get; private set; }
        public GetFacePlusCompareQuery(string image1,string image2)
        {
          
        }
    }

    public class GetFacePlusCompareQueryHandler: IRequestHandler<GetFacePlusCompareQuery, Result>
    {
        public async Task<Result> Handle(GetFacePlusCompareQuery userRequest, CancellationToken cancellationToken)
        {
            var key = "";
            var secret = "";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api-us.faceplusplus.com/facepp/v3/compare");
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(key), "api_key");
            content.Add(new StringContent(secret), "api_secret");
            content.Add(new StringContent(""), "face_token1");
            content.Add(new StringContent(""), "face_token2");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return  Result.Success();
        }
    }
}