# Use an official Node.js runtime as a parent image
FROM node:20 AS build
WORKDIR /frontend

# Copy only package.json and package-lock.json to leverage Docker cache for dependencies
COPY frontend/package.json .
COPY frontend/package-lock.json .
RUN npm install --silent
RUN npm install react-scripts -g --silent

# Copy the rest of the app's files
COPY frontend/ .

# Build the React application
RUN npm run build

# Use a lightweight web server to serve the build files
FROM nginx:alpine
COPY --from=build /frontend/build /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
