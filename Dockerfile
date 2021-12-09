# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything and build
COPY ./ ./
RUN dotnet publish ./WebAPI/ClubIS.WebAPI.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "ClubIS.WebAPI.dll"]
