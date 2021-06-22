# Chapter 5. Creating a Data Service

In previous chapter we used InMemoryLocation Repository, and now we will Postgres database to store the locations.

## 1. Setup and Run the Postgres
### Method 1 - (Easy) Download and run the Postgres Docker Image
1. Pull And run the Postgress Docker Image
    >  docker run  --rm  -p 5432:5432 --name some-postgres -e POSTGRES_PASSWORD=inteword -e POSTGRES_USER=integrator -e POSTGRES_DB=locationservice -d postgres
2. Very docker container by command: **docker ps**
   > ![image](https://user-images.githubusercontent.com/14904879/120819556-5308e400-c571-11eb-8083-d57a1ba5b19e.png)

3. Very if "LocationService" database is created and reachable
    1. Connect into the running container in iteractive mode
       > docker exec -it some-postgres bash
    3. Connect psql (postgress client)
       > psql -U integrator --dbname=locationservice ![image](https://user-images.githubusercontent.com/14904879/120820751-71231400-c572-11eb-8b42-2c01780d7afa.png)
    3. Show Database command: **\l**
       > \l 
       > ![image](https://user-images.githubusercontent.com/14904879/120821781-64eb8680-c573-11eb-86cd-aefd0aa04bd6.png)
4. Your Postgres Database is setup now!
### Method 2 - Install Postgres (Windows version manually in out host OS)

## 2. Setup Entityframework Core in Location Service Project
1. Open command prompt and navigate to directory (ch-5-Creating-a-Data-Service\locationservice\src\StatlerWaldorfCorp.LocationService) 
   1. > dotnet new tool-manifest
   2. > dotnet tool install dotnet-ef  
   3. Verify Entity Framework version
      > dotnet ef --version
   5. Output: ![image](https://user-images.githubusercontent.com/14904879/120824135-c3196900-c575-11eb-95b5-b42d5a5918e0.png)
   6. Provisions tables in Location Service Database based on Models in Location Service Project (Code First Entity Frame work approach)
   7. > dotnet ef migrations add InitialCatelog
   8. > dotnet ef database update 
   9. Output: ![image](https://user-images.githubusercontent.com/14904879/120825131-b2b5be00-c576-11eb-90e7-5ecbcd2b6fde.png)
2. Build Location Service Project
   1. dotnet restore
   2. dotnet build
   3. dotnet run --urls http://localhost:5001 (Just to see, that is no error and hitting below url should give you empty page [], as there is not data yet
      > http://localhost:5001/locations/63e7acf8-8fae-42ce-9349-3c8593ac8292 

## 3. Build and Run Location Service Locally at port **5001**
1. Open Command Prompt and navigate to Directory (ch-5-Creating-a-Data-Service\locationservice\src\StatlerWaldorfCorp.LocationService)
2. Build Location Service Project
    1. >  dotnet restore
    2. >  dotnet build
    3. >  dotnet run --urls http://localhost:5001 


## 4. Build and Run the Team Service Locally at port **5000**
1. Open Command Prompt and navigate to Directory (ch-5-Creating-a-Data-Service\teamservice\src\StatlerWaldorfCorp.TeamService)
2. Build Location Service Project
    3. >  dotnet restore
    4. >  dotnet build
    5. >  dotnet run --urls http://localhost:5000 


**The Verification steps will be same as previous chapter, the only techncal difference now is that the location data is being persisted in Postgres Database.**

### Now your Team Service and Location Service both running concurently.
1. Team Service is Running at http://localhost:5000 
2. Location Service is running at http://localhost:5001

## Verification Steps
1. **Create a new team** (In Teams Service http://localhost:5000/Teams )
> PowerShell Command

```
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Content-Type", "application/json")

$body = "{`"id`":`"e52baa63-d511-417e-9e54-7aab04286281`",
`n`"name`":`"Team Zombie`"}"

$response = Invoke-RestMethod 'http://localhost:5000/Teams' -Method 'POST' -Headers $headers -Body $body
$response | ConvertTo-Json
```
2. **Add a member to that team**  (In Teams Service 'http://localhost:5000/teams/e52baa63-d511-417e-9e54-7aab04286281/members' ) 
 > Powershell Command:
 
 ```
     $headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
    $headers.Add("Content-Type", "application/json")

    $body = "{`"id`":`"63e7acf8-8fae-42ce-9349-3c8593ac8292`", 
    `n`"firstName`":`"Al`", 
    `n`"lastName`":`"Foo`"
    `n}"

    $response = Invoke-RestMethod 'http://localhost:5000/teams/e52baa63-d511-417e-9e54-7aab04286281/members' -Method 'POST' -Headers $headers -Body $body
    $response | ConvertTo-Json
 ```
3. **Query the team details to see the member** (In Teams Service 'http://localhost:5000/teams/e52baa63-d511-417e-9e54-7aab04286281' )
> Borwser Url GET
> http://localhost:5000/teams/e52baa63-d511-417e-9e54-7aab04286281 <br><br>
> PowerShell Command 
   
```
$response = Invoke-RestMethod 'http://localhost:5000/teams/e52baa63-d511-417e-9e54-7aab04286281' -Method 'GET' -Headers $headers
$response | ConvertTo-Json
```

4. **Add a location to that member’s location history** (In Location Service http://localhost:5001/locations/{memberid} )
> Powershell Command
```
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Content-Type", "application/json")

$body = "{`"id`": `"55bf35ba-deb7-4708-abc2-a21054dbfa18`", `"latitude`": 22.56, `"longitude`": 45.567, `"altitude`": 1200, `"timestamp`" : 1476029596, `"memberId`": `"63e7acf8-8fae-42ce-9349-3c8593ac8292`" }"

$response = Invoke-RestMethod 'http://localhost:5001/locations/63e7acf8-8fae-42ce-9349-3c8593ac8292' -Method 'POST' -Headers $headers -Body $body
$response | ConvertTo-Json
```

5. **Query the member’s details from the team service to see their location added to the response**.
> Browser Url GET 
> http://localhost:5000/teams/e52baa63-d511-417e-9e54-7aab04286281/members/63e7acf8-8fae-42ce-9349-3c8593ac8292 <br> <br>
> Powershell Command

```
 $response = Invoke-RestMethod 'http://localhost:5000/teams/e52baa63-d511-417e-9e54-7aab04286281/members/63e7acf8-8fae-42ce-9349-3c8593ac8292' -Method 'GET' -Headers $headers
$response | ConvertTo-Json
```

### Now, build the docker images for the above two Location Service and Team Service applications and run them in Docker container
### And repeat above verification steps

## 6. Build and Run Docker Image for Location Service  at port **5001**
1. Open Command Prompt and navigate to Directory (ch-5-Creating-a-Data-Service\locationservice)
2. Run Following Command to create Docker Image for Location Service
>  docker build -t aspnetcorelocationservice:2.0 .
3. Run following command to run Location Service Docker Image that should run on port http://localhost:<b>5001</b> , so that our Team Service Docker image can run at Port **5000**
>  docker run --rm -p 5001:80  aspnetcorelocationservice:2.0

## 7. Build and Run the Docker Image for Team Service at port **5000**
1. Open Command Prompt and navigate to Directory (ch-5-Creating-a-Data-Service\teamservice)
2. Run Following Command to create Docker Image for Team Service
> docker build -t aspnetcoreteamservice:2.0 .
3. Run following command to run Teams Service Docker Image that should run on port http://localhost:**5000**
>  docker run -p 5000:80  aspnetcoreteamservice:2.0
