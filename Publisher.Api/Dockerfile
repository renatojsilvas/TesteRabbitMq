FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Publisher.Api/Publisher.Api.csproj", "Publisher.Api/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Publisher.Api/Publisher.Api.csproj"
COPY . .
WORKDIR "/src/Publisher.Api"
RUN dotnet build "Publisher.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Publisher.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Publisher.Api.dll"]