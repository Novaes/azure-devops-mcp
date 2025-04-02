# Use the official .NET 8 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-ltsc2022 AS build
WORKDIR /app

# Copy the .csproj file from the parent directory and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application from the parent directory and build it
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET 8 runtime image to run the application
FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-ltsc2022 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Copy the configuration file to the output directory
COPY Properties/mcp.json ./Properties/mcp.json

# Expose the port the application runs on
EXPOSE 8081

# Output the contents of the configuration file to verify it was copied correctly
RUN type Properties\mcp.json

# Run the application
ENTRYPOINT ["dotnet", "azure-devops-mcp-client.dll"]