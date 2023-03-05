using Application.Interfaces;
using Domain.Entities;
using UseFilteringAttribute = HotChocolate.Data.UseFilteringAttribute;
using UseSortingAttribute = HotChocolate.Data.UseSortingAttribute;

namespace Api.GraphQL.RatingScales
{
    [ExtendObjectType("Query")]
    public class RatingScaleQuery
    {
        private readonly IBaseService<RatingScale> iRatingScaleService;

        public RatingScaleQuery(IBaseService<RatingScale> pRatingScaleService)
        {
            iRatingScaleService = pRatingScaleService;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RatingScale> GetRatingScales()
        {
            return iRatingScaleService.GetQueryable();
        }
    }
}
