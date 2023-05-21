#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebPlus/WebPlus.csproj", "WebPlus/"]
RUN dotnet restore "WebPlus/WebPlus.csproj"
COPY . .
WORKDIR "/src/WebPlus"
RUN dotnet build "WebPlus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebPlus.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebPlus.dll"]