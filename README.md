# JobTracker API

A modern .NET 10 Web API demonstrating clean architecture, background processing, and containerization.

**Built by a developer with 10+ years of experience to showcase current .NET ecosystem knowledge.**

## What This Project Demonstrates

- ✅ .NET 10 Minimal APIs
- ✅ Entity Framework Core with PostgreSQL
- ✅ Background job processing with hosted services
- ✅ MassTransit for message-based architecture
- ✅ Docker & Docker Compose
- ✅ Clean Architecture principles
- ✅ Repository pattern with Unit of Work
- ✅ Structured logging with Serilog

## The Domain

A job application tracking system:
- Track job applications (company, position, status, dates)
- Automatic follow-up reminders via background worker
- Application status workflow (Applied → Interview → Offer/Rejected)


## Architecture

## Quick Start

```bash
# Clone and run
docker-compose up -d

# API available at
http://localhost:5000/swagger
```


## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|

## Project Structure

```
JobTracker/
├── src/
├── tests/
├── docker-compose.yml
└── README.md
```

## Tech Stack

- .NET 10
- Entity Framework Core 
- PostgreSQL 
- RabbitMQ 
- MassTransit 
- Serilog
- Docker

## Building Locally

```bash
# Restore and build
dotnet restore
dotnet build

# Run tests
dotnet test

# Run API (requires PostgreSQL and RabbitMQ running)
cd src/JobTracker.Api
dotnet run
```

## Why This Architecture?

1. **Separation of API and Worker**: Shows understanding of bounded responsibilities
2. **Message-based communication**: Decoupled components, scalable pattern
3. **Repository pattern**: Testable data access, not married to EF Core
4. **Docker Compose**: Production-ready local development

## Author

Alex (Amirali) Delpisheh

## License

AGPLv3
