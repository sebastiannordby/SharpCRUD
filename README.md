# SharpCRUD 🧙👓✒️🆑
## A better way to structure your CRUD-project with validation.

🌟🌟🌟**If you like this concept make sure to give it a star**🌟🌟🌟

Have you ever struggled with how to structure your CRUD application? Well, me too. 
After countless hours spent on research i could not find and optimal solution that will scales well with the complexity.
There are many good concepts that showcase how to handle these simple operations, but as soon as the complexity and 
the models become increase, this for some reason seem to fail ⁉️

In this project i will try and fail until i find a suitable solution for my problems, and i hope that some will stuble over this
and maybe get some inspiration 😎

## How do i run this project?
Coming soon...

## How is this project structured?

### API
- The API should handle the domain/business logic
- The domain logic should be separated from the API gateway
- The gateway handles a http request and invokes domain logic

### Communication/Consumption
- Conserned with how the frontend should communicate with the API
- Could be published as a NuGet for api consumption

### Frontend
- Uses the communication-part to communicate/consume the API
- Simple frontend to showcase CRUD

## How i commit for this project
- 🔵 When i do some refactoring
- 🟢 When i have wrote a test that passes
- 🔴 When i have added code and tests fails
