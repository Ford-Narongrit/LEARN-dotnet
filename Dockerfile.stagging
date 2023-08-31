FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /App

# copy csproj and restore as distinct layers
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /App
COPY --from=build /App/out ./
CMD ["dotnet", "WebApi.dll"]
