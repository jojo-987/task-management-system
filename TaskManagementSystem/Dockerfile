FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY Application.sln ./

COPY Application.Api/*.csproj ./Application.Api/

COPY Application.AppService/*.csproj ./Application.AppService/

COPY Application.Infrastructure/*.csproj ./Application.Infrastructure/

RUN dotnet restore

COPY . .

RUN dotnet build ./Application.Api/*.csproj -c Release -o /app/build

FROM build AS publish

RUN dotnet publish ./Application.Api/*.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=3000

COPY --from=publish /app/publish .

EXPOSE 3000

ENTRYPOINT ["dotnet","Application.Api.dll"]
