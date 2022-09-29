using Application.Interfaces;
using Application.Dtos.Destinations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService iDestinationService;

        public DestinationController(IDestinationService pDestinationService)
        {
            iDestinationService = pDestinationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<DestinationDto> mList;

            mList = await iDestinationService.GetDestinations();

            return Ok(mList);
        }

        [HttpGet("{pId}")]
        public async Task<IActionResult> Get(int pId)
        {
            var mDestination = await iDestinationService.GetDestinationById(pId);

            return Ok(mDestination);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InputDestinationDto pDestinationDto)
        {
            var mResult = await iDestinationService.AddDestination(pDestinationDto);

            if (mResult.Code == 200)
            {
                return Ok(mResult.Message);
            }
            else
            {
                return Problem(detail: mResult.Details, title: mResult.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(DestinationDto pDestinationDto)
        {
            var mResult = await iDestinationService.UpdateDestination(pDestinationDto);

            if (mResult.Code == 200)
            {
                return Ok(mResult.Message);
            }
            else
            {
                return Problem(detail: mResult.Details, title: mResult.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int pId)
        {
            var mResult = await iDestinationService.DeleteDestination(pId);

            if (mResult.Code == 200)
            {
                return Ok(mResult.Message);
            }
            else if (mResult.Code == 404)
            {
                return BadRequest(mResult.Message);
            }

            return Problem(detail: mResult.Details, title: mResult.Message);
        } 
    }
}
