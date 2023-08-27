# SharpCRUD 🧙👓✒️🆑
## A better way to structure your CRUD-project with validation.

**Pssst 🤫:** If you like this concept make sure to give it a star🌟

Have you ever struggled with how to structure your CRUD application? Well, me too. 
After countless hours spent on research i could not find and optimal solution that will scales well with the complexity.
There are many good concepts that showcase how to handle these simple operations, but as soon as the complexity and 
the models become increase, this for some reason seem to fail ⁉️

In this project i will try and fail until i find a suitable solution for my problems, and i hope that some will stuble over this
and maybe get some inspiration 😎

## How is this project structured?

### API - Backend
- The API should handle the domain/business logic
- The domain logic should be separated from the API gateway
- The gateway handles a http request and invokes domain logic

### Communication - Layer between frontend and backend
- Conserned with how the frontend should communicate with the API
- Could be published as a NuGet for api consumption

### Frontend
- Uses the communication-part to communicate/consume the API
- Simple frontend to showcase CRUD

## Whats the emojii's in the commits?
- 🔵 When i do some refactoring
- 🟢 When i have wrote a test that passes
- 🔴 When i have added code and tests fails

## How do i run this project?
First of you need to create a Microsoft SQL database.
When the database is configured you need to setup "secrets.json"-file in Visual Studio:
- You can do this by right-clicking the "SharpCRUD.RestAPI" project as follows:
![image](https://github.com/sebastiannordby/SharpCRUD/assets/24465003/43fbb2e3-2fd9-4e83-8d2a-e381ca168896)

The json file should look like this:
{
  "ConnectionStrings:DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DB_NAME;User Id=YOUR_DB_USERNAME;Password=YOUR_DB_PASS;MultipleActiveResultSets=false",
}

