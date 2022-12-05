FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SmithTrade/SmithTrade.csproj", "SmithTrade/"]
RUN dotnet restore "SmithTrade/SmithTrade.csproj"
COPY . .
WORKDIR "/src/SmithTrade"
RUN dotnet build "SmithTrade.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmithTrade.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmithTrade.dll"]
