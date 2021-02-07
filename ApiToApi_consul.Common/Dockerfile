#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ApiToApi_consul.Common/ApiToApi_consul.Common.csproj", "ApiToApi_consul.Common/"]
RUN dotnet restore "ApiToApi_consul.Common/ApiToApi_consul.Common.csproj"
COPY . .
WORKDIR "/src/ApiToApi_consul.Common"
RUN dotnet build "ApiToApi_consul.Common.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiToApi_consul.Common.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiToApi_consul.Common.dll"]