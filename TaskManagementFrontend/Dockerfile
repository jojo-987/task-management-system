FROM node:25-alpine AS build

WORKDIR /app

COPY package*.json .

RUN npm i

COPY . . 

EXPOSE 5173

CMD ["npm","run","dev"]
