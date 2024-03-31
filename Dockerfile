FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build the application
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:7.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the published output from the build stage into the final stage
COPY --from=build /app/out ./

# Set the entry point for the container
ENTRYPOINT ["dotnet", "ComputeUtility.dll"]