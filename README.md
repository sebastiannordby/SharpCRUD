# SharpCRUD
A better way to structure your CRUD-project.

## This project consist of three parts:
- API
- Communication/Consumption
- Frontend

### API
- The API should handle the domain/business logic
- The domain logic should be separated from the API gateway
- The gateway handles a http request and invokes domain logic

## Communication/Consumption
- Conserned with how the frontend should communicate with the API
- Could be published as a NuGet for api consumption

## Frontend
- Uses the communication-part to communicate/consume the API
- Simple frontend to showcase CRUD
