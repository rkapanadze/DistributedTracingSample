FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
CMD ["dotnet", "watch", "--no-hot-reload", "run", "--urls=http://0.0.0.0:5000"]

FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ServiceA.API/ServiceA.API.csproj", "ServiceA.API/"]
RUN dotnet restore "ServiceA.API/ServiceA.API.csproj"
COPY . .
WORKDIR "/src/ServiceA.API"
RUN dotnet build "ServiceA.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ServiceA.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceA.API.dll"]
