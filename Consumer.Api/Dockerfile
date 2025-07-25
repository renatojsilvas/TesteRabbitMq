FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Consumer.Api/Consumer.Api.csproj", "Consumer.Api/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Consumer.Api/Consumer.Api.csproj"
COPY . .
WORKDIR "/src/Consumer.Api"
RUN dotnet build "Consumer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Consumer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consumer.Api.dll"]