using AutoMapper;
using scratch_collect.API.Database;
using scratch_collect.API.Exceptions;
using scratch_collect.Model;
using System;
using System.Linq;

namespace scratch_collect.API.Services
{
    public class RatingService : IRatingService
    {
        private readonly ScratchCollectContext _context;
        private readonly IMapper _mapper;

        public RatingService(ScratchCollectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RatingDTO Rate(RatingRequest request)
        {
            // Check if user rated item already
            var alreadyRated = _context
                .Ratings
                .Where(x => x.OfferId == request.OfferId && x.UserId == request.UserId)
                .Any();

            if (alreadyRated)
                throw new BadRequestException("You already rated this item!");

            // Rate item
            var model = _mapper.Map<Rating>(request);
            model.RatedOn = DateTime.Now;

            _context.Ratings.Add(model);
            _context.SaveChanges();

            return _mapper.Map<RatingDTO>(model);
        }
    }
}