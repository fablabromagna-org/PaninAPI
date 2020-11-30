FROM mcr.microsoft.com/dotnet/core/sdk:3.1.404-alpine3.12 AS build-env
WORKDIR /app
EXPOSE 80

# Copy csproj and restore as distinct layers
COPY ./PaninApi.sln ./PaninApi.sln
COPY ./src/PaninApi.Abstractions/PaninApi.Abstractions.csproj ./src/PaninApi.Abstractions/PaninApi.Abstractions.csproj
COPY ./src/PaninApi.WebApi/PaninApi.WebApi.csproj ./src/PaninApi.WebApi/PaninApi.WebApi.csproj
COPY ./tests/PaninApi.Tests.WebApi/PaninApi.Tests.WebApi.csproj ./tests/PaninApi.Tests.WebApi/PaninApi.Tests.WebApi.csproj
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish "./src/PaninApi.Abstractions/PaninApi.Abstractions.csproj" -c Release -o out
RUN dotnet publish "./src/PaninApi.WebApi/PaninApi.WebApi.csproj" -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.10-alpine3.12
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PaninApi.WebApi.dll"]