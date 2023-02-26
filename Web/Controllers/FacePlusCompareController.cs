using System.Threading.Tasks;
using FacePlusPlus.Application.UseCases.FacePlus.GetCompareResult;
using FacePlusPlus.Web.Contracts.Request;
using FacePlusPlus.Web.Contracts.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FacePlusPlus.Web.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class FacePlusCompareController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacePlusCompareController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET
        [HttpPost("compare_faces")]
        public async Task<ActionResult<FacePlusCompareResponse>> Get(
            [FromForm] FacePlusCompareDto dto)
        {
            var result =  await _mediator.Send(new GetFacePlusCompareQuery(dto.Image_1,dto.Image_2));
            if (result.IsSuccess)
            {
                return Ok(new FacePlusCompareResponse()
                    {
                        Status = "Success",
                        Code = 1000,
                        Success = true,
                        Message = "Fetched confidence value.",
                        Data = new CompareData()
                        {
                            Confidence = result.Value.Confidence.ToString()
                        },
                        Exception = string.Empty
                        
                    }
                
                );
            }
            return BadRequest(new FacePlusCompareResponse()
            {
                Status = "Failed",
                Code = 2000,
                Success = false,
                Message = "Fetched confidence value.",
                Data = new CompareData()
                {
                    Confidence = null
                },
                Exception = result.Error
                        
            });
        }
    }
}