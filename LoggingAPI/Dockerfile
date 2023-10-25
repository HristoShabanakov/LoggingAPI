# Use the official .NET 6.0 runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET 6.0 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./LoggingAPI/*.csproj ./
RUN dotnet restore

# Copy wait-for-it script into the image at this stage because we have the necessary tools to set permissions
COPY ./LoggingAPI/wait-for-it.sh .
RUN chmod +x wait-for-it.sh

COPY ./LoggingAPI/ ./
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /src/wait-for-it.sh .
COPY --from=publish /app/publish .

# Change the ENTRYPOINT to use wait-for-it before starting the application
ENTRYPOINT ["/app/wait-for-it.sh", "postgres_database:5432", "--", "dotnet", "LoggingAPI.dll"]
