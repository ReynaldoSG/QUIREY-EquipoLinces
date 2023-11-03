# Stage 1
FROM mcr.microsoft.com/dotnet/sdk:5.0.302 AS build-env
WORKDIR /src
COPY  marcatel-api.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app

# Stage 2


FROM mcr.microsoft.com/dotnet/aspnet:5.0.8 
WORKDIR /app
COPY --from=build-env /app .

# ENTRYPOINT ["dotnet", "marcatel-api.dll"]
# Use the following instead for Heroku
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /usr/lib/ssl/openssl.cnf

CMD ASPNETCORE_URLS=http://*:$PORT dotnet marcatel-api.dll