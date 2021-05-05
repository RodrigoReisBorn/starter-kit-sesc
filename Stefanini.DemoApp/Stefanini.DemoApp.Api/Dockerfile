#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Stefanini.DemoApp.Api/Stefanini.DemoApp.Api.csproj", "Stefanini.DemoApp.Api/"]
COPY ["Shared/Stefanini.Web/Stefanini.Web.csproj", "Shared/Stefanini.Web/"]
COPY ["Shared/Stefanini.Common/Stefanini.Common.csproj", "Shared/Stefanini.Common/"]
COPY ["Stefanini.DemoApp.CrossCutting/Stefanini.DemoApp.CrossCutting.csproj", "Stefanini.DemoApp.CrossCutting/"]
COPY ["Shared/Stefanini.Log/Stefanini.Log.csproj", "Shared/Stefanini.Log/"]
COPY ["Stefanini.DemoApp.Infrastructure.Data/Stefanini.DemoApp.Infrastructure.Data.csproj", "Stefanini.DemoApp.Infrastructure.Data/"]
COPY ["Shared/Stefanini.Repository.NHibernate/Stefanini.Repository.NHibernate.csproj", "Shared/Stefanini.Repository.NHibernate/"]
COPY ["Shared/Stefanini.Domain/Stefanini.Domain.csproj", "Shared/Stefanini.Domain/"]
COPY ["Shared/Stefanini.Repository/Stefanini.Repository.csproj", "Shared/Stefanini.Repository/"]
COPY ["Stefanini.DemoApp.Domain/Stefanini.DemoApp.Domain.csproj", "Stefanini.DemoApp.Domain/"]
COPY ["Shared/Stefanini.Business/Stefanini.Business.csproj", "Shared/Stefanini.Business/"]
RUN dotnet restore "Stefanini.DemoApp.Api/Stefanini.DemoApp.Api.csproj"
COPY . .
WORKDIR "/src/Stefanini.DemoApp.Api"
RUN dotnet build "Stefanini.DemoApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stefanini.DemoApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stefanini.DemoApp.Api.dll"]
