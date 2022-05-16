FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MovieStore.csproj", "."]
RUN dotnet restore "./MovieStore.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MovieStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieStore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieStore.dll"]