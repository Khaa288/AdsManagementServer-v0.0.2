# Ads-Management-Server
AdsManagement is a tools for helping offices of each disticts, wards can manage their advertisement billboard activities. Following the clean architecture (Domain driven design principle) and modular monolith architecture.

## Features
- API services for advertisement points, boards management.
- API services for reports actions (request, resolve, reject,...).
- API services for licensing actions with external companies.

## Usage
**Prerequisite**
- NodeJS and NPM are installed if not install [here](https://nodejs.org/en/download)
- .NET SDK 8.0 is installed if not install [here](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks) 
- Entity Framework Core Tool is installed if not install [here](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- Registered MapTiler account and API KEY if not create account and get free API KEY [here](https://cloud.maptiler.com/auth/widget?next=https://cloud.maptiler.com/maps/)

## Configuring
Configure `appsetting.json` in **AdsManagement.API** similar to below format

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Databases": {
    "AuthModuleDb": {
      "Sql": {
        "ConnectionString": "YOUR_CONNECTION_STRING_HERE"
      },
      "NoSql": {
        "Redis": {
          "ConnectionString": "YOUR_CONNECTION_STRING_HERE"
        }
      }
    },
    "AdvertisementModuleDb": {
      "NoSql": {
        "MongoDb": {
          "ConnectionString": "YOUR_CONNECTION_STRING_HERE",
          "DatabaseName": "YOUR_CONNECTION_STRING_HERE"
        }
      }
    },
    "ReportModuleDb": {
      "Sql": {
        "ConnectionString": "YOUR_CONNECTION_STRING_HERE"
      },
      "NoSql": {
        "Redis": {
          "ConnectionString": "YOUR_CONNECTION_STRING_HERE"
        }
      }
    },
    "LicensingModuleDb": {
      "Sql": {
        "ConnectionString": "YOUR_CONNECTION_STRING_HERE"
      },
      "NoSql": {
        "Redis": {
          "ConnectionString": "YOUR_CONNECTION_STRING_HERE"
        }
      }
    }
  },
  "Jwt": {
    "Issuer": "YOUR_ISSUER_HERE",
    "Audience": "YOUR_AUDIENCE_HERE",
    "Key": "YOU_JWT_KEY_HERE"
  },
  "EventBus": {
    "HostName": "YOUR_EVENT_BUS_HOST_HERE",
    "Username": "YOUR_EVENT_BUS_USERNAME_HERE",
    "Password": "YOUR_EVENT_BUS_PASSWORD_HERE"
  }
}
```

## Libraries & patterns applied
- AutoFac: as an IoC container
- JwtBearer: support authentication, authorization with Bearer Tokens
- FluentValidation: validate request input data
- EntityFramework Core: support relational database actions
- MongoDb Driver: support document database (MongoDb) actions
- Masstransit: simplify pub-sub events with RabbitMq
- MediatR: applied mediator design pattern into codebase
- Repository and UnitOfWork: abstract methods to work with RDBMS
