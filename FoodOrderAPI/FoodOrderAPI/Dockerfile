#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FoodOrderAPI/FoodOrderAPI.csproj", "FoodOrderAPI/"]
RUN dotnet restore "FoodOrderAPI/FoodOrderAPI.csproj"
COPY . .
WORKDIR "/src/FoodOrderAPI"
RUN dotnet build "FoodOrderAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodOrderAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodOrderAPI.dll"]