FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KekMoneyApplication/KekMoneyApplication.csproj", "KekMoneyApplication/"]
RUN dotnet restore "KekMoneyApplication/KekMoneyApplication.csproj"
COPY . .
WORKDIR "/src/KekMoneyApplication"
RUN dotnet build "KekMoneyApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KekMoneyApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KekMoneyApplication.dll"]
