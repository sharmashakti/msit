## 1. Location Service Api Project
<br>
Follow below steps to run the Location Service <br> 
1. Open command prompt and navigate to directory (ch-4-Backing-Services\locationservice\src\StatlerWaldorfCorp.LocationService) <br>
2. Cmd: dotnet restore <br>
3. Cmd: dotnet run <br>

**Verification Steps**:
1. Post a New Location object using Postman or Powershell with below command <br>
> Browser Url POST http://localhost:5001/locations/63e7acf8-8fae-42ce-9349-3c8593ac8292
3. PowerShell Command:

``` 
$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("Content-Type", "application/json")

$body = "{`"id`": `"55bf35ba-deb7-4708-abc2-a21054dbfa18`", `"latitude`": 22.56, `"longitude`": 45.567, `"altitude`": 1200, `"timestamp`" : 1476029596, `"memberId`": `"63e7acf8-8fae-42ce-9349-3c8593ac8292`" }"

$response = Invoke-RestMethod 'http://localhost:5001/locations/63e7acf8-8fae-42ce-9349-3c8593ac8292' -Method 'POST' -Headers $headers -Body $body
$response | ConvertTo-Json
```
 4. Expected Outcome of the above Post Call:
    ```
   {
        "id": "55bf35ba-deb7-4708-abc2-a21054dbfa18",
        "latitude": 22.56,
        "longitude": 45.567,
        "altitude": 1200,
        "timestamp": 1476029596,
        "memberID": "63e7acf8-8fae-42ce-9349-3c8593ac8292"
    }
    ```

5. Run below Url to get Get the above added Location either in Url or PostMan tool
   > http://localhost:5001/locations/63e7acf8-8fae-42ce-9349-3c8593ac8292 

## 2. Build and Run Docker Image for Location Service
1. Open Command Prompt and navigate to Directory (ch-4-Backing-Services\locationservice)
2. Run Following Command to create Docker Image for Location Service
>  docker build -t aspnetcorelocationservice:2.0 .
3. Run following command to run Location Service Docker Image that should run on port http://localhost:**5001** , so that our Team Service Docker image can run at Port **5000**
>  docker run -p 5001:80  aspnetcorelocationservice:2.0

## 3. Build and Run the Docker Image for Team Service
1. Open Command Prompt and navigate to Directory (ch-4-Backing-Services\teamservice)
2. Run Following Command to create Docker Image for Team Service
> docker build -t aspnetcoreteamservice:2.0 .
3. Run following command to run Teams Service Docker Image that should run on port http://localhost:**5000**
>  docker run -p 5000:80  aspnetcoreteamservice:2.0

### Now your Team Service and Location Service both running concurently in their Docker Containers.
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
