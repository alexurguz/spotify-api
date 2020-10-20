using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpotifyApi.Core.CustomEntities;
using SpotifyApi.Core.Exceptions;
using SpotifyApi.Core.Interfaces.ApiConsumer;
using SpotifyApi.Core.Interfaces.Repository;
using SpotifyApi.Core.Interfaces.UnitOfWork;
using SpotifyApi.Core.Interfaces.UseCase;
using SpotifyApi.Core.UseCase;
using SpotifyApi.Infrastructure.Data;
using SpotifyApi.Infrastructure.Filters;
using SpotifyApi.Infrastructure.Repositories;

namespace Spotify.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add AutoMapper for mapper DTOs with models
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(options => {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options => {

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;// Destroy loop reference in objects

            }).ConfigureApiBehaviorOptions(options => {
                // options.SuppressModelStateInvalidFilter = true;
            });
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));
            // Use the string connection configured on the appsettings.json
            services.AddDbContext<ApiSpotifyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApiSpotify"))
            );

            // Dependency Injection UseCase
            services.AddTransient<ISongUseCase, SongUseCaseImpl>();
            services.AddTransient<IApiMusicUseCase, ApiMusicUseCaseImpl>();

            // Dependency Injection Repository
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IApiMusicRepository, ApiMusicRepository>();
            services.AddTransient<ISongsArtistsRepository, SongsArtistsRepository>();

            // Dependency Injection UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Register a global filter for the controllers
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
