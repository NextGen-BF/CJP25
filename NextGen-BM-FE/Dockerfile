FROM node:latest

WORKDIR /app
COPY ["./NextGen-BM-FE/package.json", "./"]
RUN npm install

COPY ./NextGen-BM-FE ./

ENTRYPOINT ["npm", "run", "dev"]
