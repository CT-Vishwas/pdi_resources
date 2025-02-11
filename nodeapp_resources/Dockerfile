FROM node:alpine

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the application code
COPY . .

# Expose the port
EXPOSE 3000

# Start the application
CMD ["node", "index.js"]