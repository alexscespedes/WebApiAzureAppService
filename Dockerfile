FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

RUN adduser --disabled-password --gecos "" appuser
WORKDIR /app

COPY --from=build /app/publish .

RUN chown -R appuser:appuser /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT [ "dotnet", "WebApiAzureAppService.dll" ]