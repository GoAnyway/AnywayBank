#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Identity/IdentityApi/IdentityApi.csproj", "Identity/IdentityApi/"]
COPY ["Identity/IdentityCore/IdentityCore.csproj", "Identity/IdentityCore/"]
COPY ["Identity/Data/Data.csproj", "Identity/Data/"]
COPY ["Common/CommonData/CommonData.csproj", "Common/CommonData/"]
COPY ["Identity/DataManager/DataManager.csproj", "Identity/DataManager/"]
COPY ["Common/CommonDataManager/CommonDataManager.csproj", "Common/CommonDataManager/"]
COPY ["Common/CommonDatabase/CommonDatabase.csproj", "Common/CommonDatabase/"]
COPY ["Identity/Database/Database.csproj", "Identity/Database/"]
COPY ["Common/Core/Core.csproj", "Common/Core/"]
RUN dotnet restore "Identity/IdentityApi/IdentityApi.csproj"
COPY . .
WORKDIR "/src/Identity/IdentityApi"
RUN dotnet build "IdentityApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityApi.dll"]