FROM mcr.microsoft.com/dotnet/sdk:6.0 AS watch
WORKDIR /app
COPY . /app
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]