#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Esis.Shin/Esis.Shin.csproj", "Esis.Shin/"]
COPY ["Esis.Shin.Services.Administrations/Esis.Shin.Services.Administrations.csproj", "Esis.Shin.Services.Administrations/"]
COPY ["Esis.Shin.Core/Esis.Shin.Core.csproj", "Esis.Shin.Core/"]
RUN dotnet restore "Esis.Shin/Esis.Shin.csproj"
COPY . .
WORKDIR "/src/Esis.Shin"
RUN dotnet build "Esis.Shin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Esis.Shin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Esis.Shin.dll"]