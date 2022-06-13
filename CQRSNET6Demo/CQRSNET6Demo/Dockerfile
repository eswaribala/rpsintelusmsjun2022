#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CQRSNET6Demo/CQRSNET6Demo.csproj", "CQRSNET6Demo/"]
RUN dotnet restore "CQRSNET6Demo/CQRSNET6Demo.csproj"
COPY . .
WORKDIR "/src/CQRSNET6Demo"
RUN dotnet build "CQRSNET6Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRSNET6Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRSNET6Demo.dll"]