FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GraphQL.NET/GraphQLProductApp.csproj", "GraphQL.NET/"]
RUN dotnet restore "GraphQL.NET/GraphQLProductApp.csproj"
COPY . .
WORKDIR "/src/GraphQL.NET"
RUN dotnet build "GraphQLProductApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQLProductApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:8000
EXPOSE 8000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQLProductApp.dll"]
