ARG DOTNET_VERSION=10.0
ARG BUILD_CONFIGURATION=Release

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

WORKDIR /src
COPY ["API/", "API/"]
COPY ["Application/", "Application/"]
COPY ["Domain/", "Domain/"]
COPY ["Infrastructure/", "Infrastructure/"]

WORKDIR /src/API
RUN dotnet restore "API.csproj"
RUN dotnet publish "API.csproj" \
  --configuration ${BUILD_CONFIGURATION} \
  --no-restore \
  --output /publish

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime

WORKDIR /app
COPY --from=build /publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "API.dll"]