# Description

ASP.NET core web app showing how to use MongoDb from C#.

It stores TO DO items in a Mongo database and has Razor pages for CRUD operations.

Run MongoDb in a docker container using this command

    docker run -it -p 27017:27017 --name mongodb --rm -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=password1234 mongo

See also
* https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-7.0&tabs=visual-studio