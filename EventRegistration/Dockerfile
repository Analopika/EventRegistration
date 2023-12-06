FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /app
EXPOSE 8080

#copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

#runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app 
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "EventRegistration.dll" ]