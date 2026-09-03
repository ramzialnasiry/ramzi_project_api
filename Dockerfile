
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# انسخ ملف المشروع واجرِ restore
COPY ["ramzi_project_api.csproj", "./"]
RUN dotnet restore "ramzi_project_api.csproj"

# انسخ باقي الملفات وابنِ التطبيق
COPY . .
RUN dotnet publish "ramzi_project_api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# انسخ من مرحلة البناء
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "ramzi_project_api.dll"]
