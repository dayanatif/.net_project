# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SoftwareSubscriptionApp.csproj", "./"]
RUN dotnet restore "SoftwareSubscriptionApp.csproj"

COPY . .
RUN dotnet build "SoftwareSubscriptionApp.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "SoftwareSubscriptionApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SoftwareSubscriptionApp.dll"]
