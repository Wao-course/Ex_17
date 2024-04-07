FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5100

ENV ASPNETCORE_URLS=http://+:5100

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Nozama.OrderOrchestratorService/Nozama.OrderOrchestratorService.csproj", "Nozama.OrderOrchestratorService/"]
RUN dotnet restore "Nozama.OrderOrchestratorService/Nozama.OrderOrchestratorService.csproj"
COPY . .
WORKDIR "/src/Nozama.OrderOrchestratorService"
RUN dotnet build "Nozama.OrderOrchestratorService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nozama.OrderOrchestratorService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nozama.OrderOrchestratorService.dll"]