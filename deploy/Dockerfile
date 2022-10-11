FROM mcr.microsoft.com/dotnet/sdk:6.0.402-alpine3.16-amd64 AS build-env
WORKDIR /app
    
COPY /src .

RUN dotnet publish Expenses/Expenses.csproj -c Release -o out
    
FROM mcr.microsoft.com/dotnet/aspnet:6.0.10-alpine3.16-amd64
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Expenses.dll"]

