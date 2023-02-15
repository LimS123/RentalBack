#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Arenda.WebAPI/Arenda.WebAPI.csproj", "src/Arenda.WebAPI/"]
COPY ["src/Arenda.BusinessLogic/Arenda.BusinessLogic.csproj", "src/Arenda.BusinessLogic/"]
COPY ["src/Arenda.DataAccess/Arenda.DataAccess.csproj", "src/Arenda.DataAccess/"]
RUN dotnet restore "src/Arenda.WebAPI/Arenda.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Arenda.WebAPI"
RUN dotnet build "Arenda.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Arenda.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Arenda.WebAPI.dll"]