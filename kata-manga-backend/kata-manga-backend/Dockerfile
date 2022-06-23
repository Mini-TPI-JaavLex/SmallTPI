FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5225
EXPOSE 5225

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./*.csproj ./
RUN dotnet restore
COPY . .
WORKDIR "/src/"
RUN dotnet build "kata-manga-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "kata-manga-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "kata-manga-backend.dll"]
