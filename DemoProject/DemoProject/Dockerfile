#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DemoProject/DemoProject.csproj", "DemoProject/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Servers/Services.csproj", "Servers/"]
COPY ["UnitTest/UnitTest.csproj", "UnitTest/"]
RUN dotnet restore "DemoProject/DemoProject.csproj"
COPY . .
RUN dotnet test UnitTest/UnitTest.csproj

WORKDIR "/src/DemoProject"
RUN apt-get update && apt-get install -y openjdk-11-jdk
RUN dotnet tool install dotnet-sonarscanner --global
ENV PATH="${PATH}:/root/.dotnet/tools"
# analyze using SQ
RUN dotnet sonarscanner begin  /o:"socbaymau" \
  /k:"socbaymau_DemoUnitTest" \
  /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="52a4c5132f5759eea29e190d8fe067f1de089eab"
RUN dotnet build -c Release -o out --no-restore
#RUN dotnet build "DemoProject.csproj" -c Release -o /app/build
RUN dotnet sonarscanner end /d:sonar.login="52a4c5132f5759eea29e190d8fe067f1de089eab"

#RUN dotnet test "DemoProject.csproj" --logger "trx;LogFileName=webapplication1.trx" 
FROM build AS publish
RUN dotnet publish "DemoProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoProject.dll"]