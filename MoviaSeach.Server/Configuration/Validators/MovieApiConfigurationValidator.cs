namespace MovieSearch.Server.Configuration.Validators
{
    using FluentValidation;
    /// <summary>
    /// Movie api configuration validator
    /// </summary>
    public class MovieApiConfigurationValidator : AbstractValidator<MovieApiConfiguration>
    {
        public MovieApiConfigurationValidator()
        {
            RuleFor(x => x.ServiceUrl)
                .NotEmpty()
                .WithMessage($"Movie api {nameof(MovieApiConfiguration.ServiceUrl)} missing!");
            RuleFor(x => x.ApiKey)
                .NotEmpty()
                .WithMessage($"Movie api {nameof(MovieApiConfiguration.ApiKey)} missing!");

        }
    }
}
