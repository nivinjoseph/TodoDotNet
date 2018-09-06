FROM node:8

LABEL maintainer="nivinjoseph@outlook.com"

RUN apt-get update && apt-get install -y \
    nasm \
    && rm -rf /var/lib/apt/lists/*

RUN mkdir /app

COPY . /app

WORKDIR /app

RUN npm install

ENV env=prod

RUN npm run build

EXPOSE 4000

ENTRYPOINT ["npm", "run", "start"]