#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs
run apt-get install gcc -y


COPY ["Twitter Auto  Alt Text/Twitter Auto  Alt Text.csproj", "Twitter Auto  Alt Text/"]
RUN dotnet restore "Twitter Auto  Alt Text/Twitter Auto  Alt Text.csproj"
COPY . .
WORKDIR "/src/Twitter Auto  Alt Text"
RUN dotnet build "Twitter Auto  Alt Text.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Twitter Auto  Alt Text.csproj" -c Release -o /app/publish

run apt-get install -y libgif7 libjpeg62 libopenjp2-7 libpng16-16 libtiff5 libwebp6
run apt update

run apt install libleptonica-dev -y

run apt install libtesseract-dev -y
WORKDIR /app/x64
run ln -s /usr/lib/x86_64-linux-gnu/liblept.so.5 liblept1753.so
run ln -s /usr/lib/x86_64-linux-gnu/libtesseract.so.4.0.1 libtesseract3052.so
# install System.Drawing native dependencies
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*
run ln -s /lib/x86_64-linux-gnu/libdl.so.2 /lib/x86_64-linux-gnu/libdl.so
run apt install libgdiplus
run ln -s /usr/lib/libgdiplus.so /lib/x86_64-linux-gnu/libgdiplus.so
RUN apt-get update \
    && apt-get install -y --no-install-recommends libc6-dev

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
WORKDIR /app/x64
run ln -s /usr/lib/x86_64-linux-gnu/liblept.so.5 liblept1753.so
run ln -s /usr/lib/x86_64-linux-gnu/libtesseract.so.4.0.1 libtesseract3052.so

workdir /app
ENTRYPOINT ["dotnet", "Twitter Auto  Alt Text.dll"]




