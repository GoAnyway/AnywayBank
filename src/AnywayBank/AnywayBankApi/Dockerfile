#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AnywayBank/AnywayBankApi/AnywayBankApi.csproj", "AnywayBank/AnywayBankApi/"]
COPY ["AnywayBank/AnywayBankCore/AnywayBankCore.csproj", "AnywayBank/AnywayBankCore/"]
COPY ["AnywayBank/Data/Data.csproj", "AnywayBank/Data/"]
COPY ["Common/CommonData/CommonData.csproj", "Common/CommonData/"]
COPY ["Common/CommonDataManager/CommonDataManager.csproj", "Common/CommonDataManager/"]
COPY ["Common/CommonDatabase/CommonDatabase.csproj", "Common/CommonDatabase/"]
COPY ["AnywayBank/DataManager/DataManager.csproj", "AnywayBank/DataManager/"]
COPY ["AnywayBank/Database/Database.csproj", "AnywayBank/Database/"]
COPY ["Common/Core/Core.csproj", "Common/Core/"]
RUN dotnet restore "AnywayBank/AnywayBankApi/AnywayBankApi.csproj"
COPY . .
WORKDIR "/src/AnywayBank/AnywayBankApi"
RUN dotnet build "AnywayBankApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnywayBankApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnywayBankApi.dll"]