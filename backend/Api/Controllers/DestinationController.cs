using Application.Destinations.Dtos;
using Application.Destinations.Interfaces;
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

        #region Destination

        [HttpGet]
        public async Task<IActionResult> Destinations()
        {
            IEnumerable<DestinationDto> mList;

            mList = await iDestinationService.GetDestinations();

            return Ok(mList);
        }

        [HttpGet("{pId}")]
        public async Task<IActionResult> Destinations(int pId)
        {
            var mDestination = await iDestinationService.GetDestinationById(pId);

            return Ok(mDestination);
        }

        [HttpPost]
        public async Task<IActionResult> Destination(InputDestinationDto pDestinationDto)
        {
            await iDestinationService.AddDestination(pDestinationDto);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Destination(DestinationDto pDestinationDto)
        {
            await iDestinationService.UpdateDestination(pDestinationDto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Destination(int pId)
        {
            await iDestinationService.DeleteDestination(pId);

            return Ok();
        }

        #endregion  
    }
}
