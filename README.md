# LoggingAPI

The LoggingAPI project is a scalable, containerized microservice application designed to collect, process, and store log messages. This guide provides step-by-step instructions on setting up and running the project.

## Overview

The LoggingAPI is constructed with a microservices architecture, encapsulating several key functionalities, including:

- **Data Collection**: Efficiently gathers log data from various sources.
- **Data Processing**: Processes the raw log data, extracting relevant information.
- **Data Storage**: Safely stores the processed log data in a PostgreSQL database.
- **Data Visualization**: Utilizes pgAdmin for a graphical interface to the database.
- **Scalability**: Uses Docker to containerize each service, allowing for easy scaling and deployment.

## Components

The primary components of the LoggingAPI include:

- `postgres_database`: A PostgreSQL container for storing log messages.
- `pgadmin`: A pgAdmin4 container providing a web interface for managing the PostgreSQL database.
- `proxy`: A service that utilizes YARP to LoadBalance and proxy HTTP requests.
- `app1` to `app5`: Multiple instances of the LoggingAPI application for scalability.

## Getting Started

### Prerequisites

1. Install [Docker](https://www.docker.com/products/docker-desktop) and Docker Compose.
2. Clone the project repository to your local machine.

### Running the Project

1. Navigate to the project root directory in your terminal.
2. Use the command `docker-compose up` to start all the services defined in `docker-compose.yml`.
3. Once all services are up and running, you can access:
   - The logging API at: `http://localhost:5000`.
   - The pgAdmin interface at: `http://localhost:8887`.

### Stopping the Project

1. In your terminal, press `Ctrl + C` to stop the running services.
2. If necessary, use the command `docker-compose down` to remove all the services.

### Using Logging API

1. **Create Log Messages Endpoint**:
   - To create log messages, send a POST request to `http://localhost:5000/Logs/create`.
   - The request body should be in the following format:
   ```json
   [
      {
        "application": "string",
        "logDate": "DateTime",
        "message": "string"
      }
   ]


### pgAdmin4 Instructions

1. **Log In**:
   - Access the pgAdmin4 interface at `http://localhost:8887`
   - Username: `user-name@domain-name.com`
   - Password: `strong-password`
   
![Screenshot (562)](https://github.com/HristoShabanakov/LoggingAPI/assets/32416999/2bbf3679-7619-4f84-964c-f100a8b67a36)

2. **Create Server**:
   - Click on the `Add New Server` icon in the `Quick Links` section.
     
     ![Screenshot (563)](https://github.com/HristoShabanakov/LoggingAPI/assets/32416999/a7c886fa-a59b-4fd4-9364-c093482d0c5c)

   - In the `General` tab, name your server.
     
     ![Screenshot (564)](https://github.com/HristoShabanakov/LoggingAPI/assets/32416999/bf6cc5ac-9e0a-4fc4-888d-abdf5295a6ca)

   - In the `Connection` tab:
     - Enter `postgres_database` as the `Hostname/Address`.
     - Use `5432` as the port.
     - Username: `user`
     - Password: `password`
     - Click the "Save" button.
    
     ![Screenshot (565)](https://github.com/HristoShabanakov/LoggingAPI/assets/32416999/675cf79f-d9c5-44bb-a798-da3fe439354e)


