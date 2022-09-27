using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingScaleController : ControllerBase
    {
        private readonly IRatingScaleRepository iRatingScaleRepository;

        public RatingScaleController(IRatingScaleRepository pRatingScaleRepository)
        {
            iRatingScaleRepository = pRatingScaleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mList = await iRatingScaleRepository.GetAllAsync();

            return Ok(mList);
        }
    }
}
