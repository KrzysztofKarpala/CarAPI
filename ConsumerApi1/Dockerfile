#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConsumerApi1/ConsumerApi1.csproj", "ConsumerApi1/"]
RUN dotnet restore "ConsumerApi1/ConsumerApi1.csproj"
COPY . .
WORKDIR "/src/ConsumerApi1"
RUN dotnet build "ConsumerApi1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsumerApi1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsumerApi1.dll"]