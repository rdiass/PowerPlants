## What does this service do?
Calculate how much power each of a multitude of different powerplants need to produce (a.k.a. the production-plan) when the load is given and taking into account the cost of the underlying energy sources (gas, kerosine) and the Pmin and Pmax of each powerplant.

## Running

### From Docker
To deploy and test this app using Docker, first you need to [install Docker in your machine](https://docs.docker.com/engine/installation/).

### Docker Command Line
On terminal navigate into the folder docker and use the following command:

```
$ docker-compose up --build --force-recreate
```

After that, try to access [http://localhost:8888/swagger/index.html](http://localhost:8888/swagger/index.html) with the application running.

### Visual Studio 2019

To run the app through Visual Studio. 

 - In Startup Project, select PowerPlants.Api. 
 - In Run, select PowerPlants.Api, press to run.

To run the app using Docker through Visual Studio. 

 - In Startup Project, select PowerPlants.Api. 
 - In Run, select Docker, press to run.

### Command Line
On terminal navigate into the PowerPlants.Api project and use the following command:

```
$ dotnet run
```

After that, try to access [https://localhost:8888/swagger/index.html](https://localhost:8888/swagger/index.html) with the application running.

## Testing

To test the endpoint /api/ProductionPlan

 - Click on "/api/ProductionPlan" on swagger main page
 - Click on "try it out" 
 - Past the paylod json on Request body and click in execute button.

