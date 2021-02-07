#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ApiToApi_consul.ApiGateway/ApiToApi_consul.ApiGateway.csproj", "ApiToApi_consul.ApiGateway/"]
RUN dotnet restore "ApiToApi_consul.ApiGateway/ApiToApi_consul.ApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiToApi_consul.ApiGateway"
RUN dotnet build "ApiToApi_consul.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiToApi_consul.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiToApi_consul.ApiGateway.dll"]