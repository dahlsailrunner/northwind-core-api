# Northwind API Sampler
This project is meant to enable exploration and comparison 
between different API technologies within ASP.NET Core:

* REST / JSON 
* GraphQL
* gRPC

## Running the project 
### Setting up the Postgres database (easy)
It references a localhost instance of Postgres containing the Northwind database.

If you have Docker desktop installed, the repo below has some instructions on getting the database set up.
https://github.com/dahlsailrunner/northwind_psql

Windows:
```
docker volume create --name northwind-pg-data -d local
docker-compose -f .\docker-compose-windows.yml up
```

Mac:
You'll need to have a Docker compose file that exposes port 5432 like the windows one does.
If you want to simply use the Windows one, the above commands should work.  If you don't want
to create the external volume, then modify the existing `docker-compose.yml` file 
and add the section for `ports` like the Windows file does.  

Then simply run:
```
docker-compose up
```
### Running the API
Clone the repo and build it, then run.

It should open a browser to the Home page, with links across the top for the Swagger interface and the GraphQL playground.

