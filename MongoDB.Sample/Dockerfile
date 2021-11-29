#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MongoDB.Sample/MongoDB.Sample.csproj", "MongoDB.Sample/"]
RUN export http_proxy=http://proxy.fpts.com.vn:8080 \
	&& export https_proxy=http://proxy.fpts.com.vn:8080 \
	&& dotnet restore "MongoDB.Sample/MongoDB.Sample.csproj"
COPY . .
WORKDIR "/src/MongoDB.Sample"
RUN dotnet build "MongoDB.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MongoDB.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoDB.Sample.dll"]