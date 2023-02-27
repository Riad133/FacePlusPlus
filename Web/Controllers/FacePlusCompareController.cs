using System.Threading.Tasks;
using FacePlusPlus.Application.UseCases.FacePlus.GetCompareResult;
using FacePlusPlus.Web.Contracts.Request;
using FacePlusPlus.Web.Contracts.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;

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
        public async Task<ActionResult<FacePlusCompareFileDto>> Get(
            IFormFile img_1, IFormFile img_2)
        {
            var log = new LoggerConfiguration().WriteTo.File(
                @"C:\logs\facePluslog.txt",
                LogEventLevel.Information).CreateLogger();
            log.Information("this is a log for entry");
            var result =  await _mediator.Send(new GetFacePlusCompareByBit64Query(img_1,img_2));
            if (result.IsSuccess)
            {
                log.Information("this is a log exit: Confidence: "+result.Value.Confidence.ToString());
                return Ok(new FacePlusCompareResponse()
                    {
                        Status = "ok",
                        Code = "1000",
                        Success = true,
                        Message = "Fetched confidence value.",
                        Data = new CompareData()
                        {
                            confidence = (result.Value.Confidence/100).ToString()
                        },
                        Exception = string.Empty
                        
                    }
                
                );
            }
            log.Information($"this is a log exit: error: {result.Error}");
            return BadRequest(new FacePlusCompareResponse()
            {
                Status = "ok",
                Code = "2000",
                Success = false,
                Message = "Fetched confidence value.",
                Data = new CompareData()
                {
                    confidence = "0"
                },
                Exception = result.Error
                        
            });
        }
    }
}