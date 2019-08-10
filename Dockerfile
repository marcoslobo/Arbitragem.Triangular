FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Arbitragem.Triangular/Arbitragem.Triangular.csproj", "Arbitragem.Triangular/"]
RUN dotnet restore "Arbitragem.Triangular/Arbitragem.Triangular.csproj"
COPY . .
WORKDIR "/src/Arbitragem.Triangular"
RUN dotnet build "Arbitragem.Triangular.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Arbitragem.Triangular.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Arbitragem.Triangular.dll"]