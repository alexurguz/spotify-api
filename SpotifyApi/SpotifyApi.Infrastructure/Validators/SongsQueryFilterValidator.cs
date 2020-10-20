using System;
using FluentValidation;
using SpotifyApi.Core.QueryFilters;

namespace SpotifyApi.Infrastructure.Validators
{
    public class SongsQueryFilterValidator : AbstractValidator<SongsQueryFilter>
    {
        public SongsQueryFilterValidator()
        {
            RuleFor(SongsQueryFilter => SongsQueryFilter.songId)
                .NotNull()
                .WithMessage("songId can't be null");
        }
    }
}
