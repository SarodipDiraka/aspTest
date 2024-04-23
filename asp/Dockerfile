FROM mrc.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mrc.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["asp/asp.csproj", "asp/"]
RUN dotnet restore "asp/asp.csproj"
COPY . .
WORKDIR "/src/asp"
RUN dotnet build "asp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "asp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet",  "asp.dll"]