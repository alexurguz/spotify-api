using System;
using FluentValidation;
using SpotifyApi.Core.QueryFilters;

namespace SpotifyApi.Infrastructure.Validators
{
    public class SongQueryFilterValidator : AbstractValidator<SongQueryFilter>
    {
        public SongQueryFilterValidator()
        {
            RuleFor(SongQueryFilter => SongQueryFilter.artistName)
                .NotNull()
                .WithMessage("artistName can't be null")
                .MinimumLength(3)
                .WithMessage("artistName minimum length 3");

            RuleFor(SongQueryFilter => SongQueryFilter.pageNumber)
                .NotNull()
                .WithMessage("pageNumber can't be null");

            RuleFor(SongQueryFilter => SongQueryFilter.pageSize)
                .NotNull()
                .WithMessage("pageSize can't be null");
        }
    }
}