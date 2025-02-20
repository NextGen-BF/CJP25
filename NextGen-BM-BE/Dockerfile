FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5204/tcp 7261/tcp

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./NextGen-BM-BE/NextGen-BM-BE-API/NextGen-BM-BE-API.csproj", "./NextGen-BM-BE-API/"]
COPY ["./NextGen-BM-BE/NextGen-BM-BE-Domain/NextGen-BM-BE-Domain.csproj", "./NextGen-BM-BE-Domain/"]
COPY ["./NextGen-BM-BE/NextGen-BM-BE-Application/NextGen-BM-BE-Application.csproj", "./NextGen-BM-BE-Application/"]
COPY ["./NextGen-BM-BE/NextGen-BM-BE-Infrastructure/NextGen-BM-BE-Infrastructure.csproj", "./NextGen-BM-BE-Infrastructure/"]
RUN dotnet restore "./NextGen-BM-BE-API/NextGen-BM-BE-API.csproj"
# configure https
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust

COPY ./NextGen-BM-BE .
RUN dotnet build "./NextGen-BM-BE-API/NextGen-BM-BE-API.csproj" -c release -o /app/build

FROM build AS publish
RUN dotnet publish "./NextGen-BM-BE-API/NextGen-BM-BE-API.csproj" -c release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/

ENTRYPOINT ["dotnet", "NextGen-BM-BE-API.dll"]
