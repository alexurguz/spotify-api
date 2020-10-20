FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY Spotify.Api/*.csproj ./Spotify.Api/
COPY SpotifyApi.Core/*.csproj ./SpotifyApi.Core/
COPY SpotifyApi.Infrastructure/*.csproj ./SpotifyApi.Infrastructure/
COPY SpotifyApi.Utilities/*.csproj ./SpotifyApi.Utilities/
#
RUN dotnet restore
#
# copy everything else and build app
COPY Spotify.Api/. ./Spotify.Api/
COPY SpotifyApi.Core/. ./SpotifyApi.Core/
COPY SpotifyApi.Infrastructure/. ./SpotifyApi.Infrastructure/
COPY SpotifyApi.Utilities/. ./SpotifyApi.Utilities/
#
WORKDIR /app/Spotify.Api
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build /app/Spotify.Api/out ./
ENTRYPOINT ["dotnet", "SpotifyApi.Api.dll"]