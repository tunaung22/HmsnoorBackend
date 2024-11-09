# README

  API Backend for Hmsnoor sale module

## Instructions

### .env

    DB_NAME=[database name]
    DB_USER=[databaes username]
    DB_PASSWORD=[database password]

## Dev Docs

### Error Codes

Custom error codes for error log and tracking

Generic

- E5001 Internal Server Error (default)
- E5008 Server Not Starting ?

Client Related

- E2000 Not Found
- E2001 KeyNotFoundException
- E2000 Key
- E2040 Bad Request
- E2041 Access Denied
- E2042 Unauthorized
-

Database Related

- E8000 Unable to Connect to Database
- E8010 DbUpdateConcurrencyException
- E8020 Database Operation Error DbUpdateException

Uncategorized

- Invalid JSON object
- Missing Accept header
- Invalid payload
- Invalid Content-Type
- Request Content-Type Not Supported
-
