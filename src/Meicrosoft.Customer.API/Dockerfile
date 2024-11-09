FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

RUN apt-get update && apt-get install -y clang gcc

COPY ["Meicrosoft.Customer.API/Meicrosoft.Customer.API.csproj", "Meicrosoft.Customer.API/"]
COPY ["Meicrosoft.Customer.Application/Meicrosoft.Customer.Application.csproj", "Meicrosoft.Customer.Application/"]
COPY ["Meicrosoft.Customer.Domain/Meicrosoft.Customer.Domain.csproj", "Meicrosoft.Customer.Domain/"]
COPY ["Meicrosoft.Customer.IoC/Meicrosoft.Customer.IoC.csproj", "Meicrosoft.Customer.IoC/"]
COPY ["Meicrosoft.Customer.Infra/Meicrosoft.Customer.Infra.csproj", "Meicrosoft.Customer.Infra/"]
RUN dotnet restore "Meicrosoft.Customer.API/Meicrosoft.Customer.API.csproj"

COPY . .

WORKDIR "/src/Meicrosoft.Customer.API"
RUN dotnet build "Meicrosoft.Customer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Meicrosoft.Customer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:PublishAot=true /p:PublishTrimmed=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./Meicrosoft.Customer.API"]
