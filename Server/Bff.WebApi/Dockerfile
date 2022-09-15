#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Bff.WebApi/Bff.WebApi.csproj", "Bff.WebApi/"]
COPY ["Bff.WebApi.Administrations/Bff.WebApi.Services.Administrations.csproj", "Bff.WebApi.Administrations/"]
COPY ["Bff.Core/Bff.Core.csproj", "Bff.Core/"]
RUN dotnet restore "Bff.WebApi/Bff.WebApi.csproj"
COPY . .
WORKDIR "/src/Bff.WebApi"
RUN dotnet build "Bff.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bff.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bff.WebApi.dll"]