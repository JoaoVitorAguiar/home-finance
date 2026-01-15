
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY HomeFinance.slnx ./

COPY HomeFinance.Api/HomeFinance.Api.csproj HomeFinance.Api/
COPY HomeFinance.Application/HomeFinance.Application.csproj HomeFinance.Application/
COPY HomeFinance.Core/HomeFinance.Core.csproj HomeFinance.Core/
COPY HomeFinance.Infra/HomeFinance.Infra.csproj HomeFinance.Infra/

RUN dotnet restore

COPY . .

WORKDIR /src/HomeFinance.Api
RUN dotnet publish -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "HomeFinance.Api.dll"]
