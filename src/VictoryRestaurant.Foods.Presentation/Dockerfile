FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
WORKDIR /src
COPY ["src/VictoryRestaurant.Foods.Presentation", "VictoryRestaurant.Foods.Presentation/"]
RUN dotnet restore "VictoryRestaurant.Foods.Presentation/VictoryRestaurant.Foods.Presentation.csproj"
COPY . .

WORKDIR "/src/VictoryRestaurant.Foods.Presentation"
RUN dotnet build "VictoryRestaurant.Foods.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VictoryRestaurant.Foods.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VictoryRestaurant.Foods.Presentation.dll"]