# Etapa 1: Build de Angular
FROM node:20 AS build

# Crear directorio de trabajo
WORKDIR /app

# Copiar package.json e instalar dependencias
COPY package*.json ./
RUN npm install

# Copiar el resto del proyecto
COPY . .

# Compilar la aplicación Angular (ajusta el nombre según tu proyecto)
RUN npm run build -- --configuration=production

# Etapa 2: Servir con Nginx
FROM nginx:stable-alpine

# Copiar la build generada a la carpeta de Nginx
COPY --from=build /app/dist/my-angular-app /usr/share/nginx/html

# Copiar un archivo custom de configuración si lo deseas
# COPY nginx.conf /etc/nginx/conf.d/default.conf

# Exponer el puerto
EXPOSE 80

# Comando por defecto
CMD ["nginx", "-g", "daemon off;"]
