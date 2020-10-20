using System;
using FluentValidation;
using SpotifyApi.Core.QueryFilters;

namespace SpotifyApi.Infrastructure.Validators
{
    public class ArtistQueryFilterValidator : AbstractValidator<ArtistQueryFilter>
    {
        public ArtistQueryFilterValidator()
        {
            RuleFor(ArtistQueryFilter => ArtistQueryFilter.artistsIds)
                .NotNull()
                .WithMessage("artistsIds can't be null")
                .Must(hasNumberValidArtists)
                .WithMessage("artistsIds only can procces 15 ids by artist");
        }

        private bool hasNumberValidArtists(string artistsIds)
        {
            bool resp = false;
            if ( artistsIds != null ) {
                int count = artistsIds.Split(',').Length - 1;
                if (count <= 14)
                    resp = true;
            }
            
            return resp;
        }
    }
}