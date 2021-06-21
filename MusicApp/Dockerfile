#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
WORKDIR /app
EXPOSE 5000
EXPOSE 5001


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
RUN apt install -y nodejs
WORKDIR /src
COPY ["MusicApp/MusicApp.csproj", "MusicApp/"]
RUN dotnet restore "MusicApp/MusicApp.csproj"
COPY . .
WORKDIR "/src/MusicApp"
RUN dotnet build "MusicApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicApp.dll"]