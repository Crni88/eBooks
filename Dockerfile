# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["eBooks.csproj", "."]
RUN dotnet restore "./eBooks.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "eBooks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eBooks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/mssql/server:2017-latest AS database
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourStrongPassword123
ENV MSSQL_PID=Developer
EXPOSE 1433

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=database / .
ENTRYPOINT ["dotnet", "eBooks.dll"]
