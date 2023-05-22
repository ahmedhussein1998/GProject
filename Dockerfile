# Build Image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app    

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Gproject/Gproject.Api/*.csproj ./Gproject/Gproject.Api/
COPY Gproject/Gproject.Application/*.csproj ./Gproject/Gproject.Application/
COPY Gproject/Gproject.Contracts/*.csproj ./Gproject/Gproject.Contracts/
COPY Gproject/Gproject.Domain/*.csproj ./Gproject/Gproject.Domain/
COPY Gproject/Gproject.Infrastructure/*.csproj ./Gproject/Gproject.Infrastructure/
RUN dotnet restore

# Copy everything else and build app
COPY . .
WORKDIR /app/Gproject/Gproject.Api
RUN dotnet publish -c Release -o out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/Gproject/Gproject.Api/out ./
ENTRYPOINT ["dotnet", "Gproject.Api.dll"]