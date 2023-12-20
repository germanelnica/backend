FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# copying the csproj and compile 
COPY *.csproj ./
RUN dotnet restore

#copy the result to my localfile of my new container. to publish to my folder
COPY . ./
RUN dotnet publish -c Release -o out

# Create a new build image, only taking the publish outcome
FROM mcr.microsoft.com/dotnet/sdk:8.0 as final-env
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DemoApp.dll"]