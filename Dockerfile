FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TestPollyApi/TestPollyApi.csproj", "TestPollyApi/"]
RUN dotnet restore "TestPollyApi/TestPollyApi.csproj"
COPY . .
WORKDIR "/src/TestPollyApi"
RUN dotnet build "TestPollyApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestPollyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestPollyApi.dll"]