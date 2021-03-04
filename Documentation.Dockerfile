# build .dll files for docfx to inspect
FROM mcr.microsoft.com/dotnet/sdk:5.0.102-alpine3.12-amd64 AS code-env

WORKDIR /app

COPY . .

RUN dotnet publish -o ./.build src/FileShare.API

# build docs with docfx using mono
FROM mono as docs-env

RUN apt update && apt install -y unzip wget

WORKDIR /tools

RUN wget https://github.com/dotnet/docfx/releases/download/v2.56.7/docfx.zip

RUN unzip docfx.zip -d ./docfx

WORKDIR /build

COPY --from=code-env /app/.build .build

COPY . .

RUN mono /tools/docfx/docfx.exe build docfx_project/docfx.json

# deploy using nginx for static file hosting
FROM nginx:latest

WORKDIR /var/www/html

COPY --from=docs-env /build/docfx_project/_site .

WORKDIR /etc/nginx/conf.d

COPY ./docfx_project/default.conf default.conf
