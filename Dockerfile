FROM microsoft/dotnet:2.2-sdk

LABEL maintainer="nivinjoseph@outlook.com"

RUN mkdir /app

COPY . /app

WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production

RUN dotnet restore ./TodoDomain && \
    dotnet build ./TodoDomain -c Release && \
    dotnet restore ./TodoData && \
    dotnet build ./TodoData -c Release && \
    dotnet restore ./TodoApi && \
    dotnet build ./TodoApi -c Release

EXPOSE 5000

ENTRYPOINT [ "dotnet", "run", "-c", "Release", "--launch-profile", "TodoApiProd", "-p", "./TodoApi/TodoApi.csproj" ]